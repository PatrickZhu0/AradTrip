using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014EF RID: 5359
	public class ChampionshipFightRaceItem : MonoBehaviour
	{
		// Token: 0x0600CFF7 RID: 53239 RVA: 0x003350DE File Offset: 0x003334DE
		private void Awake()
		{
		}

		// Token: 0x0600CFF8 RID: 53240 RVA: 0x003350E0 File Offset: 0x003334E0
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600CFF9 RID: 53241 RVA: 0x003350E8 File Offset: 0x003334E8
		private void ClearData()
		{
			this._fightGroupId = 0;
			this._fightRaceDataModel = null;
			this._firstPlayerDataModel = null;
			this._secondPlayerDataModel = null;
		}

		// Token: 0x0600CFFA RID: 53242 RVA: 0x00335106 File Offset: 0x00333506
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceSyncGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceSyncGroupMessage));
		}

		// Token: 0x0600CFFB RID: 53243 RVA: 0x00335123 File Offset: 0x00333523
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceSyncGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceSyncGroupMessage));
		}

		// Token: 0x0600CFFC RID: 53244 RVA: 0x00335140 File Offset: 0x00333540
		public void Init(ChampionshipFightRaceDataModel fightRaceDataModel)
		{
			this._fightRaceDataModel = fightRaceDataModel;
			if (this._fightRaceDataModel == null)
			{
				return;
			}
			this._fightGroupId = this._fightRaceDataModel.FightGroupId;
			this._firstPlayerDataModel = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._fightRaceDataModel.FirstPlayerGuid);
			this._secondPlayerDataModel = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._fightRaceDataModel.SecondPlayerGuid);
			this.InitView();
		}

		// Token: 0x0600CFFD RID: 53245 RVA: 0x003351A4 File Offset: 0x003335A4
		private void InitView()
		{
			if (this.firstPlayerItem != null)
			{
				if (this._firstPlayerDataModel == null)
				{
					CommonUtility.UpdateGameObjectVisible(this.firstPlayerItem.gameObject, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.firstPlayerItem.gameObject, true);
					this.firstPlayerItem.Init(this._firstPlayerDataModel);
				}
			}
			if (this.secondPlayerItem != null)
			{
				if (this._secondPlayerDataModel == null)
				{
					CommonUtility.UpdateGameObjectVisible(this.secondPlayerItem.gameObject, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.secondPlayerItem.gameObject, true);
					this.secondPlayerItem.Init(this._secondPlayerDataModel);
				}
			}
			this.UpdateFightRaceStatus();
		}

		// Token: 0x0600CFFE RID: 53246 RVA: 0x0033525F File Offset: 0x0033365F
		private void UpdateFightRaceStatus()
		{
			if (this.fightRaceStatusControl != null)
			{
				this.fightRaceStatusControl.Init(this._fightRaceDataModel);
			}
			this.UpdateFightRaceItemBg();
		}

		// Token: 0x0600CFFF RID: 53247 RVA: 0x0033528C File Offset: 0x0033368C
		private void UpdateFightRaceItemBg()
		{
			CommonUtility.UpdateGameObjectVisible(this.commonBg, true);
			CommonUtility.UpdateGameObjectVisible(this.specialBg, false);
			if (this._fightRaceDataModel == null)
			{
				return;
			}
			if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.BeFighting)
			{
				CommonUtility.UpdateGameObjectVisible(this.commonBg, false);
				CommonUtility.UpdateGameObjectVisible(this.specialBg, true);
			}
		}

		// Token: 0x0600D000 RID: 53248 RVA: 0x003352E8 File Offset: 0x003336E8
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
			this.UpdateFightRaceStatus();
		}

		// Token: 0x0600D001 RID: 53249 RVA: 0x00335332 File Offset: 0x00333732
		public void OnItemRecycle()
		{
			this.ClearData();
		}

		// Token: 0x040079AA RID: 31146
		private int _fightGroupId;

		// Token: 0x040079AB RID: 31147
		private ChampionshipFightRaceDataModel _fightRaceDataModel;

		// Token: 0x040079AC RID: 31148
		private ChampionshipTopPlayerDataModel _firstPlayerDataModel;

		// Token: 0x040079AD RID: 31149
		private ChampionshipTopPlayerDataModel _secondPlayerDataModel;

		// Token: 0x040079AE RID: 31150
		[Space(10f)]
		[Header("Bg")]
		[Space(10f)]
		[SerializeField]
		private GameObject commonBg;

		// Token: 0x040079AF RID: 31151
		[SerializeField]
		private GameObject specialBg;

		// Token: 0x040079B0 RID: 31152
		[Space(10f)]
		[Header("PlayerItem")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem firstPlayerItem;

		// Token: 0x040079B1 RID: 31153
		[SerializeField]
		private ChampionshipPlayerItem secondPlayerItem;

		// Token: 0x040079B2 RID: 31154
		[Space(10f)]
		[Header("FightButton")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipFightRaceStatusControl fightRaceStatusControl;
	}
}
