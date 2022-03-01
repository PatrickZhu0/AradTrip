using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C8C RID: 7308
	public class TeamDuplicationFightStageGoalItem : MonoBehaviour
	{
		// Token: 0x06011EAB RID: 73387 RVA: 0x0053DAE0 File Offset: 0x0053BEE0
		private void Awake()
		{
		}

		// Token: 0x06011EAC RID: 73388 RVA: 0x0053DAE2 File Offset: 0x0053BEE2
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011EAD RID: 73389 RVA: 0x0053DAEA File Offset: 0x0053BEEA
		private void ClearData()
		{
			this._goalItemDataModel = null;
		}

		// Token: 0x06011EAE RID: 73390 RVA: 0x0053DAF3 File Offset: 0x0053BEF3
		public void Init(ComControlData comControlData)
		{
			this._goalItemDataModel = comControlData;
			if (this._goalItemDataModel == null)
			{
				return;
			}
			this.InitGoalItemView();
		}

		// Token: 0x06011EAF RID: 73391 RVA: 0x0053DB0E File Offset: 0x0053BF0E
		private void InitGoalItemView()
		{
			if (this.goalTitleLabel != null)
			{
				this.goalTitleLabel.text = this._goalItemDataModel.Name;
			}
			this.UpdateGoalContent(this._goalItemDataModel.Index);
		}

		// Token: 0x06011EB0 RID: 73392 RVA: 0x0053DB48 File Offset: 0x0053BF48
		public void UpdateGoalContent(int fightPointId = 0)
		{
			if (this.goalContentLabel == null)
			{
				return;
			}
			string text = string.Empty;
			TeamDuplicationFightGoalType id = (TeamDuplicationFightGoalType)this._goalItemDataModel.Id;
			if (id != TeamDuplicationFightGoalType.CaptainGoal)
			{
				if (id != TeamDuplicationFightGoalType.TeamDuplicationGoal)
				{
					if (id == TeamDuplicationFightGoalType.FightPointDescription)
					{
						text = TeamDuplicationFightStageGoalItem.GetFightPointDescription(fightPointId);
					}
				}
				else
				{
					text = TeamDuplicationFightStageGoalItem.GetFightTeamGoalContent();
				}
			}
			else
			{
				text = TeamDuplicationFightStageGoalItem.GetFightCaptainGoalContent();
			}
			this.goalContentLabel.text = text;
		}

		// Token: 0x06011EB1 RID: 73393 RVA: 0x0053DBC1 File Offset: 0x0053BFC1
		public bool IsFightStageGoalItem()
		{
			return this._goalItemDataModel != null && (this._goalItemDataModel.Id == 1 || this._goalItemDataModel.Id == 2);
		}

		// Token: 0x06011EB2 RID: 73394 RVA: 0x0053DBF5 File Offset: 0x0053BFF5
		public bool IsFightPointItem()
		{
			return this._goalItemDataModel != null && this._goalItemDataModel.Id == 3;
		}

		// Token: 0x06011EB3 RID: 73395 RVA: 0x0053DC18 File Offset: 0x0053C018
		public static string GetFightCaptainGoalContent()
		{
			return TeamDuplicationUtility.GetFightGoalDescription(DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainFightGoalDataModel);
		}

		// Token: 0x06011EB4 RID: 73396 RVA: 0x0053DC38 File Offset: 0x0053C038
		public static string GetFightTeamGoalContent()
		{
			return TeamDuplicationUtility.GetFightGoalDescription(DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationTeamFightGoalDataModel);
		}

		// Token: 0x06011EB5 RID: 73397 RVA: 0x0053DC58 File Offset: 0x0053C058
		public static string GetFightPointDescription(int fightPointId)
		{
			TeamCopyFieldTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>(fightPointId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.StrongholdDesc;
			}
			return string.Empty;
		}

		// Token: 0x0400BABE RID: 47806
		private ComControlData _goalItemDataModel;

		// Token: 0x0400BABF RID: 47807
		[Space(10f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Text goalTitleLabel;

		// Token: 0x0400BAC0 RID: 47808
		[SerializeField]
		private Text goalContentLabel;
	}
}
