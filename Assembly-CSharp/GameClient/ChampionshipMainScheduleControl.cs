using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200150B RID: 5387
	public class ChampionshipMainScheduleControl : MonoBehaviour
	{
		// Token: 0x0600D13B RID: 53563 RVA: 0x0033A0E0 File Offset: 0x003384E0
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D13C RID: 53564 RVA: 0x0033A0E8 File Offset: 0x003384E8
		private void ClearData()
		{
			this._scheduleTable = null;
			this._scheduleKnockOutView = null;
			this._scheduleScoreView = null;
			this._scheduleSeaView = null;
		}

		// Token: 0x0600D13D RID: 53565 RVA: 0x0033A106 File Offset: 0x00338506
		public void InitControl(ChampionshipScheduleTable scheduleTable)
		{
			if (scheduleTable == null)
			{
				return;
			}
			this._scheduleTable = scheduleTable;
			this.UpdateControl();
		}

		// Token: 0x0600D13E RID: 53566 RVA: 0x0033A11C File Offset: 0x0033851C
		private void UpdateControl()
		{
			this.ResetMainScheduleControl();
			ChampionshipScheduleTable.eScheduleType scheduleType = this._scheduleTable.ScheduleType;
			if (scheduleType == ChampionshipScheduleTable.eScheduleType.None || scheduleType == ChampionshipScheduleTable.eScheduleType.SignUp)
			{
				return;
			}
			if (!DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenInTime)
			{
				return;
			}
			if (scheduleType == ChampionshipScheduleTable.eScheduleType.Sea_Select)
			{
				CommonUtility.UpdateGameObjectVisible(this.scheduleSeaRoot, true);
				if (this._scheduleSeaView == null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.scheduleSeaRoot);
					if (gameObject != null)
					{
						this._scheduleSeaView = gameObject.GetComponent<ChampionshipMainScheduleSeaView>();
					}
				}
				if (this._scheduleSeaView != null)
				{
					this._scheduleSeaView.InitView(this._scheduleTable);
				}
			}
			else if (scheduleType == ChampionshipScheduleTable.eScheduleType.ReSea_Select || scheduleType == ChampionshipScheduleTable.eScheduleType.SixtyFour_Select || scheduleType == ChampionshipScheduleTable.eScheduleType.Sixteen_Select)
			{
				CommonUtility.UpdateGameObjectVisible(this.scheduleScoreRoot, true);
				if (this._scheduleScoreView == null)
				{
					GameObject gameObject2 = CommonUtility.LoadGameObject(this.scheduleScoreRoot);
					if (gameObject2 != null)
					{
						this._scheduleScoreView = gameObject2.GetComponent<ChampionshipMainScheduleScoreView>();
					}
				}
				if (this._scheduleScoreView != null)
				{
					this._scheduleScoreView.InitView(this._scheduleTable);
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.scheduleKnockoutRoot, true);
				if (this._scheduleKnockOutView == null)
				{
					GameObject gameObject3 = CommonUtility.LoadGameObject(this.scheduleKnockoutRoot);
					if (gameObject3 != null)
					{
						this._scheduleKnockOutView = gameObject3.GetComponent<ChampionshipMainScheduleKnockOutView>();
					}
				}
				if (this._scheduleKnockOutView != null)
				{
					this._scheduleKnockOutView.InitView(this._scheduleTable);
				}
			}
		}

		// Token: 0x0600D13F RID: 53567 RVA: 0x0033A2A8 File Offset: 0x003386A8
		public void ResetMainScheduleControl()
		{
			CommonUtility.UpdateGameObjectVisible(this.scheduleSeaRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.scheduleScoreRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.scheduleKnockoutRoot, false);
		}

		// Token: 0x04007A7A RID: 31354
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x04007A7B RID: 31355
		private ChampionshipMainScheduleKnockOutView _scheduleKnockOutView;

		// Token: 0x04007A7C RID: 31356
		private ChampionshipMainScheduleScoreView _scheduleScoreView;

		// Token: 0x04007A7D RID: 31357
		private ChampionshipMainScheduleSeaView _scheduleSeaView;

		// Token: 0x04007A7E RID: 31358
		[Space(10f)]
		[Header("Root")]
		[Space(10f)]
		[SerializeField]
		private GameObject scheduleSeaRoot;

		// Token: 0x04007A7F RID: 31359
		[SerializeField]
		private GameObject scheduleScoreRoot;

		// Token: 0x04007A80 RID: 31360
		[SerializeField]
		private GameObject scheduleKnockoutRoot;
	}
}
