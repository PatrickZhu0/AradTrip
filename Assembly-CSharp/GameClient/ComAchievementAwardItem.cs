using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013CD RID: 5069
	internal class ComAchievementAwardItem : MonoBehaviour
	{
		// Token: 0x0600C4A3 RID: 50339 RVA: 0x002F37FC File Offset: 0x002F1BFC
		public void OnClickAcquired()
		{
			if (DataManager<ItemDataManager>.GetInstance().IsPackageFull(EPackageType.Invalid))
			{
				SystemNotifyManager.SystemNotify(9058, string.Empty);
				return;
			}
			if (this.data != null && this.data.ID != 0)
			{
				DataManager<AchievementGroupDataManager>.GetInstance().SendGetAward(this.data.ID);
				AchievementAwardPlayFrame.CommandOpen(new AchievementAwardPlayFrameData
				{
					iId = this.data.ID
				});
			}
		}

		// Token: 0x0600C4A4 RID: 50340 RVA: 0x002F3878 File Offset: 0x002F1C78
		public int getStatus()
		{
			if (this.data == null || this.keys.Length != 3)
			{
				return 0;
			}
			bool flag = DataManager<AchievementGroupDataManager>.GetInstance().IsAchievementFinished(this.data.ID);
			if (flag)
			{
				return 2;
			}
			int achievementScore = DataManager<PlayerBaseData>.GetInstance().AchievementScore;
			if (achievementScore < this.data.Max)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x0600C4A5 RID: 50341 RVA: 0x002F38E0 File Offset: 0x002F1CE0
		public void OnItemVisible(AchievementLevelInfoTable achievementItem)
		{
			this.data = achievementItem;
			if (this.data == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.icon, this.data.Icon, true);
			if (null != this.desc)
			{
				this.desc.text = string.Format(this.data.Name, this.data.Max);
			}
			if (this.comItems == null)
			{
				this.comItems = new ComItem[this.goParents.Length];
				for (int i = 0; i < this.goParents.Length; i++)
				{
					this.comItems[i] = ComItemManager.Create(this.goParents[i]);
				}
			}
			if (this.data.AwardCount.Count == this.data.AwardID.Count)
			{
				for (int j = 0; j < this.comItems.Length; j++)
				{
					this.goParents[j].CustomActive(j < this.data.AwardID.Count);
					if (j < this.data.AwardID.Count)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.data.AwardID[j], 100, 0);
						if (itemData != null)
						{
							itemData.Count = this.data.AwardCount[j];
						}
						this.comItems[j].Setup(itemData, new ComItem.OnItemClicked(this._OnItemClicked));
					}
				}
			}
			int status = this.getStatus();
			if (status >= 0 && status < this.keys.Length && null != this.mState)
			{
				this.mState.Key = this.keys[status];
			}
			if (null != this.achievementPoint)
			{
				this.achievementPoint.text = string.Format(this.mAchievementPointString, this.data.Max);
			}
		}

		// Token: 0x0600C4A6 RID: 50342 RVA: 0x002F3ADC File Offset: 0x002F1EDC
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C4A7 RID: 50343 RVA: 0x002F3AF4 File Offset: 0x002F1EF4
		private void OnDestroy()
		{
			if (this.comItems != null)
			{
				for (int i = 0; i < this.comItems.Length; i++)
				{
					ComItemManager.Destroy(this.comItems[i]);
					this.comItems[i] = null;
				}
				this.comItems = null;
			}
		}

		// Token: 0x04006FF5 RID: 28661
		public Image icon;

		// Token: 0x04006FF6 RID: 28662
		public Text desc;

		// Token: 0x04006FF7 RID: 28663
		public Text achievementPoint;

		// Token: 0x04006FF8 RID: 28664
		public GameObject[] goParents = new GameObject[0];

		// Token: 0x04006FF9 RID: 28665
		public StateController mState;

		// Token: 0x04006FFA RID: 28666
		public string[] keys = new string[0];

		// Token: 0x04006FFB RID: 28667
		private AchievementLevelInfoTable data;

		// Token: 0x04006FFC RID: 28668
		private ComItem[] comItems;

		// Token: 0x04006FFD RID: 28669
		public string mAchievementPointString = string.Empty;
	}
}
