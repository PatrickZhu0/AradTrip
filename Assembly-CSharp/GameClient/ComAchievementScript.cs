using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017B9 RID: 6073
	internal class ComAchievementScript : MonoBehaviour
	{
		// Token: 0x0600EF7F RID: 61311 RVA: 0x004060F8 File Offset: 0x004044F8
		private void OnDestroy()
		{
			this.Name = null;
			this.Desc = null;
			this.awardParent = null;
			this.progressImage = null;
			if (this.slider != null)
			{
				this.slider.onValueChanged.RemoveAllListeners();
				this.slider = null;
			}
			this.progressText = null;
			this.progress = null;
			this.gray = null;
			if (this.award != null)
			{
				this.award.onClick.RemoveAllListeners();
				this.award = null;
			}
			if (this.go != null)
			{
				this.go.onClick.RemoveAllListeners();
				this.go = null;
			}
			this.complete = null;
		}

		// Token: 0x0600EF80 RID: 61312 RVA: 0x004061B8 File Offset: 0x004045B8
		private void _RecycleComItems()
		{
			for (int i = 0; i < this.akComItems.Count; i++)
			{
				this.akComItems[i].Setup(null, null);
				this.akComItems[i].CustomActive(false);
				this.akCachedItems.Add(this.akComItems[i]);
			}
			this.akComItems.Clear();
		}

		// Token: 0x0600EF81 RID: 61313 RVA: 0x00406228 File Offset: 0x00404628
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600EF82 RID: 61314 RVA: 0x0040623A File Offset: 0x0040463A
		private void OnClickAward()
		{
			DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.value.missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
		}

		// Token: 0x0600EF83 RID: 61315 RVA: 0x00406258 File Offset: 0x00404658
		private void OnClickGo()
		{
			if (this.value.missionItem != null)
			{
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(this.value.missionItem.LinkInfo, null, false);
			}
		}

		// Token: 0x0600EF84 RID: 61316 RVA: 0x00406288 File Offset: 0x00404688
		public void OnVisible(MissionManager.SingleMissionInfo data, ClientFrame clientFrame)
		{
			this.value = data;
			this.frame = (clientFrame as MissionFrameNew);
			MissionTable missionItem = this.value.missionItem;
			this.award.onClick.RemoveAllListeners();
			this.award.onClick.AddListener(new UnityAction(this.OnClickAward));
			this.go.onClick.RemoveAllListeners();
			this.go.onClick.AddListener(new UnityAction(this.OnClickGo));
			base.gameObject.name = missionItem.ID.ToString();
			this.Name.text = missionItem.TaskName;
			this.Desc.text = Utility.ParseMissionText(missionItem.ID, true, false, false);
			this._RecycleComItems();
			List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(missionItem.ID, -1);
			for (int i = 0; i < missionAwards.Count; i++)
			{
				AwardItemData awardItemData = missionAwards[i];
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(awardItemData.ID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(awardItemData.ID, 100, 0);
					if (itemData != null)
					{
						itemData.Count = awardItemData.Num;
						ComItem comItem;
						if (this.akCachedItems.Count > 0)
						{
							comItem = this.akCachedItems[0];
							this.akCachedItems.RemoveAt(0);
						}
						else
						{
							comItem = this.frame.CreateComItem(this.awardParent);
						}
						if (comItem != null)
						{
							comItem.CustomActive(true);
							comItem.Setup(itemData, new ComItem.OnItemClicked(this._OnItemClicked));
							this.akComItems.Add(comItem);
						}
					}
				}
			}
			bool flag = this.value.status == 5;
			bool flag2 = false;
			if (flag)
			{
				this.complete.CustomActive(true);
				this.award.CustomActive(false);
				this.progress.CustomActive(false);
				this.go.CustomActive(false);
			}
			else
			{
				this.complete.CustomActive(false);
				bool flag3 = missionItem != null && missionItem.TaskFinishType == MissionTable.eTaskFinishType.TFT_LINKS && !string.IsNullOrEmpty(missionItem.LinkInfo) && this.value.status == 1;
				this.award.CustomActive(!flag3);
				this.go.CustomActive(flag3);
				this.progress.CustomActive(true);
				Utility.ContentProcess contentProcess = Utility.ParseMissionProcess(missionItem.ID, true);
				if (contentProcess != null)
				{
					if (contentProcess.iPreValue > contentProcess.iAftValue)
					{
						contentProcess.iPreValue = contentProcess.iAftValue;
					}
					this.slider.value = contentProcess.fAmount;
					this.progressText.text = contentProcess.iPreValue + "/" + contentProcess.iAftValue;
					flag2 = (this.value.status == 2);
				}
			}
			this.award.enabled = (!flag && flag2);
			this.gray.enabled = !this.award.enabled;
		}

		// Token: 0x040092B9 RID: 37561
		private MissionManager.SingleMissionInfo value;

		// Token: 0x040092BA RID: 37562
		private MissionFrameNew frame;

		// Token: 0x040092BB RID: 37563
		private List<ComItem> akComItems = new List<ComItem>();

		// Token: 0x040092BC RID: 37564
		private List<ComItem> akCachedItems = new List<ComItem>();

		// Token: 0x040092BD RID: 37565
		public Text Name;

		// Token: 0x040092BE RID: 37566
		public Text Desc;

		// Token: 0x040092BF RID: 37567
		public GameObject awardParent;

		// Token: 0x040092C0 RID: 37568
		public Image progressImage;

		// Token: 0x040092C1 RID: 37569
		public Slider slider;

		// Token: 0x040092C2 RID: 37570
		public Text progressText;

		// Token: 0x040092C3 RID: 37571
		public GameObject progress;

		// Token: 0x040092C4 RID: 37572
		public UIGray gray;

		// Token: 0x040092C5 RID: 37573
		public Button award;

		// Token: 0x040092C6 RID: 37574
		public Button go;

		// Token: 0x040092C7 RID: 37575
		public Image complete;
	}
}
