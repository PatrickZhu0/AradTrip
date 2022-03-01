using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014ED RID: 5357
	public class ChampionshipFightRaceCommonView : ChampionshipFightBaseView
	{
		// Token: 0x0600CFDE RID: 53214 RVA: 0x00334DB7 File Offset: 0x003331B7
		protected override void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CFDF RID: 53215 RVA: 0x00334DBF File Offset: 0x003331BF
		protected override void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CFE0 RID: 53216 RVA: 0x00334DCD File Offset: 0x003331CD
		protected override void BindUiEvents()
		{
			base.BindUiEvents();
		}

		// Token: 0x0600CFE1 RID: 53217 RVA: 0x00334DD5 File Offset: 0x003331D5
		protected override void UnBindUiEvents()
		{
			base.UnBindUiEvents();
		}

		// Token: 0x0600CFE2 RID: 53218 RVA: 0x00334DDD File Offset: 0x003331DD
		protected override void ClearData()
		{
			base.ClearData();
		}

		// Token: 0x0600CFE3 RID: 53219 RVA: 0x00334DE5 File Offset: 0x003331E5
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceAllGroupMessage));
		}

		// Token: 0x0600CFE4 RID: 53220 RVA: 0x00334E02 File Offset: 0x00333202
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceAllGroupMessage));
		}

		// Token: 0x0600CFE5 RID: 53221 RVA: 0x00334E1F File Offset: 0x0033321F
		public override void UpdateView(ChampionshipScheduleTable scheduleTable)
		{
			base.UpdateView(scheduleTable);
			this.UpdateCommonView();
			base.UpdateScheduleTimeInfo();
		}

		// Token: 0x0600CFE6 RID: 53222 RVA: 0x00334E34 File Offset: 0x00333234
		private void UpdateCommonView()
		{
			if (this._championScheduleTable == null)
			{
				return;
			}
			ChampionshipScheduleTable.eScheduleType scheduleType = this._championScheduleTable.ScheduleType;
			List<ChampionshipFightRaceDataModel> leftFightRaceDataModelList = ChampionshipUtility.GetLeftFightRaceDataModelList(scheduleType);
			List<ChampionshipFightRaceDataModel> rightFightRaceDataModelList = ChampionshipUtility.GetRightFightRaceDataModelList(scheduleType);
			if (this.leftFightRaceItemListControl != null)
			{
				this.leftFightRaceItemListControl.UpdateFightRaceItemControl(scheduleType, leftFightRaceDataModelList);
			}
			if (this.rightFightRaceItemListControl != null)
			{
				this.rightFightRaceItemListControl.UpdateFightRaceItemControl(scheduleType, rightFightRaceDataModelList);
			}
		}

		// Token: 0x0600CFE7 RID: 53223 RVA: 0x00334EA3 File Offset: 0x003332A3
		private void OnReceiveChampionshipFightRaceAllGroupMessage(UIEvent uiEvent)
		{
			this.UpdateCommonView();
		}

		// Token: 0x040079A1 RID: 31137
		[Space(10f)]
		[Header("ItemControl")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipFightRaceItemListControl leftFightRaceItemListControl;

		// Token: 0x040079A2 RID: 31138
		[SerializeField]
		private ChampionshipFightRaceItemListControl rightFightRaceItemListControl;
	}
}
