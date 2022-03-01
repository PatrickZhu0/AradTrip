using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200141F RID: 5151
	public class ComAdventureTeamTabRedPointBinder : MonoBehaviour
	{
		// Token: 0x0600C79A RID: 51098 RVA: 0x0030487C File Offset: 0x00302C7C
		private void Awake()
		{
			this.adventureTeamTabItemDic = new Dictionary<int, AdventureTeamMainTabItem>();
			if (this.waitUIEventWithMainTabTypeArray != null)
			{
				for (int i = 0; i < this.waitUIEventWithMainTabTypeArray.GetLength(0); i++)
				{
					UIEventSystem.GetInstance().RegisterEventHandler((EUIEventID)this.waitUIEventWithMainTabTypeArray[i, 0], new ClientEventSystem.UIEventHandler(this._OnUIEventCome));
				}
			}
		}

		// Token: 0x0600C79B RID: 51099 RVA: 0x003048E0 File Offset: 0x00302CE0
		private void OnDestroy()
		{
			if (this.adventureTeamTabItemDic != null)
			{
				this.adventureTeamTabItemDic.Clear();
				this.adventureTeamTabItemDic = null;
			}
			if (this.waitUIEventWithMainTabTypeArray != null)
			{
				for (int i = 0; i < this.waitUIEventWithMainTabTypeArray.GetLength(0); i++)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler((EUIEventID)this.waitUIEventWithMainTabTypeArray[i, 0], new ClientEventSystem.UIEventHandler(this._OnUIEventCome));
				}
				this.waitUIEventWithMainTabTypeArray = null;
			}
		}

		// Token: 0x0600C79C RID: 51100 RVA: 0x0030495C File Offset: 0x00302D5C
		private void _OnUIEventCome(UIEvent uiEvent)
		{
			if (this.waitUIEventWithMainTabTypeArray == null)
			{
				return;
			}
			if (this.adventureTeamTabItemDic == null)
			{
				return;
			}
			int num = -1;
			AdventureTeamMainTabItem adventureTeamMainTabItem = null;
			int i = 0;
			while (i < this.waitUIEventWithMainTabTypeArray.GetLength(0))
			{
				EUIEventID euieventID = (EUIEventID)this.waitUIEventWithMainTabTypeArray[i, 0];
				if (uiEvent == null)
				{
					if (num != this.waitUIEventWithMainTabTypeArray[i, 1])
					{
						num = this.waitUIEventWithMainTabTypeArray[i, 1];
						goto IL_8A;
					}
				}
				else if (euieventID == uiEvent.EventID)
				{
					num = this.waitUIEventWithMainTabTypeArray[i, 1];
					goto IL_8A;
				}
				IL_B9:
				i++;
				continue;
				IL_8A:
				if (!this.adventureTeamTabItemDic.TryGetValue(num, out adventureTeamMainTabItem))
				{
					goto IL_B9;
				}
				if (adventureTeamMainTabItem == null)
				{
					return;
				}
				bool redPointEnable = this._CheckTabsRedPointShow((AdventureTeamMainTabType)num);
				adventureTeamMainTabItem.SetRedPointEnable(redPointEnable);
				goto IL_B9;
			}
		}

		// Token: 0x0600C79D RID: 51101 RVA: 0x00304A38 File Offset: 0x00302E38
		private bool _CheckTabsRedPointShow(AdventureTeamMainTabType tabType)
		{
			switch (tabType)
			{
			case AdventureTeamMainTabType.BaseInformation:
				return DataManager<AdventureTeamDataManager>.GetInstance().IsBaseInfoTabRedPointShow();
			case AdventureTeamMainTabType.CharacterCollection:
				return DataManager<AdventureTeamDataManager>.GetInstance().IsCharacterCollectionTabRedPointShow();
			case AdventureTeamMainTabType.CharacterExpedition:
				return DataManager<AdventureTeamDataManager>.GetInstance().IsCharacterExpeditionTabRedPointShow();
			case AdventureTeamMainTabType.PassingBless:
				return DataManager<AdventureTeamDataManager>.GetInstance().IsPassingBlessTabRedPointShow();
			case AdventureTeamMainTabType.WeeklyTask:
				return DataManager<AdventureTeamDataManager>.GetInstance().IsWeeklyTaskTabRedPointShow();
			default:
				return false;
			}
		}

		// Token: 0x0600C79E RID: 51102 RVA: 0x00304A9C File Offset: 0x00302E9C
		public void InitBinder(List<AdventureTeamMainTabItem> mainTabItems)
		{
			if (mainTabItems == null || this.adventureTeamTabItemDic == null)
			{
				return;
			}
			for (int i = 0; i < mainTabItems.Count; i++)
			{
				AdventureTeamMainTabType tabType = mainTabItems[i].GetTabType();
				this.adventureTeamTabItemDic.Add((int)tabType, mainTabItems[i]);
			}
		}

		// Token: 0x0600C79F RID: 51103 RVA: 0x00304AF2 File Offset: 0x00302EF2
		public void CheckRedPointsShowOnUIEventCome()
		{
			this._OnUIEventCome(null);
		}

		// Token: 0x040072A5 RID: 29349
		private Dictionary<int, AdventureTeamMainTabItem> adventureTeamTabItemDic;

		// Token: 0x040072A6 RID: 29350
		private int[,] waitUIEventWithMainTabTypeArray = new int[,]
		{
			{
				817,
				0
			},
			{
				814,
				0
			},
			{
				830,
				0
			},
			{
				815,
				1
			},
			{
				816,
				2
			},
			{
				833,
				3
			},
			{
				840,
				4
			}
		};
	}
}
