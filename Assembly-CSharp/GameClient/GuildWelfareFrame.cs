using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001665 RID: 5733
	internal class GuildWelfareFrame : ClientFrame
	{
		// Token: 0x0600E16F RID: 57711 RVA: 0x0039D12B File Offset: 0x0039B52B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildWelfare";
		}

		// Token: 0x0600E170 RID: 57712 RVA: 0x0039D134 File Offset: 0x0039B534
		protected override void _OnOpenFrame()
		{
			if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				return;
			}
			int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.WELFARE);
			this.m_objRecordTemplate.SetActive(false);
			this.m_labDonateGoldGet.text = DataManager<GuildDataManager>.GetInstance().donateGoldGet.ToString();
			this.m_labDonateGoldCostCount.text = DataManager<GuildDataManager>.GetInstance().donateGoldCost.ToString();
			ItemData moneyTableDataByType = DataManager<ItemDataManager>.GetInstance().GetMoneyTableDataByType(ItemTable.eSubType.BindGOLD);
			ETCImageLoader.LoadSprite(ref this.m_imgDonateGoldCostIcon, moneyTableDataByType.Icon, true);
			int num = this._GetGoldDonateMaxTimes();
			int num2 = this._GetGoldDonateRemainTimes();
			int num3 = this.m_nSelectGoldTimes * 5;
			if (num3 < 1)
			{
				num3 = 1;
			}
			if (num3 > num2)
			{
				num3 = num2;
			}
			this.m_labDonateGoldTimes.text = num3.ToString();
			this.m_labDonateGoldRemainTimes.text = TR.Value("guild_remain_times", num2, num);
			this.m_labDonateTicketGet.text = DataManager<GuildDataManager>.GetInstance().donatePointGet.ToString();
			this.m_labDonateTicketCostCount.text = DataManager<GuildDataManager>.GetInstance().donatePointCost.ToString();
			ItemData moneyTableDataByType2 = DataManager<ItemDataManager>.GetInstance().GetMoneyTableDataByType(ItemTable.eSubType.BindPOINT);
			ETCImageLoader.LoadSprite(ref this.m_imgDonateTicketCostIcon, moneyTableDataByType2.Icon, true);
			int num4 = this._GetTicketDonateMaxTimes();
			int num5 = this._GetTicketDonateRemainTimes();
			int num6 = this.m_nSelectTicketTimes * 5;
			if (num6 < 1)
			{
				num6 = 1;
			}
			if (num6 > num5)
			{
				num6 = num5;
			}
			this.m_labDonateTicketTimes.text = num6.ToString();
			this.m_labDonateTicketRemainTimes.text = TR.Value("guild_remain_times", num5, num4);
			int num7 = this._GetExchangeMaxTimes();
			int num8 = this._GetExchangeRemainTimes();
			this.m_labExchangeRemainTimes.text = TR.Value("guild_remain_times", num8, num7);
			this._UpdateExchangeItem();
			ItemData moneyTableDataByType3 = DataManager<ItemDataManager>.GetInstance().GetMoneyTableDataByType(ItemTable.eSubType.GuildContri);
			ETCImageLoader.LoadSprite(ref this.m_imgExchangeCostIcon, moneyTableDataByType3.Icon, true);
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(114, string.Empty, string.Empty).Value;
			this.m_imgExchangeCostCount.text = value.ToString();
			this._UpdateExchangeCD();
			this._UpdateExchangeRedPoint();
			this._TryStartExchangeCDCounter();
			DataManager<GuildDataManager>.GetInstance().RequsetDonateLog();
			this._RegisterUIEvent();
		}

		// Token: 0x0600E171 RID: 57713 RVA: 0x0039D3C5 File Offset: 0x0039B7C5
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_delayCallUnit);
			this.m_nSelectGoldTimes = 0;
			this.m_nSelectTicketTimes = 0;
		}

		// Token: 0x0600E172 RID: 57714 RVA: 0x0039D3F0 File Offset: 0x0039B7F0
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestDonateLogSuccess, new ClientEventSystem.UIEventHandler(this._OnRecordListUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDonateSuccess, new ClientEventSystem.UIEventHandler(this._OnDonateSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildExchangeSuccess, new ClientEventSystem.UIEventHandler(this._OnExchangeSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildUpgradeBuildingSuccess, new ClientEventSystem.UIEventHandler(this._OnBuildingUpgradeSuccess));
		}

		// Token: 0x0600E173 RID: 57715 RVA: 0x0039D484 File Offset: 0x0039B884
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestDonateLogSuccess, new ClientEventSystem.UIEventHandler(this._OnRecordListUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDonateSuccess, new ClientEventSystem.UIEventHandler(this._OnDonateSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildExchangeSuccess, new ClientEventSystem.UIEventHandler(this._OnExchangeSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildUpgradeBuildingSuccess, new ClientEventSystem.UIEventHandler(this._OnBuildingUpgradeSuccess));
		}

		// Token: 0x0600E174 RID: 57716 RVA: 0x0039D518 File Offset: 0x0039B918
		private void _TryStartExchangeCDCounter()
		{
			uint nExchangeCoolTime = DataManager<GuildDataManager>.GetInstance().myGuild.nExchangeCoolTime;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (nExchangeCoolTime > serverTime)
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_delayCallUnit);
				this.m_delayCallUnit = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(1000, new DelayCaller.Del(this._UpdateExchangeCD), 9999999, false);
			}
		}

		// Token: 0x0600E175 RID: 57717 RVA: 0x0039D588 File Offset: 0x0039B988
		private void _UpdateExchangeItem()
		{
			int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.WELFARE);
			GuildBuildingTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(buildingLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ComItem comItem = this.m_objExchangeItemRoot.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = base.CreateComItem(this.m_objExchangeItemRoot);
				}
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.WelfareGiftId);
				comItem.Setup(commonItemTableDataByID, delegate(GameObject a_obj, ItemData a_item)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
				});
				this.m_labExchangeItemName.text = commonItemTableDataByID.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x0600E176 RID: 57718 RVA: 0x0039D630 File Offset: 0x0039BA30
		private void _UpdateExchangeCD()
		{
			uint nExchangeCoolTime = DataManager<GuildDataManager>.GetInstance().myGuild.nExchangeCoolTime;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (nExchangeCoolTime > serverTime)
			{
				uint num = nExchangeCoolTime - serverTime;
				uint num2 = 0U;
				uint num3 = 0U;
				uint num4 = num % 60U;
				uint num5 = num / 60U;
				if (num5 > 0U)
				{
					num2 = num5 % 60U;
					num3 = num5 / 60U;
				}
				this.m_labExchangeCD.gameObject.SetActive(true);
				this.m_labExchangeCD.text = string.Format("{0:00}:{1:00}:{2:00}", num3, num2, num4);
				this.m_comBtnExchange.SetEnable(false);
			}
			else
			{
				this.m_labExchangeCD.gameObject.SetActive(false);
				this.m_comBtnExchange.SetEnable(true);
				Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_delayCallUnit);
				this._UpdateExchangeRedPoint();
				DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
			}
		}

		// Token: 0x0600E177 RID: 57719 RVA: 0x0039D71A File Offset: 0x0039BB1A
		private void _UpdateExchangeRedPoint()
		{
			this.m_objRedPoint.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildExchange));
		}

		// Token: 0x0600E178 RID: 57720 RVA: 0x0039D734 File Offset: 0x0039BB34
		private int _GetTicketDonateRemainTimes()
		{
			int num = (int)Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.GUILD_TICKET_DONATE_DAILY);
			int count = DataManager<CountDataManager>.GetInstance().GetCount("guild_donate_point");
			int num2 = num - count;
			if (num2 < 0)
			{
				num2 = 0;
			}
			return num2;
		}

		// Token: 0x0600E179 RID: 57721 RVA: 0x0039D768 File Offset: 0x0039BB68
		private int _GetGoldDonateRemainTimes()
		{
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(135, string.Empty, string.Empty).Value;
			int count = DataManager<CountDataManager>.GetInstance().GetCount("guild_donate_gold");
			int num = value - count;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E17A RID: 57722 RVA: 0x0039D7B4 File Offset: 0x0039BBB4
		private int _GetExchangeRemainTimes()
		{
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(122, string.Empty, string.Empty).Value;
			int count = DataManager<CountDataManager>.GetInstance().GetCount("guild_exchange");
			int num = value - count;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E17B RID: 57723 RVA: 0x0039D7FB File Offset: 0x0039BBFB
		private int _GetTicketDonateMaxTimes()
		{
			return (int)Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.GUILD_TICKET_DONATE_DAILY);
		}

		// Token: 0x0600E17C RID: 57724 RVA: 0x0039D805 File Offset: 0x0039BC05
		private int _GetGoldDonateMaxTimes()
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(135, string.Empty, string.Empty).Value;
		}

		// Token: 0x0600E17D RID: 57725 RVA: 0x0039D825 File Offset: 0x0039BC25
		private int _GetExchangeMaxTimes()
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(122, string.Empty, string.Empty).Value;
		}

		// Token: 0x0600E17E RID: 57726 RVA: 0x0039D844 File Offset: 0x0039BC44
		private void _OnRecordListUpdate(UIEvent a_event)
		{
			List<GuildDonateData> list = a_event.Param1 as List<GuildDonateData>;
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.m_objRecordTemplate);
				gameObject.transform.SetParent(this.m_objRecordRoot.transform, false);
				gameObject.SetActive(true);
				GuildDonateData guildDonateData = list[i];
				Text component = gameObject.GetComponent<Text>();
				component.text = TR.Value("guild_donate_record", guildDonateData.strName, guildDonateData.nTimes, guildDonateData.nFund);
			}
		}

		// Token: 0x0600E17F RID: 57727 RVA: 0x0039D8DC File Offset: 0x0039BCDC
		private void _OnDonateSuccess(UIEvent a_event)
		{
			GuildDonateData guildDonateData = a_event.Param1 as GuildDonateData;
			if (guildDonateData != null)
			{
				GameObject gameObject;
				if (this.m_objRecordRoot.transform.childCount >= 12)
				{
					gameObject = this.m_objRecordRoot.transform.GetChild(1).gameObject;
					gameObject.transform.SetAsLastSibling();
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objRecordTemplate);
					gameObject.transform.SetParent(this.m_objRecordRoot.transform, false);
					gameObject.SetActive(true);
				}
				Text component = gameObject.GetComponent<Text>();
				component.text = TR.Value("guild_donate_record", guildDonateData.strName, guildDonateData.nTimes, guildDonateData.nFund);
				if (guildDonateData.eType == GuildDonateType.GOLD)
				{
					this.m_labDonateGoldRemainTimes.text = TR.Value("guild_remain_times", this._GetGoldDonateRemainTimes(), this._GetGoldDonateMaxTimes());
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_donate_gold_success", guildDonateData.nTimes, guildDonateData.nFund), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					this.m_labDonateTicketRemainTimes.text = TR.Value("guild_remain_times", this._GetTicketDonateRemainTimes(), this._GetTicketDonateMaxTimes());
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_donate_ticket_success", guildDonateData.nTimes, guildDonateData.nFund), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
			}
		}

		// Token: 0x0600E180 RID: 57728 RVA: 0x0039DA4C File Offset: 0x0039BE4C
		private void _OnExchangeSuccess(UIEvent a_event)
		{
			this.m_labExchangeRemainTimes.text = TR.Value("guild_remain_times", this._GetExchangeRemainTimes(), this._GetExchangeMaxTimes());
			this._UpdateExchangeCD();
			this._UpdateExchangeRedPoint();
			this._TryStartExchangeCDCounter();
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
		}

		// Token: 0x0600E181 RID: 57729 RVA: 0x0039DAA1 File Offset: 0x0039BEA1
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildWelfareFrame>(this, false);
		}

		// Token: 0x0600E182 RID: 57730 RVA: 0x0039DAB0 File Offset: 0x0039BEB0
		private void _OnBuildingUpgradeSuccess(UIEvent a_event)
		{
			this._UpdateExchangeItem();
		}

		// Token: 0x0600E183 RID: 57731 RVA: 0x0039DAB8 File Offset: 0x0039BEB8
		[UIEventHandle("DonateWithTicket/Times/Decrease")]
		private void _OnTicketTimesDecreaseClicked()
		{
			int num = this._GetTicketDonateRemainTimes();
			this.m_nSelectTicketTimes--;
			if (this.m_nSelectTicketTimes < 0)
			{
				this.m_nSelectTicketTimes = 0;
			}
			int num2 = this.m_nSelectTicketTimes * 5;
			if (num2 < 1)
			{
				num2 = 1;
			}
			if (num2 > num)
			{
				num2 = num;
			}
			this.m_labDonateTicketTimes.text = num2.ToString();
			if (num2 > 0)
			{
				this.m_labDonateTicketGet.text = (DataManager<GuildDataManager>.GetInstance().donatePointGet * num2).ToString();
				this.m_labDonateTicketCostCount.text = (DataManager<GuildDataManager>.GetInstance().donatePointCost * num2).ToString();
			}
		}

		// Token: 0x0600E184 RID: 57732 RVA: 0x0039DB74 File Offset: 0x0039BF74
		[UIEventHandle("DonateWithTicket/Times/Increase")]
		private void _OnTicketTimesIncreaseClicked()
		{
			int num = this._GetTicketDonateRemainTimes();
			int num2 = num / 5;
			if (num % 5 > 0)
			{
				num2++;
			}
			this.m_nSelectTicketTimes++;
			if (this.m_nSelectTicketTimes > num2)
			{
				this.m_nSelectTicketTimes = num2;
			}
			int num3 = this.m_nSelectTicketTimes * 5;
			if (num3 < 1)
			{
				num3 = 1;
			}
			if (num3 > num)
			{
				num3 = num;
			}
			this.m_labDonateTicketTimes.text = num3.ToString();
			if (num3 > 0)
			{
				this.m_labDonateTicketGet.text = (DataManager<GuildDataManager>.GetInstance().donatePointGet * num3).ToString();
				this.m_labDonateTicketCostCount.text = (DataManager<GuildDataManager>.GetInstance().donatePointCost * num3).ToString();
			}
		}

		// Token: 0x0600E185 RID: 57733 RVA: 0x0039DC40 File Offset: 0x0039C040
		[UIEventHandle("DonateWithGold/Times/Decrease")]
		private void _OnGoldTimesDecreaseClicked()
		{
			int num = this._GetGoldDonateRemainTimes();
			this.m_nSelectGoldTimes--;
			if (this.m_nSelectGoldTimes < 0)
			{
				this.m_nSelectGoldTimes = 0;
			}
			int num2 = this.m_nSelectGoldTimes * 5;
			if (num2 < 1)
			{
				num2 = 1;
			}
			if (num2 > num)
			{
				num2 = num;
			}
			this.m_labDonateGoldTimes.text = num2.ToString();
			if (num2 > 0)
			{
				this.m_labDonateGoldGet.text = (DataManager<GuildDataManager>.GetInstance().donateGoldGet * num2).ToString();
				this.m_labDonateGoldCostCount.text = (DataManager<GuildDataManager>.GetInstance().donateGoldCost * num2).ToString();
			}
		}

		// Token: 0x0600E186 RID: 57734 RVA: 0x0039DCFC File Offset: 0x0039C0FC
		[UIEventHandle("DonateWithGold/Times/Increase")]
		private void _OnGoldTimesIncreaseClicked()
		{
			int num = this._GetGoldDonateRemainTimes();
			int num2 = num / 5;
			if (num % 5 > 0)
			{
				num2++;
			}
			this.m_nSelectGoldTimes++;
			if (this.m_nSelectGoldTimes > num2)
			{
				this.m_nSelectGoldTimes = num2;
			}
			int num3 = this.m_nSelectGoldTimes * 5;
			if (num3 < 1)
			{
				num3 = 1;
			}
			if (num3 > num)
			{
				num3 = num;
			}
			this.m_labDonateGoldTimes.text = num3.ToString();
			if (num3 > 0)
			{
				this.m_labDonateGoldGet.text = (DataManager<GuildDataManager>.GetInstance().donateGoldGet * num3).ToString();
				this.m_labDonateGoldCostCount.text = (DataManager<GuildDataManager>.GetInstance().donateGoldCost * num3).ToString();
			}
		}

		// Token: 0x0600E187 RID: 57735 RVA: 0x0039DDC8 File Offset: 0x0039C1C8
		[UIEventHandle("DonateWithGold/Donate")]
		private void _OnDonateWithGold()
		{
			int num = this._GetGoldDonateRemainTimes();
			int nTimes = int.Parse(this.m_labDonateGoldTimes.text);
			if (nTimes > 0 && nTimes <= num)
			{
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
				costInfo.nCount = DataManager<GuildDataManager>.GetInstance().donateGoldCost * nTimes;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
				{
					DataManager<GuildDataManager>.GetInstance().Donate(GuildDonateType.GOLD, nTimes);
				}, "common_money_cost", null);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_donate_times_invalid"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600E188 RID: 57736 RVA: 0x0039DE74 File Offset: 0x0039C274
		[UIEventHandle("DonateWithTicket/Donate")]
		private void _OnDonateWithTicket()
		{
			int num = this._GetTicketDonateRemainTimes();
			int nTimes = int.Parse(this.m_labDonateTicketTimes.text);
			if (nTimes > 0 && nTimes <= num)
			{
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
				costInfo.nCount = DataManager<GuildDataManager>.GetInstance().donatePointCost * nTimes;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
				{
					DataManager<GuildDataManager>.GetInstance().Donate(GuildDonateType.POINT, nTimes);
				}, "common_money_cost", null);
			}
			else
			{
				SystemNotifyManager.SystemNotify(1000049, delegate()
				{
					VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
					vipFrame.OpenPayTab();
				});
			}
		}

		// Token: 0x0600E189 RID: 57737 RVA: 0x0039DF34 File Offset: 0x0039C334
		[UIEventHandle("Exchange/Doit")]
		private void _OnExchangeClicked()
		{
			if (this._GetExchangeRemainTimes() > 0)
			{
				if (DataManager<PlayerBaseData>.GetInstance().guildContribution < DataManager<GuildDataManager>.GetInstance().exchangeCost)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_less_contribution"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					DataManager<GuildDataManager>.GetInstance().Exchange();
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_less_exchange_times"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x04008630 RID: 34352
		[UIObject("Record/Content")]
		private GameObject m_objRecordRoot;

		// Token: 0x04008631 RID: 34353
		[UIObject("Record/Content/Template")]
		private GameObject m_objRecordTemplate;

		// Token: 0x04008632 RID: 34354
		[UIControl("DonateWithTicket/Contribution/Count", null, 0)]
		private Text m_labDonateTicketGet;

		// Token: 0x04008633 RID: 34355
		[UIControl("DonateWithTicket/Cost/Item/Count", null, 0)]
		private Text m_labDonateTicketCostCount;

		// Token: 0x04008634 RID: 34356
		[UIControl("DonateWithTicket/Cost/Item/Icon", null, 0)]
		private Image m_imgDonateTicketCostIcon;

		// Token: 0x04008635 RID: 34357
		[UIControl("DonateWithTicket/Times/Image/Text", null, 0)]
		private Text m_labDonateTicketTimes;

		// Token: 0x04008636 RID: 34358
		[UIControl("DonateWithTicket/Donate/Remain", null, 0)]
		private Text m_labDonateTicketRemainTimes;

		// Token: 0x04008637 RID: 34359
		[UIControl("DonateWithGold/Contribution/Count", null, 0)]
		private Text m_labDonateGoldGet;

		// Token: 0x04008638 RID: 34360
		[UIControl("DonateWithGold/Cost/Item/Count", null, 0)]
		private Text m_labDonateGoldCostCount;

		// Token: 0x04008639 RID: 34361
		[UIControl("DonateWithGold/Cost/Item/Icon", null, 0)]
		private Image m_imgDonateGoldCostIcon;

		// Token: 0x0400863A RID: 34362
		[UIControl("DonateWithGold/Times/Image/Text", null, 0)]
		private Text m_labDonateGoldTimes;

		// Token: 0x0400863B RID: 34363
		[UIControl("DonateWithGold/Donate/Remain", null, 0)]
		private Text m_labDonateGoldRemainTimes;

		// Token: 0x0400863C RID: 34364
		[UIControl("Exchange/Remain", null, 0)]
		private Text m_labExchangeRemainTimes;

		// Token: 0x0400863D RID: 34365
		[UIObject("Exchange/Item")]
		private GameObject m_objExchangeItemRoot;

		// Token: 0x0400863E RID: 34366
		[UIControl("Exchange/ItemName", null, 0)]
		private Text m_labExchangeItemName;

		// Token: 0x0400863F RID: 34367
		[UIControl("Exchange/Doit/CostDesc/Icon", null, 0)]
		private Image m_imgExchangeCostIcon;

		// Token: 0x04008640 RID: 34368
		[UIControl("Exchange/Doit/CostDesc/Count", null, 0)]
		private Text m_imgExchangeCostCount;

		// Token: 0x04008641 RID: 34369
		[UIControl("Exchange/Title/CD", null, 0)]
		private Text m_labExchangeCD;

		// Token: 0x04008642 RID: 34370
		[UIControl("Exchange/Doit", null, 0)]
		private ComButtonEnbale m_comBtnExchange;

		// Token: 0x04008643 RID: 34371
		[UIObject("Exchange/Doit/RedPoint")]
		private GameObject m_objRedPoint;

		// Token: 0x04008644 RID: 34372
		private int m_nSelectGoldTimes;

		// Token: 0x04008645 RID: 34373
		private int m_nSelectTicketTimes;

		// Token: 0x04008646 RID: 34374
		private DelayCallUnitHandle m_delayCallUnit;
	}
}
