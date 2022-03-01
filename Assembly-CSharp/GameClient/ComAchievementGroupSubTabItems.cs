using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013D3 RID: 5075
	public class ComAchievementGroupSubTabItems : MonoBehaviour
	{
		// Token: 0x0600C4C1 RID: 50369 RVA: 0x002F4164 File Offset: 0x002F2564
		public void SetFlags(AchievementGroupMainItemTable mainItem)
		{
			if (mainItem != null)
			{
				int count = mainItem.ChildTabs.Count;
				if (count == 1)
				{
					base.gameObject.CustomActive(false);
				}
				else
				{
					base.gameObject.CustomActive(true);
					for (int i = 0; i < this.subItems.Length; i++)
					{
						this.subItems[i].CustomActive(i < mainItem.ChildTabs.Count);
						ComAchievementGroupSubTabItem comAchievementGroupSubTabItem = this.subItems[i];
						comAchievementGroupSubTabItem.OnValueChanged(false);
						if (i < mainItem.ChildTabs.Count)
						{
							comAchievementGroupSubTabItem.OnItemVisible(mainItem.ChildTabs[i]);
						}
					}
				}
			}
			else
			{
				base.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0400700F RID: 28687
		public ComAchievementGroupSubTabItem[] subItems;
	}
}
