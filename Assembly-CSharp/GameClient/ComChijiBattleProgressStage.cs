using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001127 RID: 4391
	public class ComChijiBattleProgressStage : MonoBehaviour
	{
		// Token: 0x0600A6D1 RID: 42705 RVA: 0x0022B8BC File Offset: 0x00229CBC
		private void Start()
		{
			this.bStart = false;
			this._BindUIEvent();
			ChiJiTimeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChiJiTimeTable>((int)this.BattleStage, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.LastTime = tableItem.ProgressTime;
				this.NextStage = (ChiJiTimeTable.eBattleStage)tableItem.NextStage;
			}
			this.fTimeIntrval = 0f;
			if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage == this.BattleStage)
			{
				if (DataManager<ChijiDataManager>.GetInstance().StageStartTimeList != null && this.BattleStage < (ChiJiTimeTable.eBattleStage)DataManager<ChijiDataManager>.GetInstance().StageStartTimeList.Length)
				{
					this.StageStartTime = DataManager<ChijiDataManager>.GetInstance().StageStartTimeList[(int)this.BattleStage];
				}
			}
			else if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage > this.BattleStage && this.NextStage > ChiJiTimeTable.eBattleStage.BS_NONE && DataManager<ChijiDataManager>.GetInstance().CurBattleStage < this.NextStage && DataManager<ChijiDataManager>.GetInstance().StageStartTimeList != null && this.BattleStage < (ChiJiTimeTable.eBattleStage)DataManager<ChijiDataManager>.GetInstance().StageStartTimeList.Length)
			{
				this.StageStartTime = DataManager<ChijiDataManager>.GetInstance().StageStartTimeList[(int)this.BattleStage];
			}
			this._SetSliderValue();
		}

		// Token: 0x0600A6D2 RID: 42706 RVA: 0x0022B9EA File Offset: 0x00229DEA
		private void OnDestroy()
		{
			this._UnBindUIEvent();
			this.BattleStage = ChiJiTimeTable.eBattleStage.BS_NONE;
			this.bStart = false;
			this.StageStartTime = 0U;
			this.fTimeIntrval = 0f;
			this.LastTime = 0;
			this.NextStage = ChiJiTimeTable.eBattleStage.BS_NONE;
		}

		// Token: 0x0600A6D3 RID: 42707 RVA: 0x0022BA20 File Offset: 0x00229E20
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiBattleStageChanged, new ClientEventSystem.UIEventHandler(this._OnStageChanged));
		}

		// Token: 0x0600A6D4 RID: 42708 RVA: 0x0022BA3D File Offset: 0x00229E3D
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiBattleStageChanged, new ClientEventSystem.UIEventHandler(this._OnStageChanged));
		}

		// Token: 0x0600A6D5 RID: 42709 RVA: 0x0022BA5A File Offset: 0x00229E5A
		private void _OnStageChanged(UIEvent iEvent)
		{
			if (this.BattleStage == DataManager<ChijiDataManager>.GetInstance().CurBattleStage)
			{
				this.StageStartTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			}
			this._SetSliderValue();
		}

		// Token: 0x0600A6D6 RID: 42710 RVA: 0x0022BA88 File Offset: 0x00229E88
		private void _SetSliderValue()
		{
			if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage < this.BattleStage)
			{
				this.bStart = false;
				if (this.slider != null)
				{
					this.slider.value = 0f;
				}
			}
			else if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage == this.BattleStage)
			{
				if (this.slider != null)
				{
					uint num = DataManager<TimeManager>.GetInstance().GetServerTime() - this.StageStartTime;
					this.slider.value = num / (float)this.LastTime;
				}
				this.bStart = true;
			}
			else if (this.NextStage > ChiJiTimeTable.eBattleStage.BS_NONE && DataManager<ChijiDataManager>.GetInstance().CurBattleStage < this.NextStage)
			{
				if (this.slider != null)
				{
					uint num2 = DataManager<TimeManager>.GetInstance().GetServerTime() - this.StageStartTime;
					this.slider.value = num2 / (float)this.LastTime;
				}
				this.bStart = true;
			}
			else
			{
				this.bStart = false;
				if (this.slider != null)
				{
					this.slider.value = 1f;
				}
			}
		}

		// Token: 0x0600A6D7 RID: 42711 RVA: 0x0022BBC0 File Offset: 0x00229FC0
		private void Update()
		{
			if (!this.bStart || this.LastTime == 0)
			{
				return;
			}
			this.fTimeIntrval += Time.deltaTime;
			if (this.fTimeIntrval < 0.35f)
			{
				return;
			}
			this.fTimeIntrval = 0f;
			if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage < this.BattleStage)
			{
				return;
			}
			this._SetSliderValue();
			if ((DataManager<ChijiDataManager>.GetInstance().CurBattleStage == this.BattleStage || (this.NextStage > ChiJiTimeTable.eBattleStage.BS_NONE && DataManager<ChijiDataManager>.GetInstance().CurBattleStage < this.NextStage)) && this.ShowTime != null)
			{
				string leftTime = Function.GetLeftTime((int)(this.StageStartTime + (uint)this.LastTime), (int)DataManager<TimeManager>.GetInstance().GetServerTime(), ShowtimeType.OnlineGift);
				this.ShowTime.text = ChijiMainFrame.mStagename + leftTime;
			}
		}

		// Token: 0x04005D59 RID: 23897
		public ChiJiTimeTable.eBattleStage BattleStage;

		// Token: 0x04005D5A RID: 23898
		public Slider slider;

		// Token: 0x04005D5B RID: 23899
		public Text ShowTime;

		// Token: 0x04005D5C RID: 23900
		private bool bStart;

		// Token: 0x04005D5D RID: 23901
		private uint StageStartTime;

		// Token: 0x04005D5E RID: 23902
		private float fTimeIntrval;

		// Token: 0x04005D5F RID: 23903
		private int LastTime;

		// Token: 0x04005D60 RID: 23904
		private ChiJiTimeTable.eBattleStage NextStage;
	}
}
