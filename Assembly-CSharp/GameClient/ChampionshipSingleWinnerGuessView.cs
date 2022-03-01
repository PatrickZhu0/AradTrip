using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014FE RID: 5374
	public class ChampionshipSingleWinnerGuessView : MonoBehaviour
	{
		// Token: 0x0600D095 RID: 53397 RVA: 0x00337CE1 File Offset: 0x003360E1
		private void Awake()
		{
		}

		// Token: 0x0600D096 RID: 53398 RVA: 0x00337CE3 File Offset: 0x003360E3
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D097 RID: 53399 RVA: 0x00337CEB File Offset: 0x003360EB
		private void ClearData()
		{
			this._scheduleId = 0;
			this._comControlDataExList = null;
			this._guessProjectDataModel = null;
		}

		// Token: 0x0600D098 RID: 53400 RVA: 0x00337D02 File Offset: 0x00336102
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipGuessProjectResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGuessProjectResMessage));
		}

		// Token: 0x0600D099 RID: 53401 RVA: 0x00337D1F File Offset: 0x0033611F
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipGuessProjectResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGuessProjectResMessage));
		}

		// Token: 0x0600D09A RID: 53402 RVA: 0x00337D3C File Offset: 0x0033613C
		public void InitView()
		{
			this._scheduleId = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId;
			this._comControlDataExList = ChampionshipUtility.GetComControlDataExInTopScheduleTable(ref this._scheduleId);
			this.InitContent();
		}

		// Token: 0x0600D09B RID: 53403 RVA: 0x00337D68 File Offset: 0x00336168
		private void InitContent()
		{
			if (this.comToggleControlEx != null)
			{
				this.comToggleControlEx.InitComToggleControlEx(this._comControlDataExList, new OnComToggleItemExClick(this.OnTabClickAction), new OnComToggleItemExButtonClick(this.OnButtonClickAction));
			}
			this.UpdateContent();
		}

		// Token: 0x0600D09C RID: 53404 RVA: 0x00337DB5 File Offset: 0x003361B5
		public void OnEnableView()
		{
			this.UpdateContent();
		}

		// Token: 0x0600D09D RID: 53405 RVA: 0x00337DBD File Offset: 0x003361BD
		private void OnReceiveChampionshipGuessProjectResMessage(UIEvent uiEvent)
		{
			this.UpdateContent();
		}

		// Token: 0x0600D09E RID: 53406 RVA: 0x00337DC5 File Offset: 0x003361C5
		private void OnTabClickAction(ComControlDataEx comControlDataEx)
		{
			if (comControlDataEx == null)
			{
				return;
			}
			if (comControlDataEx.Id == this._scheduleId)
			{
				return;
			}
			this._scheduleId = comControlDataEx.Id;
			this.UpdateContent();
		}

		// Token: 0x0600D09F RID: 53407 RVA: 0x00337DF4 File Offset: 0x003361F4
		private void OnButtonClickAction(ComControlDataEx comControlDataEx)
		{
			if (comControlDataEx == null)
			{
				return;
			}
			ChampionshipScheduleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(comControlDataEx.Id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string msgContent = TR.Value("Championship_Fight_Schedule_Not_Open", tableItem.ScheduleName);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600D0A0 RID: 53408 RVA: 0x00337E43 File Offset: 0x00336243
		private void UpdateContent()
		{
			this._guessProjectDataModel = ChampionshipUtility.GetChampionshipGuessProjectDataModelByProjectType(GambleType.GT_1V1, this._scheduleId);
			if (this.guessControl != null)
			{
				this.guessControl.InitControl(this._guessProjectDataModel);
			}
		}

		// Token: 0x04007A21 RID: 31265
		private int _scheduleId;

		// Token: 0x04007A22 RID: 31266
		private ChampionshipGuessProjectDataModel _guessProjectDataModel;

		// Token: 0x04007A23 RID: 31267
		private List<ComControlDataEx> _comControlDataExList;

		// Token: 0x04007A24 RID: 31268
		[Space(10f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipSingleWinnerGuessControl guessControl;

		// Token: 0x04007A25 RID: 31269
		[Space(10f)]
		[Header("ScheduleItemList")]
		[Space(10f)]
		[SerializeField]
		private ComToggleControlEx comToggleControlEx;
	}
}
