using System;
using System.Collections.Generic;
using System.Globalization;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013D5 RID: 5077
	public class ComAchievementSubItem : MonoBehaviour
	{
		// Token: 0x0600C4C7 RID: 50375 RVA: 0x002F4309 File Offset: 0x002F2709
		private void Awake()
		{
		}

		// Token: 0x0600C4C8 RID: 50376 RVA: 0x002F430C File Offset: 0x002F270C
		private void OnDestroy()
		{
			if (this.comItems != null)
			{
				for (int i = 0; i < this.comItems.Length; i++)
				{
					ComItemManager.Destroy(this.comItems[i]);
				}
				this.comItems = null;
			}
		}

		// Token: 0x0600C4C9 RID: 50377 RVA: 0x002F4354 File Offset: 0x002F2754
		public void OnClickLink()
		{
			AchievementGroupSubItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSubItemTable>(this.value.ID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(this.value.FunctionID, string.Empty, string.Empty);
				int num = (tableItem2 != null) ? tableItem2.FinishLevel : 0;
				if (!Utility.IsFunctionCanUnlock((FunctionUnLock.eFuncType)this.value.FunctionID))
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(this.unlockHintFmt, num), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
					return;
				}
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem.LinkInfo, null, false);
			}
		}

		// Token: 0x0600C4CA RID: 50378 RVA: 0x002F43FB File Offset: 0x002F27FB
		public void OnClickShare()
		{
			if (this.value != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShareAchievementItem, this.value, null, null, null);
			}
		}

		// Token: 0x0600C4CB RID: 50379 RVA: 0x002F4420 File Offset: 0x002F2820
		public void OnClickAcquired()
		{
			if (this.value != null)
			{
				MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)this.value.ID);
				if (mission != null)
				{
					DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)mission.missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
				}
			}
		}

		// Token: 0x0600C4CC RID: 50380 RVA: 0x002F446C File Offset: 0x002F286C
		public void OnItemVisible(AchievementGroupSubItemTable value)
		{
			if (this.comItems == null)
			{
				this.comItems = new ComItem[this.parents.Length];
				for (int i = 0; i < this.parents.Length; i++)
				{
					this.comItems[i] = ComItemManager.Create(this.parents[i]);
				}
			}
			this.value = value;
			if (value != null)
			{
				ETCImageLoader.LoadSprite(ref this.icon, value.Icon, true);
				MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)value.ID);
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(value.ID, string.Empty, string.Empty);
				if (null != this.acPoint && tableItem != null)
				{
					this.acPoint.text = tableItem.IntParam0.ToString();
				}
				if (null != this.itemName && tableItem != null)
				{
					this.itemName.text = tableItem.TaskName;
				}
				if (null != this.itemDesc)
				{
					this.itemDesc.text = Utility.ParseMissionText(value.ID, true, false, false);
				}
				Utility.ContentProcess contentProcess = Utility.ParseMissionProcess(value.ID, true);
				if (contentProcess != null)
				{
					if (null != this.process)
					{
						this.process.text = string.Format(this.processFmt, contentProcess.iPreValue, contentProcess.iAftValue);
					}
					if (null != this.slider)
					{
						this.slider.value = contentProcess.fAmount;
					}
				}
				List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(value.ID, -1);
				int num = (missionAwards != null) ? missionAwards.Count : 0;
				int num2 = 0;
				while (num2 < this.comItems.Length && num2 < this.parents.Length)
				{
					this.parents[num2].CustomActive(num2 < num);
					if (num2 < num)
					{
						AwardItemData awardItemData = missionAwards[num2];
						if (awardItemData != null)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(awardItemData.ID, 100, 0);
							itemData.Count = awardItemData.Num;
							this.comItems[num2].Setup(itemData, delegate(GameObject go, ItemData item)
							{
								DataManager<ItemTipManager>.GetInstance().CloseAll();
								DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
							});
						}
						else
						{
							this.comItems[num2].Setup(null, null);
						}
					}
					else
					{
						this.comItems[num2].Setup(null, null);
					}
					num2++;
				}
				int num3 = 0;
				if (mission != null)
				{
					num3 = (int)mission.status;
				}
				if (null != this.fnishTime && !string.IsNullOrEmpty(this.finishTimeFmt))
				{
					DateTime dateTime = Function.ConvertIntDateTime(mission.finTime);
					this.fnishTime.text = dateTime.ToString(this.finishTimeFmt, DateTimeFormatInfo.InvariantInfo);
				}
				if (null != this.state)
				{
					if (num3 == 2)
					{
						this.state.Key = "finished";
					}
					else if (num3 == 5)
					{
						this.state.Key = "share";
					}
					else if (num3 == 1)
					{
						if (!string.IsNullOrEmpty(value.LinkInfo))
						{
							this.state.Key = "go";
						}
						else if (contentProcess != null && contentProcess.iPreValue > 0)
						{
							this.state.Key = "running";
						}
						else
						{
							this.state.Key = "unstart";
						}
					}
					else if (num3 == 0)
					{
						if (!string.IsNullOrEmpty(value.LinkInfo))
						{
							this.state.Key = "go";
						}
						else
						{
							this.state.Key = "unstart";
						}
					}
					else
					{
						this.state.Key = "unstart";
					}
				}
			}
		}

		// Token: 0x04007010 RID: 28688
		public Image icon;

		// Token: 0x04007011 RID: 28689
		public Text acPoint;

		// Token: 0x04007012 RID: 28690
		public Text itemName;

		// Token: 0x04007013 RID: 28691
		public Text itemDesc;

		// Token: 0x04007014 RID: 28692
		public string processFmt;

		// Token: 0x04007015 RID: 28693
		public string finishTimeFmt;

		// Token: 0x04007016 RID: 28694
		public string unlockHintFmt;

		// Token: 0x04007017 RID: 28695
		public Text process;

		// Token: 0x04007018 RID: 28696
		public Text fnishTime;

		// Token: 0x04007019 RID: 28697
		public Slider slider;

		// Token: 0x0400701A RID: 28698
		public GameObject[] parents = new GameObject[0];

		// Token: 0x0400701B RID: 28699
		public StateController state;

		// Token: 0x0400701C RID: 28700
		private ComItem[] comItems;

		// Token: 0x0400701D RID: 28701
		private AchievementGroupSubItemTable value;
	}
}
