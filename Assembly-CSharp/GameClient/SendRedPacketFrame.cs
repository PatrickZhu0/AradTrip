using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019DE RID: 6622
	internal class SendRedPacketFrame : ClientFrame
	{
		// Token: 0x060103B1 RID: 66481 RVA: 0x0048A2C6 File Offset: 0x004886C6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RedPack/SendRedPack";
		}

		// Token: 0x060103B2 RID: 66482 RVA: 0x0048A2D0 File Offset: 0x004886D0
		protected override void _OnOpenFrame()
		{
			DataManager<RedPackDataManager>.GetInstance().SendWorldGetGuildRedPacketInfoReq();
			this.m_buyData = (this.userData as List<RedPacketTable>);
			this.m_sendData = (this.userData as RedPacketBaseEntry);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSelectGuildRedPackType, new ClientEventSystem.UIEventHandler(this._OnSelectGuildRedPackType));
			if (this.m_buyData == null)
			{
				this.CalGuildRedPackBuyData();
				if (this.m_buyData == null)
				{
					return;
				}
				if (this.m_buyData.Count == 0)
				{
					Debug.LogErrorFormat("m_buyData count = 0,sendRedPackType = {0}", new object[]
					{
						SendRedPacketFrame.sendRedPackType
					});
					return;
				}
			}
			this.SetRedPackTypeName();
			if (SendRedPacketFrame.sendRedPackType == SendRedPackType.NewYear)
			{
				this.select.SafeSetGray(true, true);
				UIGray uigray = this.togSelect.gameObject.SafeAddComponent(true);
				if (uigray != null)
				{
					uigray.enabled = true;
				}
				this.togSelect.interactable = false;
				this.togSelect.image.raycastTarget = false;
			}
			if (this.m_buyData.Count <= 0)
			{
				Logger.LogError("open guild send redpacket frame, buyData is invalid!");
				return;
			}
			this.m_objDecreaseMoney.SetActive(true);
			this.m_objDecreaseNum.SetActive(true);
			this.m_objIncreaseMoney.SetActive(true);
			this.m_objIncreaseNum.SetActive(true);
			RedPacketTable redPacketTable = this.m_buyData[this.m_nCurrentMoney];
			string icon = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(redPacketTable.CostMoneyID).Icon;
			ETCImageLoader.LoadSprite(ref this.m_imgMoneyIcon, icon, true);
			ETCImageLoader.LoadSprite(ref this.m_imgCostIcon, icon, true);
			ETCImageLoader.LoadSprite(ref this.m_imgOwnedIcon, icon, true);
			this.m_labMoneyCount.text = redPacketTable.TotalMoney.ToString();
			this.m_labNumCount.text = ((!this._ModifyCurrentNum(redPacketTable)) ? "0" : redPacketTable.Num[this.m_nCurrentNum].ToString());
			this.m_labCostCount.text = redPacketTable.TotalMoney.ToString();
			this.m_labOwnedCount.text = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(redPacketTable.CostMoneyID, true).ToString();
			this.m_inputName.interactable = true;
			this.m_inputName.text = redPacketTable.Desc;
			this.m_btnSend.onClick.RemoveAllListeners();
			this.m_btnSend.onClick.AddListener(delegate()
			{
				this.OnClickSendRedPack();
			});
		}

		// Token: 0x060103B3 RID: 66483 RVA: 0x0048A561 File Offset: 0x00488961
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSelectGuildRedPackType, new ClientEventSystem.UIEventHandler(this._OnSelectGuildRedPackType));
			SendRedPacketFrame.sendRedPackType = SendRedPackType.NewYear;
			this.m_buyData = null;
			this.m_sendData = null;
			this.m_nCurrentMoney = 0;
			this.m_nCurrentNum = 0;
		}

		// Token: 0x060103B4 RID: 66484 RVA: 0x0048A5A0 File Offset: 0x004889A0
		private void _OnSelectGuildRedPackType(UIEvent uiEvent)
		{
			if (uiEvent.Param1 is SendRedPackType)
			{
				this.togSelect.SafeSetToggleOnState(false);
				SendRedPackType sendRedPackType = (SendRedPackType)uiEvent.Param1;
				if (sendRedPackType != SendRedPackType.NewYear)
				{
					SendRedPacketFrame.sendRedPackType = sendRedPackType;
					this.CalGuildRedPackBuyData();
					this.SetRedPackTypeName();
					this.m_nCurrentMoney = 0;
					this.m_nCurrentNum = 0;
					this._OnMoneyDecreaesClicked();
					this._OnNumIncreaesClicked();
				}
			}
		}

		// Token: 0x060103B5 RID: 66485 RVA: 0x0048A608 File Offset: 0x00488A08
		protected override void _bindExUI()
		{
			this.type = this.mBind.GetCom<Text>("type");
			this.select = this.mBind.GetCom<Button>("select");
			this.select.SafeSetOnClickListener(delegate
			{
				this.guildRedPackTypeListRoot.CustomActive(true);
			});
			this.guildRedPackTypeListRoot = this.mBind.GetGameObject("guildRedPackTypeListRoot");
			this.togSelect = this.mBind.GetCom<Toggle>("togSelect");
			this.togSelect.SafeSetOnValueChangedListener(delegate(bool value)
			{
				this.guildRedPackTypeListRoot.CustomActive(value);
			});
		}

		// Token: 0x060103B6 RID: 66486 RVA: 0x0048A69B File Offset: 0x00488A9B
		protected override void _unbindExUI()
		{
			this.type = null;
			this.select = null;
			this.guildRedPackTypeListRoot = null;
			this.togSelect = null;
		}

		// Token: 0x060103B7 RID: 66487 RVA: 0x0048A6BC File Offset: 0x00488ABC
		private void CalGuildRedPackBuyData()
		{
			this.m_buyData = new List<RedPacketTable>();
			if (this.m_buyData == null)
			{
				return;
			}
			RedPacketTable.eThirdType eThirdType = RedPacketTable.eThirdType.INVALID;
			if (SendRedPacketFrame.sendRedPackType == SendRedPackType.GuildMember)
			{
				eThirdType = RedPacketTable.eThirdType.GUILD_ALL;
			}
			else if (SendRedPacketFrame.sendRedPackType == SendRedPackType.GuildWar)
			{
				eThirdType = RedPacketTable.eThirdType.GUILD_BATTLE;
			}
			else if (SendRedPacketFrame.sendRedPackType == SendRedPackType.CrossGuildWar)
			{
				eThirdType = RedPacketTable.eThirdType.GUILD_CROSS_BATTLE;
			}
			else if (SendRedPacketFrame.sendRedPackType == SendRedPackType.GuildDungeon)
			{
				eThirdType = RedPacketTable.eThirdType.GUILD_DUNGEON;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<RedPacketTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					RedPacketTable redPacketTable = keyValuePair.Value as RedPacketTable;
					if (redPacketTable != null)
					{
						if (redPacketTable.ThirdType == eThirdType && redPacketTable.SubType == RedPacketTable.eSubType.Buy)
						{
							this.m_buyData.Add(redPacketTable);
						}
					}
				}
			}
		}

		// Token: 0x060103B8 RID: 66488 RVA: 0x0048A794 File Offset: 0x00488B94
		public static string GetRedPackTypeName(SendRedPackType sendRedPackType)
		{
			switch (sendRedPackType)
			{
			case SendRedPackType.NewYear:
				return TR.Value("guild_red_packet_type_new_year");
			case SendRedPackType.GuildMember:
				return TR.Value("guild_red_packet_type_all_members");
			case SendRedPackType.GuildWar:
				return TR.Value("guild_red_packet_type_guild_war");
			case SendRedPackType.CrossGuildWar:
				return TR.Value("guild_red_packet_type_cross_guild_war");
			case SendRedPackType.GuildDungeon:
				return TR.Value("guild_red_packet_type_guild_dungeon");
			default:
				return string.Empty;
			}
		}

		// Token: 0x060103B9 RID: 66489 RVA: 0x0048A7FE File Offset: 0x00488BFE
		private void SetRedPackTypeName()
		{
			this.type.SafeSetText(SendRedPacketFrame.GetRedPackTypeName(SendRedPacketFrame.sendRedPackType));
		}

		// Token: 0x060103BA RID: 66490 RVA: 0x0048A818 File Offset: 0x00488C18
		private bool _ModifyCurrentMoney()
		{
			if (this.m_nCurrentMoney < 0)
			{
				this.m_nCurrentMoney = 0;
			}
			if (this.m_nCurrentMoney >= this.m_buyData.Count)
			{
				this.m_nCurrentMoney = this.m_buyData.Count - 1;
			}
			if (this.m_nCurrentMoney >= 0 && this.m_nCurrentMoney < this.m_buyData.Count)
			{
				return true;
			}
			Logger.LogErrorFormat("当前选中的红包金额非法！(index:{0})", new object[]
			{
				this.m_nCurrentMoney
			});
			return false;
		}

		// Token: 0x060103BB RID: 66491 RVA: 0x0048A8A4 File Offset: 0x00488CA4
		private bool _ModifyCurrentNum(RedPacketTable a_data)
		{
			if (this.m_nCurrentNum < 0)
			{
				this.m_nCurrentNum = 0;
			}
			if (this.m_nCurrentNum >= a_data.Num.Count)
			{
				this.m_nCurrentNum = a_data.Num.Count - 1;
			}
			if (this.m_nCurrentNum >= 0 && this.m_nCurrentNum < a_data.Num.Count)
			{
				return true;
			}
			Logger.LogErrorFormat("当前选中的红包数量非法！(index:{0})", new object[]
			{
				this.m_nCurrentNum
			});
			return false;
		}

		// Token: 0x060103BC RID: 66492 RVA: 0x0048A930 File Offset: 0x00488D30
		private void OnClickSendRedPack()
		{
			if (this.m_nCurrentMoney >= 0 && this.m_nCurrentMoney < this.m_buyData.Count)
			{
				RedPacketTable temp = this.m_buyData[this.m_nCurrentMoney];
				if (this.m_nCurrentNum >= 0 && this.m_nCurrentNum < temp.Num.Count)
				{
					string strName = this.m_inputName.text;
					if (!string.IsNullOrEmpty(strName))
					{
						string msgContent = TR.Value("guild_red_packet_send_confirm", temp.TotalMoney);
						if (temp.ThirdType != RedPacketTable.eThirdType.INVALID)
						{
							GuildRedPacketSpecInfo guildRedPacketSpecInfo = DataManager<RedPackDataManager>.GetInstance().GetGuildRedPacketSpecInfo(SendRedPacketFrame.sendRedPackType);
							if (guildRedPacketSpecInfo != null && (ulong)guildRedPacketSpecInfo.joinNum < (ulong)((long)temp.Num[this.m_nCurrentNum]))
							{
								msgContent = TR.Value("guild_red_packet_send_confirm2", temp.TotalMoney);
							}
						}
						SystemNotifyManager.SysNotifyMsgBoxCancelOk(msgContent, null, delegate()
						{
							CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
							costInfo.nMoneyID = temp.CostMoneyID;
							costInfo.nCount = temp.TotalMoney;
							DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
							{
								DataManager<RedPackDataManager>.GetInstance().SendRedPacket((ushort)temp.ID, temp.Num[this.m_nCurrentNum], strName);
								this.frameMgr.CloseFrame<SendRedPacketFrame>(this, false);
							}, "common_money_cost", null);
						}, 0f, false, null);
					}
					else
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_redpacket_send_need_name"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
				}
				else
				{
					Logger.LogErrorFormat("当前选中的红包数量非法！(index:{0})", new object[]
					{
						this.m_nCurrentNum
					});
				}
			}
			else
			{
				Logger.LogErrorFormat("当前选中的红包金额非法！(index:{0})", new object[]
				{
					this.m_nCurrentMoney
				});
			}
		}

		// Token: 0x060103BD RID: 66493 RVA: 0x0048AACC File Offset: 0x00488ECC
		[UIEventHandle("TotalMoney/Decrease")]
		private void _OnMoneyDecreaesClicked()
		{
			this.m_nCurrentMoney--;
			if (this._ModifyCurrentMoney())
			{
				RedPacketTable redPacketTable = this.m_buyData[this.m_nCurrentMoney];
				string icon = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(redPacketTable.CostMoneyID).Icon;
				ETCImageLoader.LoadSprite(ref this.m_imgMoneyIcon, icon, true);
				ETCImageLoader.LoadSprite(ref this.m_imgCostIcon, icon, true);
				ETCImageLoader.LoadSprite(ref this.m_imgOwnedIcon, icon, true);
				this.m_labMoneyCount.text = redPacketTable.TotalMoney.ToString();
				this.m_labNumCount.text = ((!this._ModifyCurrentNum(redPacketTable)) ? "0" : redPacketTable.Num[this.m_nCurrentNum].ToString());
				this.m_labCostCount.text = redPacketTable.TotalMoney.ToString();
				this.m_labOwnedCount.text = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(redPacketTable.CostMoneyID, true).ToString();
			}
		}

		// Token: 0x060103BE RID: 66494 RVA: 0x0048ABF0 File Offset: 0x00488FF0
		[UIEventHandle("TotalMoney/Increase")]
		private void _OnMoneyIncreaesClicked()
		{
			this.m_nCurrentMoney++;
			if (this._ModifyCurrentMoney())
			{
				RedPacketTable redPacketTable = this.m_buyData[this.m_nCurrentMoney];
				string icon = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(redPacketTable.CostMoneyID).Icon;
				ETCImageLoader.LoadSprite(ref this.m_imgMoneyIcon, icon, true);
				ETCImageLoader.LoadSprite(ref this.m_imgCostIcon, icon, true);
				ETCImageLoader.LoadSprite(ref this.m_imgOwnedIcon, icon, true);
				this.m_labMoneyCount.text = redPacketTable.TotalMoney.ToString();
				this.m_labNumCount.text = ((!this._ModifyCurrentNum(redPacketTable)) ? "0" : redPacketTable.Num[this.m_nCurrentNum].ToString());
				this.m_labCostCount.text = redPacketTable.TotalMoney.ToString();
				this.m_labOwnedCount.text = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(redPacketTable.CostMoneyID, true).ToString();
			}
		}

		// Token: 0x060103BF RID: 66495 RVA: 0x0048AD14 File Offset: 0x00489114
		[UIEventHandle("TotalNum/Decrease")]
		private void _OnNumDecreaesClicked()
		{
			this.m_nCurrentNum--;
			RedPacketTable redPacketTable = this.m_buyData[this.m_nCurrentMoney];
			this.m_labNumCount.text = ((!this._ModifyCurrentNum(redPacketTable)) ? "0" : redPacketTable.Num[this.m_nCurrentNum].ToString());
		}

		// Token: 0x060103C0 RID: 66496 RVA: 0x0048AD84 File Offset: 0x00489184
		[UIEventHandle("TotalNum/Increase")]
		private void _OnNumIncreaesClicked()
		{
			this.m_nCurrentNum++;
			RedPacketTable redPacketTable = this.m_buyData[this.m_nCurrentMoney];
			this.m_labNumCount.text = ((!this._ModifyCurrentNum(redPacketTable)) ? "0" : redPacketTable.Num[this.m_nCurrentNum].ToString());
		}

		// Token: 0x0400A431 RID: 42033
		[UIObject("TotalMoney/Decrease")]
		private GameObject m_objDecreaseMoney;

		// Token: 0x0400A432 RID: 42034
		[UIObject("TotalMoney/Increase")]
		private GameObject m_objIncreaseMoney;

		// Token: 0x0400A433 RID: 42035
		[UIObject("TotalNum/Decrease")]
		private GameObject m_objDecreaseNum;

		// Token: 0x0400A434 RID: 42036
		[UIObject("TotalNum/Increase")]
		private GameObject m_objIncreaseNum;

		// Token: 0x0400A435 RID: 42037
		[UIControl("TotalMoney/Group/Icon", null, 0)]
		private Image m_imgMoneyIcon;

		// Token: 0x0400A436 RID: 42038
		[UIControl("TotalMoney/Group/Text", null, 0)]
		private Text m_labMoneyCount;

		// Token: 0x0400A437 RID: 42039
		[UIControl("TotalNum/Group/Text", null, 0)]
		private Text m_labNumCount;

		// Token: 0x0400A438 RID: 42040
		[UIControl("Name/InputField", typeof(InputField), 0)]
		private InputField m_inputName;

		// Token: 0x0400A439 RID: 42041
		[UIControl("Button/Icon", null, 0)]
		private Image m_imgCostIcon;

		// Token: 0x0400A43A RID: 42042
		[UIControl("Button/Count", null, 0)]
		private Text m_labCostCount;

		// Token: 0x0400A43B RID: 42043
		[UIControl("Owned/Group/Icon", null, 0)]
		private Image m_imgOwnedIcon;

		// Token: 0x0400A43C RID: 42044
		[UIControl("Owned/Group/Text", null, 0)]
		private Text m_labOwnedCount;

		// Token: 0x0400A43D RID: 42045
		[UIControl("Button", null, 0)]
		private Button m_btnSend;

		// Token: 0x0400A43E RID: 42046
		private List<RedPacketTable> m_buyData;

		// Token: 0x0400A43F RID: 42047
		private int m_nCurrentMoney;

		// Token: 0x0400A440 RID: 42048
		private int m_nCurrentNum;

		// Token: 0x0400A441 RID: 42049
		private RedPacketBaseEntry m_sendData;

		// Token: 0x0400A442 RID: 42050
		public static SendRedPackType sendRedPackType = SendRedPackType.NewYear;

		// Token: 0x0400A443 RID: 42051
		private Text type;

		// Token: 0x0400A444 RID: 42052
		private Button select;

		// Token: 0x0400A445 RID: 42053
		private GameObject guildRedPackTypeListRoot;

		// Token: 0x0400A446 RID: 42054
		private Toggle togSelect;
	}
}
