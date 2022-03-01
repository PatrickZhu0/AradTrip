using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001427 RID: 5159
	public class AdventureTeamWeeklyTaskModule<T> : MonoBehaviour where T : ClientFrame, new()
	{
		// Token: 0x0600C82B RID: 51243 RVA: 0x003088AC File Offset: 0x00306CAC
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

		// Token: 0x0600C82C RID: 51244 RVA: 0x0030891C File Offset: 0x00306D1C
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C82D RID: 51245 RVA: 0x00308934 File Offset: 0x00306D34
		private void OnClickAward()
		{
			if (DataManager<AdventureTeamDataManager>.GetInstance()._GetFinishedWeeklyTaskNum() < DataManager<AdventureTeamDataManager>.GetInstance().ADTMissionFinishMaxNum)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("adventure_team_weekly_task_submit_tip"), new UnityAction(this.FinishTask), null, 0f, false);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("adventure_team_weekly_task_cant_submit", DataManager<AdventureTeamDataManager>.GetInstance().ADTMissionFinishMaxNum), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600C82E RID: 51246 RVA: 0x003089A0 File Offset: 0x00306DA0
		private void FinishTask()
		{
			DataManager<MissionManager>.GetInstance().FinishAccountTaskReq(this.value.missionItem.ID);
		}

		// Token: 0x0600C82F RID: 51247 RVA: 0x003089BC File Offset: 0x00306DBC
		private void OnClickGo()
		{
			if (this.value.missionItem != null)
			{
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(this.value.missionItem.LinkInfo, null, false);
			}
		}

		// Token: 0x0600C830 RID: 51248 RVA: 0x003089EC File Offset: 0x00306DEC
		public void Init(MissionManager.SingleMissionInfo data, ClientFrame clientFrame)
		{
			this.value = data;
			this.frame = (clientFrame as T);
			MissionTable missionItem = this.value.missionItem;
			if (missionItem == null)
			{
				return;
			}
			if (this.award != null)
			{
				this.award.onClick.AddListener(new UnityAction(this.OnClickAward));
			}
			if (this.go != null)
			{
				this.go.onClick.AddListener(new UnityAction(this.OnClickGo));
			}
			base.gameObject.name = missionItem.ID.ToString();
			this._RecycleComItems();
			if (this.Desc != null)
			{
				this.Desc.text = Utility.ParseMissionText(missionItem.ID, true, false, false);
			}
			if (this.Icon != null && !string.IsNullOrEmpty(missionItem.Icon))
			{
				ETCImageLoader.LoadSprite(ref this.Icon, missionItem.Icon, true);
				this.Icon.SetNativeSize();
			}
			if (this.Difficult != null)
			{
				int num = 0;
				int.TryParse(missionItem.MissionParam, out num);
				Text difficult = this.Difficult;
				AdventureTeamTaskDifficult adventureTeamTaskDifficult = (AdventureTeamTaskDifficult)num;
				difficult.text = adventureTeamTaskDifficult.ToString();
			}
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
							comItem.transform.SetSiblingIndex(i + 1);
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
				this.go.CustomActive(false);
				this.acquired.CustomActive(true);
			}
			else
			{
				this.complete.CustomActive(false);
				this.acquired.CustomActive(false);
				bool flag3 = missionItem != null && missionItem.TaskFinishType == MissionTable.eTaskFinishType.TFT_LINKS && !string.IsNullOrEmpty(missionItem.LinkInfo) && this.value.status == 1;
				this.award.CustomActive(!flag3);
				this.go.CustomActive(flag3);
				flag2 = (this.value.status == 2);
			}
			this.award.enabled = (!flag && flag2);
			bool enabled = DataManager<AdventureTeamDataManager>.GetInstance()._GetFinishedWeeklyTaskNum() >= DataManager<AdventureTeamDataManager>.GetInstance().ADTMissionFinishMaxNum;
			this.gray.enabled = enabled;
		}

		// Token: 0x04007340 RID: 29504
		private MissionManager.SingleMissionInfo value;

		// Token: 0x04007341 RID: 29505
		private T frame;

		// Token: 0x04007342 RID: 29506
		private List<ComItem> akComItems = new List<ComItem>();

		// Token: 0x04007343 RID: 29507
		private List<ComItem> akCachedItems = new List<ComItem>();

		// Token: 0x04007344 RID: 29508
		public Text Desc;

		// Token: 0x04007345 RID: 29509
		public GameObject awardParent;

		// Token: 0x04007346 RID: 29510
		public UIGray gray;

		// Token: 0x04007347 RID: 29511
		public Button award;

		// Token: 0x04007348 RID: 29512
		public Button go;

		// Token: 0x04007349 RID: 29513
		public Image complete;

		// Token: 0x0400734A RID: 29514
		public Image acquired;

		// Token: 0x0400734B RID: 29515
		public Image Icon;

		// Token: 0x0400734C RID: 29516
		public Text Difficult;
	}
}
