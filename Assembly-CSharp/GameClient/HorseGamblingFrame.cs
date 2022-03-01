using System;
using Protocol;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001683 RID: 5763
	internal class HorseGamblingFrame : ClientFrame
	{
		// Token: 0x0600E290 RID: 58000 RVA: 0x003A32EC File Offset: 0x003A16EC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/HorseGambling/HorseGamblingFrame";
		}

		// Token: 0x0600E291 RID: 58001 RVA: 0x003A32F4 File Offset: 0x003A16F4
		protected override void _OnOpenFrame()
		{
			this.BindEvents();
			this.mView = this.frame.GetComponent<HorseGamblingView>();
			if (this.mView != null)
			{
				this.mView.Init(DataManager<HorseGamblingDataManager>.GetInstance(), new UnityAction(this.ShowSupply), new UnityAction(this.ShowStakeRecords), new UnityAction(this.ShowGameRecords), new UnityAction(this.ShowShooterRecord), new UnityAction(this.OnClose));
				this.mIsNeedUpdate = true;
				this.mUpdatedelta = 0f;
				DataManager<HorseGamblingDataManager>.GetInstance().RequestData();
				DataManager<HorseGamblingDataManager>.GetInstance().RequestStakeHistory();
				DataManager<HorseGamblingDataManager>.GetInstance().RequestGameHistory();
			}
		}

		// Token: 0x0600E292 RID: 58002 RVA: 0x003A33A5 File Offset: 0x003A17A5
		public override bool IsNeedUpdate()
		{
			return this.mIsNeedUpdate;
		}

		// Token: 0x0600E293 RID: 58003 RVA: 0x003A33B0 File Offset: 0x003A17B0
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.mView != null && DataManager<HorseGamblingDataManager>.GetInstance().State == BetHorsePhaseType.PHASE_TYPE_STAKE)
			{
				this.mUpdatedelta += timeElapsed;
				if (this.mUpdatedelta >= this.mView.RefreshOddsInterval)
				{
					DataManager<HorseGamblingDataManager>.GetInstance().RequestShooterOdds();
					this.mUpdatedelta -= this.mView.RefreshOddsInterval;
				}
			}
		}

		// Token: 0x0600E294 RID: 58004 RVA: 0x003A3424 File Offset: 0x003A1824
		protected override void _OnCloseFrame()
		{
			this.UnBindEvents();
			this.mIsNeedUpdate = false;
			this.mUpdatedelta = 0f;
			if (this.mView != null)
			{
				this.mView.Dispose();
				this.mView = null;
			}
		}

		// Token: 0x0600E295 RID: 58005 RVA: 0x003A3464 File Offset: 0x003A1864
		private void BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingGameStateUpdate, new ClientEventSystem.UIEventHandler(this.OnStateUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingUpdate, new ClientEventSystem.UIEventHandler(this.OnDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingOddsUpdate, new ClientEventSystem.UIEventHandler(this.OnOddsUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingShooterHistoryUpdate, new ClientEventSystem.UIEventHandler(this.OnShooterHistoryUpdate));
		}

		// Token: 0x0600E296 RID: 58006 RVA: 0x003A34E0 File Offset: 0x003A18E0
		private void UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingGameStateUpdate, new ClientEventSystem.UIEventHandler(this.OnStateUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingUpdate, new ClientEventSystem.UIEventHandler(this.OnDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingOddsUpdate, new ClientEventSystem.UIEventHandler(this.OnOddsUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingShooterHistoryUpdate, new ClientEventSystem.UIEventHandler(this.OnShooterHistoryUpdate));
		}

		// Token: 0x0600E297 RID: 58007 RVA: 0x003A3559 File Offset: 0x003A1959
		private void OnClose()
		{
			base.Close(false);
		}

		// Token: 0x0600E298 RID: 58008 RVA: 0x003A3564 File Offset: 0x003A1964
		private void OnStateUpdate(UIEvent data)
		{
			if (this.mView != null && data != null && data.Param1 != null)
			{
				this.mView.UpdateState((BetHorsePhaseType)data.Param1);
			}
			DataManager<HorseGamblingDataManager>.GetInstance().RequestData();
		}

		// Token: 0x0600E299 RID: 58009 RVA: 0x003A35B3 File Offset: 0x003A19B3
		private void OnDataUpdate(UIEvent data)
		{
			if (this.mView != null)
			{
				this.mView.UpdateData(DataManager<HorseGamblingDataManager>.GetInstance());
			}
		}

		// Token: 0x0600E29A RID: 58010 RVA: 0x003A35D6 File Offset: 0x003A19D6
		private void ShowSupply()
		{
			if (this.mView != null)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<HorseGamblingSupplyFrame>(FrameLayer.Middle, this.mView.SelectShooterId, string.Empty);
			}
		}

		// Token: 0x0600E29B RID: 58011 RVA: 0x003A360C File Offset: 0x003A1A0C
		private void ShowStakeRecords()
		{
			HorseGamblingRecordFrameParam horseGamblingRecordFrameParam = new HorseGamblingRecordFrameParam();
			horseGamblingRecordFrameParam.RecordType = EHorseGamblingRecord.Stake;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HorseGamblingRecordFrame>(FrameLayer.Middle, horseGamblingRecordFrameParam, string.Empty);
		}

		// Token: 0x0600E29C RID: 58012 RVA: 0x003A3638 File Offset: 0x003A1A38
		private void ShowGameRecords()
		{
			HorseGamblingRecordFrameParam horseGamblingRecordFrameParam = new HorseGamblingRecordFrameParam();
			horseGamblingRecordFrameParam.RecordType = EHorseGamblingRecord.HistoryAndRank;
			horseGamblingRecordFrameParam.Param = 0;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HorseGamblingRecordFrame>(FrameLayer.Middle, horseGamblingRecordFrameParam, string.Empty);
		}

		// Token: 0x0600E29D RID: 58013 RVA: 0x003A366C File Offset: 0x003A1A6C
		private void ShowShooterRecord()
		{
			if (this.mView != null)
			{
				HorseGamblingRecordFrameParam horseGamblingRecordFrameParam = new HorseGamblingRecordFrameParam();
				horseGamblingRecordFrameParam.RecordType = EHorseGamblingRecord.ShooterHistory;
				horseGamblingRecordFrameParam.Param = this.mView.SelectShooterId;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<HorseGamblingRecordFrame>(FrameLayer.Middle, horseGamblingRecordFrameParam, string.Empty);
			}
		}

		// Token: 0x0600E29E RID: 58014 RVA: 0x003A36BA File Offset: 0x003A1ABA
		private void OnOddsUpdate(UIEvent data)
		{
			if (this.mView != null)
			{
				this.mView.UpdateOdds(DataManager<HorseGamblingDataManager>.GetInstance());
			}
		}

		// Token: 0x0600E29F RID: 58015 RVA: 0x003A36DD File Offset: 0x003A1ADD
		private void OnShooterHistoryUpdate(UIEvent data)
		{
			if (this.mView != null && data != null && data.Param1 != null)
			{
				this.mView.UpdateShooterInfo((IHorseGamblingShooterModel)data.Param1);
			}
		}

		// Token: 0x04008794 RID: 34708
		private HorseGamblingView mView;

		// Token: 0x04008795 RID: 34709
		private bool mIsNeedUpdate;

		// Token: 0x04008796 RID: 34710
		private float mUpdatedelta;
	}
}
