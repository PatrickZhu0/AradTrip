using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013CF RID: 5071
	public class ComAchievementEffectPlayConfig : MonoBehaviour
	{
		// Token: 0x0600C4AD RID: 50349 RVA: 0x002F3D48 File Offset: 0x002F2148
		public void Play()
		{
			int num = DataManager<MissionManager>.GetInstance().PopAchievementItem();
			if (num != 0)
			{
				if (Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSubItemTable>(num, string.Empty, string.Empty) == null)
				{
					return;
				}
				if (this.effectItems.Count > 0)
				{
					ComAchievementEffectPlayItem comAchievementEffectPlayItem = this.effectItems[0];
					this.effectItems.RemoveAt(0);
					this.mUsedItems.Add(comAchievementEffectPlayItem);
					comAchievementEffectPlayItem.OnCreate();
					comAchievementEffectPlayItem.SetValue(num);
				}
				else if (this.mUsedItems.Count > 0)
				{
					ComAchievementEffectPlayItem comAchievementEffectPlayItem = this.mUsedItems[0];
					this.mUsedItems.RemoveAt(0);
					this.mUsedItems.Add(comAchievementEffectPlayItem);
					comAchievementEffectPlayItem.OnCreate();
					comAchievementEffectPlayItem.SetValue(num);
				}
			}
			else if (this.mUsedItems.Count > 0)
			{
				this.mUsedItems[0].OnRecycle();
				this.effectItems.Add(this.mUsedItems[0]);
				this.mUsedItems.RemoveAt(0);
			}
		}

		// Token: 0x04007001 RID: 28673
		public List<ComAchievementEffectPlayItem> effectItems = new List<ComAchievementEffectPlayItem>(4);

		// Token: 0x04007002 RID: 28674
		private List<ComAchievementEffectPlayItem> mUsedItems = new List<ComAchievementEffectPlayItem>(4);
	}
}
