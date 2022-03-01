using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C8B RID: 7307
	public class TeamDuplicationFightStageGoalControl : MonoBehaviour
	{
		// Token: 0x06011EA7 RID: 73383 RVA: 0x0053D91C File Offset: 0x0053BD1C
		public void Init(List<ComControlData> goalItemDataModelList)
		{
			if (goalItemDataModelList == null || goalItemDataModelList.Count <= 0)
			{
				return;
			}
			int num = 0;
			while (num < goalItemDataModelList.Count && num < this.fightStageGoalItemList.Count)
			{
				ComControlData comControlData = goalItemDataModelList[num];
				TeamDuplicationFightStageGoalItem teamDuplicationFightStageGoalItem = this.fightStageGoalItemList[num];
				if (comControlData != null && teamDuplicationFightStageGoalItem != null)
				{
					CommonUtility.UpdateGameObjectVisible(teamDuplicationFightStageGoalItem.gameObject, true);
					teamDuplicationFightStageGoalItem.Init(comControlData);
				}
				num++;
			}
			for (int i = num; i < this.fightStageGoalItemList.Count; i++)
			{
				TeamDuplicationFightStageGoalItem teamDuplicationFightStageGoalItem2 = this.fightStageGoalItemList[i];
				if (teamDuplicationFightStageGoalItem2 != null)
				{
					teamDuplicationFightStageGoalItem2.Init(null);
					CommonUtility.UpdateGameObjectVisible(teamDuplicationFightStageGoalItem2.gameObject, false);
				}
			}
		}

		// Token: 0x06011EA8 RID: 73384 RVA: 0x0053D9EC File Offset: 0x0053BDEC
		public void UpdateFightStageGoalView()
		{
			for (int i = 0; i < this.fightStageGoalItemList.Count; i++)
			{
				TeamDuplicationFightStageGoalItem teamDuplicationFightStageGoalItem = this.fightStageGoalItemList[i];
				if (!(teamDuplicationFightStageGoalItem == null))
				{
					if (teamDuplicationFightStageGoalItem.gameObject.activeSelf)
					{
						if (teamDuplicationFightStageGoalItem.IsFightStageGoalItem())
						{
							teamDuplicationFightStageGoalItem.UpdateGoalContent(0);
						}
					}
				}
			}
		}

		// Token: 0x06011EA9 RID: 73385 RVA: 0x0053DA60 File Offset: 0x0053BE60
		public void UpdateFightStageFightPointDescriptionView(TeamDuplicationFightPointDataModel selectedFightPointDataModel)
		{
			for (int i = 0; i < this.fightStageGoalItemList.Count; i++)
			{
				TeamDuplicationFightStageGoalItem teamDuplicationFightStageGoalItem = this.fightStageGoalItemList[i];
				if (!(teamDuplicationFightStageGoalItem == null))
				{
					if (teamDuplicationFightStageGoalItem.gameObject.activeSelf)
					{
						if (teamDuplicationFightStageGoalItem.IsFightPointItem())
						{
							teamDuplicationFightStageGoalItem.UpdateGoalContent(selectedFightPointDataModel.FightPointId);
						}
					}
				}
			}
		}

		// Token: 0x0400BABD RID: 47805
		[SerializeField]
		private List<TeamDuplicationFightStageGoalItem> fightStageGoalItemList = new List<TeamDuplicationFightStageGoalItem>();
	}
}
