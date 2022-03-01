using System;
using Protocol;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001695 RID: 5781
	internal class HorseGamblingSupplyFrame : ClientFrame
	{
		// Token: 0x0600E30D RID: 58125 RVA: 0x003A569E File Offset: 0x003A3A9E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/HorseGambling/HorseGamblingSupplyFrame";
		}

		// Token: 0x0600E30E RID: 58126 RVA: 0x003A56A8 File Offset: 0x003A3AA8
		protected override void _OnOpenFrame()
		{
			this.mView = this.frame.GetComponent<HorseGamblingSupplyView>();
			if (this.mView != null)
			{
				int num = (int)this.userData;
				this.mShooterId = num;
				BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(num, string.Empty, string.Empty);
				HorseGamblingShooterModel shooterModel = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterModel(this.mShooterId);
				if (shooterModel != null && shooterModel.IsUnknown && DataManager<HorseGamblingDataManager>.GetInstance().State == BetHorsePhaseType.PHASE_TYPE_STAKE)
				{
					tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(0, string.Empty, string.Empty);
				}
				if (tableItem == null)
				{
					return;
				}
				this.mView.Init(tableItem.Name, tableItem.IconPath, DataManager<HorseGamblingDataManager>.GetInstance().GetShooterOdds(num), DataManager<HorseGamblingDataManager>.GetInstance().LeftSupply, new UnityAction(this.OnSupply), new UnityAction(this.OnClose));
			}
			DataManager<HorseGamblingDataManager>.GetInstance().RequestStakeHistory();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingShooterStakeResp, new ClientEventSystem.UIEventHandler(this.OnSupplyResp));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingShooterStakeUpdate, new ClientEventSystem.UIEventHandler(this.OnStakeDataResponse));
		}

		// Token: 0x0600E30F RID: 58127 RVA: 0x003A57D4 File Offset: 0x003A3BD4
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingShooterStakeResp, new ClientEventSystem.UIEventHandler(this.OnSupplyResp));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingShooterStakeUpdate, new ClientEventSystem.UIEventHandler(this.OnStakeDataResponse));
			if (this.mView != null)
			{
				this.mView.Dispose();
				this.mView = null;
			}
		}

		// Token: 0x0600E310 RID: 58128 RVA: 0x003A583A File Offset: 0x003A3C3A
		private void OnClose()
		{
			base.Close(false);
		}

		// Token: 0x0600E311 RID: 58129 RVA: 0x003A5843 File Offset: 0x003A3C43
		private void OnStakeDataResponse(UIEvent uiEvent)
		{
			if (this.mView != null)
			{
				this.mView.UpdateStakeNum(DataManager<HorseGamblingDataManager>.GetInstance().LeftSupply);
			}
		}

		// Token: 0x0600E312 RID: 58130 RVA: 0x003A586C File Offset: 0x003A3C6C
		private void OnSupply()
		{
			if (this.mView != null)
			{
				if (DataManager<HorseGamblingDataManager>.GetInstance().State != BetHorsePhaseType.PHASE_TYPE_STAKE)
				{
					SystemNotifyManager.SystemNotify(9915, string.Empty);
					return;
				}
				if (this.mView.SupplyCount == 0)
				{
					SystemNotifyManager.SystemNotify(9925, string.Empty);
					return;
				}
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mView.BulletId, false);
				if (ownedItemCount == 0 || ownedItemCount < this.mView.SupplyCount)
				{
					SystemNotifyManager.SystemNotify(9928, string.Empty);
					return;
				}
				if (this.mView.SupplyCount > DataManager<HorseGamblingDataManager>.GetInstance().LeftSupply)
				{
					SystemNotifyManager.SystemNotify(9930, string.Empty);
					return;
				}
				this.mView.SetConfirmEnable(false);
				DataManager<HorseGamblingDataManager>.GetInstance().ShooterStake(this.mShooterId, this.mView.SupplyCount);
			}
		}

		// Token: 0x0600E313 RID: 58131 RVA: 0x003A595C File Offset: 0x003A3D5C
		private void OnSupplyResp(UIEvent uiEvent)
		{
			if (uiEvent != null && uiEvent.Param1 != null)
			{
				int num = (int)uiEvent.Param1;
				if (this.mView != null)
				{
					this.mView.SetConfirmEnable(true);
				}
				switch (num)
				{
				case 3800001:
					SystemNotifyManager.SystemNotify(9915, string.Empty);
					break;
				case 3800002:
					SystemNotifyManager.SystemNotify(9916, string.Empty);
					break;
				case 3800003:
					SystemNotifyManager.SystemNotify(9917, string.Empty);
					break;
				case 3800004:
					SystemNotifyManager.SystemNotify(9918, string.Empty);
					break;
				default:
					if (num == 0)
					{
						if (this.mView != null)
						{
							this.mView.SetConfirmEnable(false);
						}
						SystemNotifyManager.SystemNotify(9919, string.Empty);
						base.Close(false);
					}
					break;
				}
			}
		}

		// Token: 0x04008800 RID: 34816
		private HorseGamblingSupplyView mView;

		// Token: 0x04008801 RID: 34817
		private int mShooterId;
	}
}
