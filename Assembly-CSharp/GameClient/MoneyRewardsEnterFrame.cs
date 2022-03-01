using System;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017EA RID: 6122
	internal class MoneyRewardsEnterFrame : ClientFrame
	{
		// Token: 0x0600F100 RID: 61696 RVA: 0x0040E46E File Offset: 0x0040C86E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MoneyRewards/MoneyRewardsEnterFrame";
		}

		// Token: 0x0600F101 RID: 61697 RVA: 0x0040E475 File Offset: 0x0040C875
		public static void CommandOpen(object argv)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MoneyRewardsEnterFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsEnterFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600F102 RID: 61698 RVA: 0x0040E499 File Offset: 0x0040C899
		public static void OpenLinkFrame(string strParam)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MoneyRewardsEnterFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsEnterFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600F103 RID: 61699 RVA: 0x0040E4C0 File Offset: 0x0040C8C0
		protected override void _OnOpenFrame()
		{
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<MoneyRewardsEnterFrame>(this, false);
			});
			base._AddButton("BtnEnter", new UnityAction(this._OnClickEnter));
			if (null != this.icon_0)
			{
				ETCImageLoader.LoadSprite(ref this.icon_0, DataManager<MoneyRewardsDataManager>.GetInstance().MoneyIcon, true);
			}
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsPoolsMoneyChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsPoolsMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsPlayerCountChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsPlayerCountChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsAwardListChanged, new ClientEventSystem.UIEventHandler(this._OnOnMoneyRewardsAwardListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsSelfResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsSelfResultChanged));
			if (null != this.comSetting)
			{
				this.comSetting.UpdateHint();
			}
			this._UpdateStage();
			this._UpdateMoneyCount();
			this._UpdatePlayerCount();
			this._UpdatePoolMoneys();
			this._UpdateDesc();
			this._UpdateChampAward();
		}

		// Token: 0x0600F104 RID: 61700 RVA: 0x0040E610 File Offset: 0x0040CA10
		private void _OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._UpdateMoneyCount();
		}

		// Token: 0x0600F105 RID: 61701 RVA: 0x0040E618 File Offset: 0x0040CA18
		private void _OnMoneyRewardsPoolsMoneyChanged(UIEvent uiEvent)
		{
			this._UpdatePoolMoneys();
		}

		// Token: 0x0600F106 RID: 61702 RVA: 0x0040E620 File Offset: 0x0040CA20
		private void _OnMoneyRewardsPlayerCountChanged(UIEvent uiEvent)
		{
			this._UpdatePlayerCount();
		}

		// Token: 0x0600F107 RID: 61703 RVA: 0x0040E628 File Offset: 0x0040CA28
		private void _OnMoneyRewardsStatusChanged(UIEvent uiEvent)
		{
			this._UpdateStage();
		}

		// Token: 0x0600F108 RID: 61704 RVA: 0x0040E630 File Offset: 0x0040CA30
		private void _OnOnMoneyRewardsAwardListChanged(UIEvent uiEvent)
		{
			this._UpdateChampAward();
		}

		// Token: 0x0600F109 RID: 61705 RVA: 0x0040E638 File Offset: 0x0040CA38
		private void _OnMoneyRewardsSelfResultChanged(UIEvent uiEvent)
		{
			this._UpdateChampAward();
		}

		// Token: 0x0600F10A RID: 61706 RVA: 0x0040E640 File Offset: 0x0040CA40
		private void _UpdateMoneyCount()
		{
			if (null != this.moneyCount)
			{
				if (DataManager<MoneyRewardsDataManager>.GetInstance().IsMoneyEnough)
				{
					this.moneyCount.text = TR.Value("money_rewards_cost_money_enable", DataManager<MoneyRewardsDataManager>.GetInstance().MoneyCount);
				}
				else
				{
					this.moneyCount.text = TR.Value("money_rewards_cost_money_disable", DataManager<MoneyRewardsDataManager>.GetInstance().MoneyCount);
				}
			}
		}

		// Token: 0x0600F10B RID: 61707 RVA: 0x0040E6BC File Offset: 0x0040CABC
		private void _UpdatePlayerCount()
		{
			if (null != this.playerCount)
			{
				this.playerCount.text = DataManager<MoneyRewardsDataManager>.GetInstance().playerCount.ToString();
			}
		}

		// Token: 0x0600F10C RID: 61708 RVA: 0x0040E6FD File Offset: 0x0040CAFD
		private void _UpdatePoolMoneys()
		{
			if (null != this.poolsMoney)
			{
				this.poolsMoney.RollValue = DataManager<MoneyRewardsDataManager>.GetInstance().moneysInPool;
			}
		}

		// Token: 0x0600F10D RID: 61709 RVA: 0x0040E728 File Offset: 0x0040CB28
		private void _UpdateDesc()
		{
			if (null != this.fixedDesc0)
			{
				this.fixedDesc0.text = TR.Value("money_rewards_fixed_desc0");
			}
			if (null != this.fixedDesc1)
			{
				this.fixedDesc1.text = TR.Value("money_rewards_fixed_desc1");
			}
		}

		// Token: 0x0600F10E RID: 61710 RVA: 0x0040E781 File Offset: 0x0040CB81
		private void _UpdateChampAward()
		{
			if (null != this.comSetting)
			{
				this.comSetting.UpdateChampAwards();
			}
		}

		// Token: 0x0600F10F RID: 61711 RVA: 0x0040E7A0 File Offset: 0x0040CBA0
		private void _UpdateStage()
		{
			if (null != this.comState)
			{
				bool isOpen = DataManager<MoneyRewardsDataManager>.GetInstance().isOpen;
				if (isOpen)
				{
					if (!DataManager<MoneyRewardsDataManager>.GetInstance().bHasParty)
					{
						if (DataManager<MoneyRewardsDataManager>.GetInstance().Status == PremiumLeagueStatus.PLS_ENROLL)
						{
							this.comState.Key = "addparty";
						}
						else
						{
							this.comState.Key = "timeover";
						}
					}
					else
					{
						this.comState.Key = "enter";
					}
				}
				else
				{
					this.comState.Key = "closed";
				}
			}
		}

		// Token: 0x0600F110 RID: 61712 RVA: 0x0040E840 File Offset: 0x0040CC40
		private void _OnClickEnter()
		{
			if (DataManager<MoneyRewardsDataManager>.GetInstance().needLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_add_need_lv", DataManager<MoneyRewardsDataManager>.GetInstance().needLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			if (DataManager<MoneyRewardsDataManager>.GetInstance().bHasParty)
			{
				DataManager<ActivityDungeonDataManager>.GetInstance().mIsLimitActivityRedPoint = false;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshLimitTimeState, null, null, null, null);
				this._onAddParty();
				return;
			}
			if (DataManager<MoneyRewardsDataManager>.GetInstance().Status != PremiumLeagueStatus.PLS_ENROLL)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_addparty_stage_error"), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				return;
			}
			if (!DataManager<MoneyRewardsDataManager>.GetInstance().IsMoneyEnough)
			{
				ItemComeLink.OnLink(DataManager<MoneyRewardsDataManager>.GetInstance().MoneyID, DataManager<MoneyRewardsDataManager>.GetInstance().MoneyCount, true, null, false, false, false, null, string.Empty);
				return;
			}
			SystemNotifyManager.SystemNotify(7023, delegate()
			{
				DataManager<MoneyRewardsDataManager>.GetInstance().SendAddParty(new UnityAction(this._onAddPartyOK));
			}, null, new object[]
			{
				DataManager<MoneyRewardsDataManager>.GetInstance().MoneyCount,
				DataManager<MoneyRewardsDataManager>.GetInstance().MoneyName
			});
		}

		// Token: 0x0600F111 RID: 61713 RVA: 0x0040E96A File Offset: 0x0040CD6A
		private void _onAddPartyOK()
		{
			this._UpdateStage();
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc13"), CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x0600F112 RID: 61714 RVA: 0x0040E982 File Offset: 0x0040CD82
		private void _onAddParty()
		{
			DataManager<MoneyRewardsDataManager>.GetInstance().GotoPvpFight();
			this.frameMgr.CloseFrame<MoneyRewardsEnterFrame>(this, false);
		}

		// Token: 0x0600F113 RID: 61715 RVA: 0x0040E99C File Offset: 0x0040CD9C
		protected override void _OnCloseFrame()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsPoolsMoneyChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsPoolsMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsPlayerCountChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsPlayerCountChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsAwardListChanged, new ClientEventSystem.UIEventHandler(this._OnOnMoneyRewardsAwardListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsSelfResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsSelfResultChanged));
		}

		// Token: 0x04009415 RID: 37909
		[UIControl("PlayerCount", typeof(Text), 0)]
		private Text playerCount;

		// Token: 0x04009416 RID: 37910
		[UIControl("MoneyIcon_0", typeof(Image), 0)]
		private Image icon_0;

		// Token: 0x04009417 RID: 37911
		[UIControl("FixedDesc_0", typeof(Text), 0)]
		private Text fixedDesc0;

		// Token: 0x04009418 RID: 37912
		[UIControl("FixedDesc_1", typeof(Text), 0)]
		private Text fixedDesc1;

		// Token: 0x04009419 RID: 37913
		[UIControl("MoneyCount", typeof(Text), 0)]
		private Text moneyCount;

		// Token: 0x0400941A RID: 37914
		[UIControl("poolsMoney", typeof(ComRollNumber), 0)]
		private ComRollNumber poolsMoney;

		// Token: 0x0400941B RID: 37915
		[UIControl("", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x0400941C RID: 37916
		[UIControl("", typeof(ComMoneyRewardsEnterSetting), 0)]
		private ComMoneyRewardsEnterSetting comSetting;
	}
}
