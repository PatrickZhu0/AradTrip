using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014EE RID: 5358
	public class ChampionshipFightRaceFinalView : ChampionshipFightBaseView
	{
		// Token: 0x0600CFE9 RID: 53225 RVA: 0x00334EB3 File Offset: 0x003332B3
		protected override void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CFEA RID: 53226 RVA: 0x00334EBB File Offset: 0x003332BB
		protected override void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CFEB RID: 53227 RVA: 0x00334EC9 File Offset: 0x003332C9
		protected override void BindUiEvents()
		{
			base.BindUiEvents();
		}

		// Token: 0x0600CFEC RID: 53228 RVA: 0x00334ED1 File Offset: 0x003332D1
		protected override void UnBindUiEvents()
		{
			base.UnBindUiEvents();
		}

		// Token: 0x0600CFED RID: 53229 RVA: 0x00334ED9 File Offset: 0x003332D9
		protected override void ClearData()
		{
			base.ClearData();
			this._fightGroupId = 0;
			this._fightRaceDataModel = null;
			this._firstPlayerDataModel = null;
			this._secondPlayerDataModel = null;
		}

		// Token: 0x0600CFEE RID: 53230 RVA: 0x00334EFD File Offset: 0x003332FD
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceAllGroupMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceSyncGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceSyncGroupMessage));
		}

		// Token: 0x0600CFEF RID: 53231 RVA: 0x00334F35 File Offset: 0x00333335
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceAllGroupMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceSyncGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceSyncGroupMessage));
		}

		// Token: 0x0600CFF0 RID: 53232 RVA: 0x00334F6D File Offset: 0x0033336D
		public override void UpdateView(ChampionshipScheduleTable scheduleTable)
		{
			base.UpdateView(scheduleTable);
			this.UpdateFinalView();
		}

		// Token: 0x0600CFF1 RID: 53233 RVA: 0x00334F7C File Offset: 0x0033337C
		private void UpdateFinalView()
		{
			if (this._championScheduleTable == null)
			{
				return;
			}
			this._fightRaceDataModel = ChampionshipUtility.GetFinalFightRaceDataModel();
			if (this._fightRaceDataModel == null)
			{
				return;
			}
			this._fightGroupId = this._fightRaceDataModel.FightGroupId;
			this._firstPlayerDataModel = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._fightRaceDataModel.FirstPlayerGuid);
			this._secondPlayerDataModel = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._fightRaceDataModel.SecondPlayerGuid);
			this.UpdatePlayerItem();
			this.UpdateFightRaceStatusControl();
		}

		// Token: 0x0600CFF2 RID: 53234 RVA: 0x00334FF8 File Offset: 0x003333F8
		private void UpdatePlayerItem()
		{
			if (this.firstPlayerItem != null && this._firstPlayerDataModel != null)
			{
				this.firstPlayerItem.Init(this._firstPlayerDataModel);
			}
			if (this.secondPlayerItem != null && this._secondPlayerDataModel != null)
			{
				this.secondPlayerItem.Init(this._secondPlayerDataModel);
			}
		}

		// Token: 0x0600CFF3 RID: 53235 RVA: 0x0033505F File Offset: 0x0033345F
		private void UpdateFightRaceStatusControl()
		{
			if (this.fightRaceStatusControl != null)
			{
				this.fightRaceStatusControl.Init(this._fightRaceDataModel);
			}
		}

		// Token: 0x0600CFF4 RID: 53236 RVA: 0x00335083 File Offset: 0x00333483
		private void OnReceiveChampionshipFightRaceAllGroupMessage(UIEvent uiEvent)
		{
			this.UpdateFinalView();
		}

		// Token: 0x0600CFF5 RID: 53237 RVA: 0x0033508C File Offset: 0x0033348C
		private void OnReceiveChampionshipFightRaceSyncGroupMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (num != this._fightGroupId)
			{
				return;
			}
			if (this._fightRaceDataModel == null)
			{
				return;
			}
			this.UpdateFightRaceStatusControl();
		}

		// Token: 0x040079A3 RID: 31139
		private int _fightGroupId;

		// Token: 0x040079A4 RID: 31140
		private ChampionshipFightRaceDataModel _fightRaceDataModel;

		// Token: 0x040079A5 RID: 31141
		private ChampionshipTopPlayerDataModel _firstPlayerDataModel;

		// Token: 0x040079A6 RID: 31142
		private ChampionshipTopPlayerDataModel _secondPlayerDataModel;

		// Token: 0x040079A7 RID: 31143
		[Space(10f)]
		[Header("FightRaceStatusControl")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipFightRaceStatusControl fightRaceStatusControl;

		// Token: 0x040079A8 RID: 31144
		[Space(10f)]
		[Header("PlayerItem")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem firstPlayerItem;

		// Token: 0x040079A9 RID: 31145
		[SerializeField]
		private ChampionshipPlayerItem secondPlayerItem;
	}
}
