using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015EE RID: 5614
	internal class GuildAttackCityFrame : ClientFrame
	{
		// Token: 0x0600DBD0 RID: 56272 RVA: 0x00376DB3 File Offset: 0x003751B3
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildAttackCityFrame";
		}

		// Token: 0x0600DBD1 RID: 56273 RVA: 0x00376DBC File Offset: 0x003751BC
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.TerritoryID = (int)this.userData;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(261, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.AddedMoneyNum = tableItem.Value;
			}
			this.RegisterUIEvent();
			this.SendAttackGuildReq();
		}

		// Token: 0x0600DBD2 RID: 56274 RVA: 0x00376E1D File Offset: 0x0037521D
		protected override void _OnCloseFrame()
		{
			this.UnRegisterUIEvent();
			this.ClearData();
		}

		// Token: 0x0600DBD3 RID: 56275 RVA: 0x00376E2B File Offset: 0x0037522B
		private void ClearData()
		{
			this.TerritoryID = 0;
			this.AddedMoneyNum = 0;
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallLeftTime);
		}

		// Token: 0x0600DBD4 RID: 56276 RVA: 0x00376E50 File Offset: 0x00375250
		private void RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildAttackCityInfoUpdate, new ClientEventSystem.UIEventHandler(this.UpdateInterface));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this.OnUpdateGuildBattleState));
		}

		// Token: 0x0600DBD5 RID: 56277 RVA: 0x00376E88 File Offset: 0x00375288
		private void UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildAttackCityInfoUpdate, new ClientEventSystem.UIEventHandler(this.UpdateInterface));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this.OnUpdateGuildBattleState));
		}

		// Token: 0x0600DBD6 RID: 56278 RVA: 0x00376EC0 File Offset: 0x003752C0
		private void OnUpdateGuildBattleState(UIEvent iEvent)
		{
			this.UpdateInterface(iEvent);
		}

		// Token: 0x0600DBD7 RID: 56279 RVA: 0x00376ECC File Offset: 0x003752CC
		private void UpdateInterface(UIEvent iEvent)
		{
			GuildAttackCityData attackCityData = DataManager<GuildDataManager>.GetInstance().GetAttackCityData();
			if (attackCityData == null)
			{
				return;
			}
			if (attackCityData.enrollGuildId <= 0UL)
			{
				this.mName.text = "当前尚未有公会进行宣战";
				this.mLevel.text = "0";
				this.mGuildLeader.text = "无";
			}
			else
			{
				this.mName.text = string.Format("【{0}】", attackCityData.enrollGuildName);
				this.mLevel.text = attackCityData.enrollGuildLevel.ToString();
				this.mGuildLeader.text = attackCityData.enrollGuildleaderName;
			}
			this.mBidPrice.text = attackCityData.itemNum.ToString();
			this.mButtonPrice.text = ((long)((ulong)attackCityData.itemNum + (ulong)((long)this.AddedMoneyNum))).ToString();
			this.UpdateSignUp();
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallLeftTime);
			this.m_repeatCallLeftTime = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(1000, delegate
			{
				this._UpdateLeftTime();
			}, 9999999, true);
		}

		// Token: 0x0600DBD8 RID: 56280 RVA: 0x00377000 File Offset: 0x00375400
		private void UpdateSignUp()
		{
			if (!this.CheckCanChallenge(false))
			{
				this.mSignUpGray.enabled = true;
				this.mSignUp.interactable = false;
			}
			else
			{
				this.mSignUpGray.enabled = false;
				this.mSignUp.interactable = true;
			}
		}

		// Token: 0x0600DBD9 RID: 56281 RVA: 0x00377050 File Offset: 0x00375450
		private void _UpdateLeftTime()
		{
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Signup)
			{
				uint num = DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime() - DataManager<TimeManager>.GetInstance().GetServerTime();
				if (num > 0U)
				{
					this.mLeftTime.text = Function.GetLeftTime((int)DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime(), (int)DataManager<TimeManager>.GetInstance().GetServerTime(), ShowtimeType.OnlineGift);
					this.mLeftTime.gameObject.CustomActive(true);
				}
				else
				{
					this.mLeftTime.text = "已结束";
				}
			}
			else
			{
				this.mLeftTime.text = "已结束";
			}
		}

		// Token: 0x0600DBDA RID: 56282 RVA: 0x003770EC File Offset: 0x003754EC
		private bool CheckCanChallenge(bool bNeedTip = false)
		{
			GuildAttackCityData attackCityData = DataManager<GuildDataManager>.GetInstance().GetAttackCityData();
			if (attackCityData == null)
			{
				return false;
			}
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() != GuildBattleType.GBT_CHALLENGE)
			{
				if (bNeedTip)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("当前非攻城战日期,无法发起挑战", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				return false;
			}
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() != EGuildBattleState.Signup)
			{
				if (bNeedTip)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("攻城战报名阶段已结束", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				return false;
			}
			if (!DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.StartGuildAttackCity, EGuildDuty.Invalid))
			{
				if (bNeedTip)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你当前没有权限发起挑战!", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				return false;
			}
			if (attackCityData.info.terrId <= 0)
			{
				if (bNeedTip)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("该领地未被占领,无法发起挑战", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				return false;
			}
			if (DataManager<GuildDataManager>.GetInstance().GetManorOwner(this.TerritoryID) == DataManager<GuildDataManager>.GetInstance().GetMyGuildName())
			{
				if (bNeedTip)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你所在公会已经占领该领地，无需发起挑战!", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600DBDB RID: 56283 RVA: 0x003771DC File Offset: 0x003755DC
		private void SendAttackGuildReq()
		{
			WorldGuildChallengeInfoReq cmd = new WorldGuildChallengeInfoReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildChallengeInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600DBDC RID: 56284 RVA: 0x00377200 File Offset: 0x00375600
		private void SendAttackCityReq()
		{
			GuildAttackCityData attackCityData = DataManager<GuildDataManager>.GetInstance().GetAttackCityData();
			if (attackCityData == null)
			{
				return;
			}
			WorldGuildChallengeReq worldGuildChallengeReq = new WorldGuildChallengeReq();
			worldGuildChallengeReq.terrId = (byte)this.TerritoryID;
			worldGuildChallengeReq.itemId = attackCityData.itemId;
			worldGuildChallengeReq.itemNum = (uint)(this.AddedMoneyNum + (int)attackCityData.itemNum);
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildChallengeReq>(ServerType.GATE_SERVER, worldGuildChallengeReq);
		}

		// Token: 0x0600DBDD RID: 56285 RVA: 0x00377260 File Offset: 0x00375660
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mLevel = this.mBind.GetCom<Text>("Level");
			this.mGuildLeader = this.mBind.GetCom<Text>("GuildLeader");
			this.mBidPrice = this.mBind.GetCom<Text>("BidPrice");
			this.mButtonPrice = this.mBind.GetCom<Text>("ButtonPrice");
			this.mSignUp = this.mBind.GetCom<Button>("SignUp");
			this.mSignUp.onClick.AddListener(new UnityAction(this._onSignUpButtonClick));
			this.mSignUpGray = this.mBind.GetCom<UIGray>("SignUpGray");
			this.mLeftTime = this.mBind.GetCom<Text>("LeftTime");
		}

		// Token: 0x0600DBDE RID: 56286 RVA: 0x00377384 File Offset: 0x00375784
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mTitle = null;
			this.mName = null;
			this.mLevel = null;
			this.mGuildLeader = null;
			this.mBidPrice = null;
			this.mButtonPrice = null;
			this.mSignUp.onClick.RemoveListener(new UnityAction(this._onSignUpButtonClick));
			this.mSignUp = null;
			this.mSignUpGray = null;
			this.mLeftTime = null;
		}

		// Token: 0x0600DBDF RID: 56287 RVA: 0x0037740F File Offset: 0x0037580F
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<GuildAttackCityFrame>(this, false);
		}

		// Token: 0x0600DBE0 RID: 56288 RVA: 0x00377420 File Offset: 0x00375820
		private void _onSignUpButtonClick()
		{
			if (!this.CheckCanChallenge(true))
			{
				return;
			}
			GuildAttackCityData attackCityData = DataManager<GuildDataManager>.GetInstance().GetAttackCityData();
			if (attackCityData == null)
			{
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = (int)attackCityData.itemId;
			costInfo.nCount = this.AddedMoneyNum + (int)attackCityData.itemNum;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				this.SendAttackCityReq();
			}, "common_money_cost", null);
		}

		// Token: 0x04008191 RID: 33169
		private int TerritoryID;

		// Token: 0x04008192 RID: 33170
		private int AddedMoneyNum;

		// Token: 0x04008193 RID: 33171
		private DelayCallUnitHandle m_repeatCallLeftTime;

		// Token: 0x04008194 RID: 33172
		private Button mBtClose;

		// Token: 0x04008195 RID: 33173
		private Text mTitle;

		// Token: 0x04008196 RID: 33174
		private Text mName;

		// Token: 0x04008197 RID: 33175
		private Text mLevel;

		// Token: 0x04008198 RID: 33176
		private Text mGuildLeader;

		// Token: 0x04008199 RID: 33177
		private Text mBidPrice;

		// Token: 0x0400819A RID: 33178
		private Text mButtonPrice;

		// Token: 0x0400819B RID: 33179
		private Button mSignUp;

		// Token: 0x0400819C RID: 33180
		private UIGray mSignUpGray;

		// Token: 0x0400819D RID: 33181
		private Text mLeftTime;
	}
}
