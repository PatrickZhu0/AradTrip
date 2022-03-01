using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001648 RID: 5704
	internal class GuildRedPackFrame : ClientFrame
	{
		// Token: 0x0600E073 RID: 57459 RVA: 0x0039653C File Offset: 0x0039493C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildRedPack";
		}

		// Token: 0x0600E074 RID: 57460 RVA: 0x00396544 File Offset: 0x00394944
		protected override void _OnOpenFrame()
		{
			if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				return;
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, "MyRedPack/ScrollView/Template", true);
			gameObject.SetActive(false);
			this.m_objMyTemplate1.transform.SetParent(gameObject.transform, false);
			this.m_objMyTemplate2.transform.SetParent(gameObject.transform, false);
			this.m_objOtherTemplate.transform.SetParent(gameObject.transform, false);
			this._InitBuyTableData();
			this._InitMyRedPacket();
			this._InitOtherRedPacket();
			this._RegisterUIEvent();
		}

		// Token: 0x0600E075 RID: 57461 RVA: 0x003965D7 File Offset: 0x003949D7
		protected override void _OnCloseFrame()
		{
			this.m_arrMyInfos.Clear();
			this.m_arrOtherInfos.Clear();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600E076 RID: 57462 RVA: 0x003965F5 File Offset: 0x003949F5
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600E077 RID: 57463 RVA: 0x003965F7 File Offset: 0x003949F7
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600E078 RID: 57464 RVA: 0x003965FC File Offset: 0x003949FC
		private void _InitBuyTableData()
		{
			if (!this.m_bTableDataInited)
			{
				foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<RedPacketTable>())
				{
					RedPacketTable redPacketTable = keyValuePair.Value as RedPacketTable;
					if (redPacketTable.Type == RedPacketTable.eType.GUILD && redPacketTable.SubType == RedPacketTable.eSubType.Buy)
					{
						this.m_arrBuyTable.Add(redPacketTable);
					}
				}
				if (this.m_arrBuyTable.Count > 0)
				{
					this.m_arrBuyTable.Sort((RedPacketTable a, RedPacketTable b) => a.TotalMoney - b.TotalMoney);
				}
				this.m_bTableDataInited = true;
			}
		}

		// Token: 0x0600E079 RID: 57465 RVA: 0x003966B0 File Offset: 0x00394AB0
		private int _GetRemainBuyTime()
		{
			int value = Singleton<TableManager>.instance.GetTableItem<SystemValueTable>(124, string.Empty, string.Empty).Value;
			int count = DataManager<CountDataManager>.GetInstance().GetCount("guild_pay_rp");
			int num = value - count;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E07A RID: 57466 RVA: 0x003966F8 File Offset: 0x00394AF8
		private void _InitMyRedPacket()
		{
			this.m_arrMyInfos.Clear();
			List<RedPacketBaseEntry> redPacketsByType = DataManager<RedPackDataManager>.GetInstance().GetRedPacketsByType(RedPacketType.GUILD);
			for (int i = 0; i < redPacketsByType.Count; i++)
			{
				this._CreateMyRedPacket(redPacketsByType[i]);
			}
			this._CreateMyRedPacketBuy();
			this._UpdateMyRedPacketLayout();
		}

		// Token: 0x0600E07B RID: 57467 RVA: 0x0039674C File Offset: 0x00394B4C
		private void _InitOtherRedPacket()
		{
			this.m_arrOtherInfos.Clear();
			List<RedPacketBaseEntry> redPacketsByType = DataManager<RedPackDataManager>.GetInstance().GetRedPacketsByType(RedPacketType.GUILD);
			for (int i = 0; i < redPacketsByType.Count; i++)
			{
				this._CreateOtherRedPacket(redPacketsByType[i]);
			}
			this._UpdateOtherRedPacketLayout();
		}

		// Token: 0x0600E07C RID: 57468 RVA: 0x0039679C File Offset: 0x00394B9C
		private void _CreateMyRedPacket(RedPacketBaseEntry a_data)
		{
			if (a_data.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			GuildRedPackFrame.RedPacketMyInfo redPacketMyInfo = new GuildRedPackFrame.RedPacketMyInfo();
			redPacketMyInfo.data = a_data;
			if (a_data.status == 0)
			{
				redPacketMyInfo.objRoot = Object.Instantiate<GameObject>(this.m_objMyTemplate1);
				redPacketMyInfo.objRoot.SetActive(true);
				redPacketMyInfo.objRoot.transform.SetParent(this.m_objMyRoot.transform, false);
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Title").text = a_data.name;
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Func").text = TR.Value("guild_redpacket_send_single");
				Image componetInChild = Utility.GetComponetInChild<Image>(redPacketMyInfo.objRoot, "Desc/Image");
				ETCImageLoader.LoadSprite(ref componetInChild, DataManager<RedPackDataManager>.GetInstance().GetCostMoneyIcon((int)a_data.reason), true);
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Desc/Text").text = a_data.totalMoney.ToString();
				Button component = redPacketMyInfo.objRoot.GetComponent<Button>();
				component.onClick.RemoveAllListeners();
				component.onClick.AddListener(delegate()
				{
				});
			}
			else if (a_data.status == 2 && a_data.opened == 0)
			{
				redPacketMyInfo.objRoot = Object.Instantiate<GameObject>(this.m_objMyTemplate1);
				redPacketMyInfo.objRoot.SetActive(true);
				redPacketMyInfo.objRoot.transform.SetParent(this.m_objMyRoot.transform, false);
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Title").text = a_data.name;
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Func").text = TR.Value("guild_redpacket_open_single");
				Image componetInChild2 = Utility.GetComponetInChild<Image>(redPacketMyInfo.objRoot, "Desc/Image");
				ETCImageLoader.LoadSprite(ref componetInChild2, DataManager<RedPackDataManager>.GetInstance().GetCostMoneyIcon((int)a_data.reason), true);
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Desc/Text").text = a_data.totalMoney.ToString();
				Button component2 = redPacketMyInfo.objRoot.GetComponent<Button>();
				component2.onClick.RemoveAllListeners();
				component2.onClick.AddListener(delegate()
				{
				});
			}
			else
			{
				redPacketMyInfo.objRoot = Object.Instantiate<GameObject>(this.m_objMyTemplate2);
				redPacketMyInfo.objRoot.SetActive(true);
				redPacketMyInfo.objRoot.transform.SetParent(this.m_objMyRoot.transform, false);
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Name").text = a_data.name;
				Image componetInChild3 = Utility.GetComponetInChild<Image>(redPacketMyInfo.objRoot, "Desc/Image");
				ETCImageLoader.LoadSprite(ref componetInChild3, DataManager<RedPackDataManager>.GetInstance().GetCostMoneyIcon((int)a_data.reason), true);
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Desc/Text").text = a_data.totalMoney.ToString();
				Button component3 = redPacketMyInfo.objRoot.GetComponent<Button>();
				component3.onClick.RemoveAllListeners();
				component3.onClick.AddListener(delegate()
				{
					DataManager<RedPackDataManager>.GetInstance().CheckRedPacket(a_data.id);
				});
			}
			this.m_arrMyInfos.Add(redPacketMyInfo);
		}

		// Token: 0x0600E07D RID: 57469 RVA: 0x00396B38 File Offset: 0x00394F38
		private void _CreateMyRedPacketBuy()
		{
			if (this.m_arrBuyTable.Count > 0)
			{
				GuildRedPackFrame.RedPacketMyInfo redPacketMyInfo = new GuildRedPackFrame.RedPacketMyInfo();
				redPacketMyInfo.data = null;
				redPacketMyInfo.objRoot = Object.Instantiate<GameObject>(this.m_objMyTemplate1);
				redPacketMyInfo.objRoot.SetActive(true);
				redPacketMyInfo.objRoot.transform.SetParent(this.m_objMyRoot.transform, false);
				Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Title").text = TR.Value("guild_redpacket_buy_desc");
				Utility.GetComponetInChild<Image>(redPacketMyInfo.objRoot, "Desc/Image").gameObject.SetActive(false);
				Text componetInChild = Utility.GetComponetInChild<Text>(redPacketMyInfo.objRoot, "Desc/Text");
				if (Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.GUILD_PRIVATECOST_REDPACKET) == 0f)
				{
					int key = Utility.GetFirstValidVipLevelPrivilegeData(VipPrivilegeTable.eType.GUILD_PRIVATECOST_REDPACKET).Key;
					componetInChild.text = TR.Value("vip_open_limit_desc", key);
				}
				else
				{
					componetInChild.text = TR.Value("guild_redpacket_buy_remain_time", this._GetRemainBuyTime());
				}
				Button component = redPacketMyInfo.objRoot.GetComponent<Button>();
				component.onClick.RemoveAllListeners();
				component.onClick.AddListener(delegate()
				{
				});
				this.m_arrMyInfos.Add(redPacketMyInfo);
			}
		}

		// Token: 0x0600E07E RID: 57470 RVA: 0x00396C8C File Offset: 0x0039508C
		private void _CreateOtherRedPacket(RedPacketBaseEntry a_data)
		{
			if (a_data.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			RedPacketTable tableItem = Singleton<TableManager>.instance.GetTableItem<RedPacketTable>((int)a_data.reason, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("红包表找不到ID为{0}的数据，可能服务器和客户端表格不一致", new object[]
				{
					a_data.reason
				});
				return;
			}
			GuildRedPackFrame.RedPacketOtherInfo redPacketOtherInfo = new GuildRedPackFrame.RedPacketOtherInfo();
			redPacketOtherInfo.data = a_data;
			redPacketOtherInfo.objRoot = Object.Instantiate<GameObject>(this.m_objOtherTemplate);
			redPacketOtherInfo.objRoot.transform.SetParent(this.m_objOtherRoot.transform, false);
			redPacketOtherInfo.objRoot.SetActive(true);
			redPacketOtherInfo.labFunc = Utility.GetComponetInChild<Text>(redPacketOtherInfo.objRoot, "Func/Text");
			Image componetInChild = Utility.GetComponetInChild<Image>(redPacketOtherInfo.objRoot, "Tag");
			if (redPacketOtherInfo.data.status == 2 && redPacketOtherInfo.data.opened == 0)
			{
				redPacketOtherInfo.labFunc.text = TR.Value("guild_redpacket_open");
			}
			else
			{
				redPacketOtherInfo.labFunc.text = TR.Value("guild_redpacket_check");
			}
			Utility.GetComponetInChild<Text>(redPacketOtherInfo.objRoot, "OwnerName").text = redPacketOtherInfo.data.ownerName;
			Utility.GetComponetInChild<Text>(redPacketOtherInfo.objRoot, "Name").text = redPacketOtherInfo.data.name;
			Utility.GetComponetInChild<Text>(redPacketOtherInfo.objRoot, "Desc/Count").text = redPacketOtherInfo.data.totalMoney.ToString();
			Image componetInChild2 = Utility.GetComponetInChild<Image>(redPacketOtherInfo.objRoot, "Desc/Icon");
			ETCImageLoader.LoadSprite(ref componetInChild2, DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.CostMoneyID).Icon, true);
			Button componetInChild3 = Utility.GetComponetInChild<Button>(redPacketOtherInfo.objRoot, "Func");
			componetInChild3.onClick.RemoveAllListeners();
			componetInChild3.onClick.AddListener(delegate()
			{
			});
			this.m_arrOtherInfos.Add(redPacketOtherInfo);
		}

		// Token: 0x0600E07F RID: 57471 RVA: 0x00396E9C File Offset: 0x0039529C
		private void _UpdateMyRedPacketLayout()
		{
			this.m_arrMyInfos.Sort(delegate(GuildRedPackFrame.RedPacketMyInfo a, GuildRedPackFrame.RedPacketMyInfo b)
			{
				if (a.data == null)
				{
					return 1;
				}
				if (b.data == null)
				{
					return -1;
				}
				if (a.data.status == 0)
				{
					if (b.data.status == 0)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (a.data.status != 2)
					{
						return 1;
					}
					if (b.data.status == 0)
					{
						return 1;
					}
					if (b.data.status == 2)
					{
						return (int)(a.data.opened - b.data.opened);
					}
					return -1;
				}
			});
			for (int i = 0; i < this.m_arrMyInfos.Count; i++)
			{
				this.m_arrMyInfos[i].objRoot.transform.SetSiblingIndex(i);
			}
		}

		// Token: 0x0600E080 RID: 57472 RVA: 0x00396F0C File Offset: 0x0039530C
		private void _UpdateOtherRedPacketLayout()
		{
			this.m_arrOtherInfos.Sort(delegate(GuildRedPackFrame.RedPacketOtherInfo a, GuildRedPackFrame.RedPacketOtherInfo b)
			{
				if (a.data.status == 2)
				{
					if (b.data.status == 2)
					{
						return (int)(a.data.opened - b.data.opened);
					}
					return -1;
				}
				else
				{
					if (b.data.status == 2)
					{
						return 1;
					}
					return 0;
				}
			});
			for (int i = 0; i < this.m_arrOtherInfos.Count; i++)
			{
				this.m_arrOtherInfos[i].objRoot.transform.SetSiblingIndex(i);
			}
		}

		// Token: 0x0600E081 RID: 57473 RVA: 0x00396F7C File Offset: 0x0039537C
		private void _UpdateMyRedPacketBuy()
		{
			for (int i = 0; i < this.m_arrMyInfos.Count; i++)
			{
				if (this.m_arrMyInfos[i].data == null)
				{
					Utility.GetComponetInChild<Text>(this.m_arrMyInfos[i].objRoot, "Desc/Text").text = TR.Value("guild_redpacket_buy_remain_time", this._GetRemainBuyTime());
				}
			}
		}

		// Token: 0x0600E082 RID: 57474 RVA: 0x00396FF0 File Offset: 0x003953F0
		private void _OnSendSuccess(UIEvent a_event)
		{
			RedPacketBaseEntry redPacketBaseInfo = DataManager<RedPackDataManager>.GetInstance().GetRedPacketBaseInfo((ulong)a_event.Param1);
			if (redPacketBaseInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				for (int i = 0; i < this.m_arrMyInfos.Count; i++)
				{
					if (this.m_arrMyInfos[i].data != null && this.m_arrMyInfos[i].data.id == redPacketBaseInfo.id)
					{
						Object.Destroy(this.m_arrMyInfos[i].objRoot);
						this.m_arrMyInfos.RemoveAt(i);
						break;
					}
				}
				this._UpdateMyRedPacketBuy();
				this._CreateMyRedPacket(redPacketBaseInfo);
				this._UpdateMyRedPacketLayout();
				string text = TR.Value("guild_redpacket_send_chat", DataManager<PlayerBaseData>.GetInstance().Name, redPacketBaseInfo.id);
				text = text.Replace('(', '{');
				text = text.Replace(')', '}');
				DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_GUILD, text, 0UL, 0);
			}
		}

		// Token: 0x0600E083 RID: 57475 RVA: 0x003970FC File Offset: 0x003954FC
		private void _OnOpenSuccess(UIEvent a_event)
		{
			RedPacketDetail redPacketDetail = a_event.Param1 as RedPacketDetail;
			if (redPacketDetail.baseEntry.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				for (int i = 0; i < this.m_arrMyInfos.Count; i++)
				{
					if (this.m_arrMyInfos[i].data != null && this.m_arrMyInfos[i].data.id == redPacketDetail.baseEntry.id)
					{
						Object.Destroy(this.m_arrMyInfos[i].objRoot);
						this.m_arrMyInfos.RemoveAt(i);
						break;
					}
				}
				this._CreateMyRedPacket(redPacketDetail.baseEntry);
				this._UpdateMyRedPacketLayout();
			}
			else
			{
				for (int j = 0; j < this.m_arrOtherInfos.Count; j++)
				{
					if (this.m_arrOtherInfos[j].data.id == redPacketDetail.baseEntry.id)
					{
						if (this.m_arrOtherInfos[j].data.status == 2 && this.m_arrOtherInfos[j].data.opened == 0)
						{
							this.m_arrOtherInfos[j].labFunc.text = TR.Value("guild_redpacket_open");
						}
						else
						{
							this.m_arrOtherInfos[j].labFunc.text = TR.Value("guild_redpacket_check");
						}
						this._UpdateOtherRedPacketLayout();
						break;
					}
				}
			}
		}

		// Token: 0x0600E084 RID: 57476 RVA: 0x0039728E File Offset: 0x0039568E
		private void _OnCheckSuccess(UIEvent a_event)
		{
		}

		// Token: 0x0600E085 RID: 57477 RVA: 0x00397290 File Offset: 0x00395690
		private void _OnGetRedPacket(UIEvent a_event)
		{
			List<ulong> list = (List<ulong>)a_event.Param1;
			for (int i = 0; i < list.Count; i++)
			{
				RedPacketBaseEntry redPacketBaseInfo = DataManager<RedPackDataManager>.GetInstance().GetRedPacketBaseInfo(list[i]);
				if (redPacketBaseInfo != null)
				{
					if (redPacketBaseInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						this._CreateMyRedPacket(redPacketBaseInfo);
						this._UpdateMyRedPacketLayout();
					}
					else
					{
						this._CreateOtherRedPacket(redPacketBaseInfo);
						this._UpdateOtherRedPacketLayout();
					}
				}
			}
		}

		// Token: 0x0600E086 RID: 57478 RVA: 0x0039730C File Offset: 0x0039570C
		private void _OnDeleteRedPacket(UIEvent a_event)
		{
			ulong[] array = (ulong[])a_event.Param1;
			for (int i = 0; i < array.Length; i++)
			{
				ulong uID = array[i];
				int num = this.m_arrMyInfos.FindIndex((GuildRedPackFrame.RedPacketMyInfo value) => value.data != null && value.data.id == uID);
				if (num >= 0 && num < this.m_arrMyInfos.Count)
				{
					Object.Destroy(this.m_arrMyInfos[num].objRoot);
					this.m_arrMyInfos.RemoveAt(num);
				}
			}
		}

		// Token: 0x0600E087 RID: 57479 RVA: 0x0039739A File Offset: 0x0039579A
		[UIEventHandle("BG/Title/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GuildRedPackFrame>(this, false);
		}

		// Token: 0x04008583 RID: 34179
		[UIObject("MyRedPack/ScrollView/Viewport/Content/Template1")]
		private GameObject m_objMyTemplate1;

		// Token: 0x04008584 RID: 34180
		[UIObject("MyRedPack/ScrollView/Viewport/Content/Template2")]
		private GameObject m_objMyTemplate2;

		// Token: 0x04008585 RID: 34181
		[UIObject("MyRedPack/ScrollView/Viewport/Content")]
		private GameObject m_objMyRoot;

		// Token: 0x04008586 RID: 34182
		[UIObject("OtherRedPack/ScrollView/Viewport/Content")]
		private GameObject m_objOtherRoot;

		// Token: 0x04008587 RID: 34183
		[UIObject("OtherRedPack/ScrollView/Viewport/Content/Template")]
		private GameObject m_objOtherTemplate;

		// Token: 0x04008588 RID: 34184
		private bool m_bTableDataInited;

		// Token: 0x04008589 RID: 34185
		private List<RedPacketTable> m_arrBuyTable = new List<RedPacketTable>();

		// Token: 0x0400858A RID: 34186
		private List<GuildRedPackFrame.RedPacketMyInfo> m_arrMyInfos = new List<GuildRedPackFrame.RedPacketMyInfo>();

		// Token: 0x0400858B RID: 34187
		private List<GuildRedPackFrame.RedPacketOtherInfo> m_arrOtherInfos = new List<GuildRedPackFrame.RedPacketOtherInfo>();

		// Token: 0x02001649 RID: 5705
		private class RedPacketMyInfo
		{
			// Token: 0x04008593 RID: 34195
			public RedPacketBaseEntry data;

			// Token: 0x04008594 RID: 34196
			public GameObject objRoot;
		}

		// Token: 0x0200164A RID: 5706
		private class RedPacketOtherInfo
		{
			// Token: 0x04008595 RID: 34197
			public RedPacketBaseEntry data;

			// Token: 0x04008596 RID: 34198
			public GameObject objRoot;

			// Token: 0x04008597 RID: 34199
			public Text labFunc;
		}
	}
}
