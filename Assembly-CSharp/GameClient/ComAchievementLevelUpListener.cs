using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013D4 RID: 5076
	public class ComAchievementLevelUpListener : MonoBehaviour
	{
		// Token: 0x0600C4C3 RID: 50371 RVA: 0x002F4227 File Offset: 0x002F2627
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementScoreChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementScoreChanged));
		}

		// Token: 0x0600C4C4 RID: 50372 RVA: 0x002F4244 File Offset: 0x002F2644
		private void _OnAchievementScoreChanged(UIEvent uiEvent)
		{
			int num = (int)uiEvent.Param1;
			int num2 = (int)uiEvent.Param2;
			if (num2 > num && num > 0)
			{
				AchievementLevelInfoTable achievementLevelByPoint = DataManager<AchievementGroupDataManager>.GetInstance().GetAchievementLevelByPoint(num);
				AchievementLevelInfoTable achievementLevelByPoint2 = DataManager<AchievementGroupDataManager>.GetInstance().GetAchievementLevelByPoint(num2);
				if (achievementLevelByPoint != null && achievementLevelByPoint2 != null && achievementLevelByPoint.ID != achievementLevelByPoint2.ID && achievementLevelByPoint2.Level > achievementLevelByPoint.Level)
				{
					AchievementLevelUpPlayFrame.CommandOpen(new AchievementLevelUpPlayFrameData
					{
						iId = achievementLevelByPoint2.ID
					});
				}
			}
		}

		// Token: 0x0600C4C5 RID: 50373 RVA: 0x002F42D8 File Offset: 0x002F26D8
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementScoreChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementScoreChanged));
		}
	}
}
