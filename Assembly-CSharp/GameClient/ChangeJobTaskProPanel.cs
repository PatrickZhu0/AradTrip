using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200151C RID: 5404
	internal class ChangeJobTaskProPanel : ClientFrame
	{
		// Token: 0x0600D213 RID: 53779 RVA: 0x0033E096 File Offset: 0x0033C496
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ChangeJob/ChangeJobTaskProPanel";
		}

		// Token: 0x0600D214 RID: 53780 RVA: 0x0033E09D File Offset: 0x0033C49D
		protected override void _OnOpenFrame()
		{
			this.InitTaskItem();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnFinishTask));
		}

		// Token: 0x0600D215 RID: 53781 RVA: 0x0033E0CB File Offset: 0x0033C4CB
		protected override void _OnCloseFrame()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnFinishTask));
		}

		// Token: 0x0600D216 RID: 53782 RVA: 0x0033E0F3 File Offset: 0x0033C4F3
		[UIEventHandle("Title/btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<ChangeJobTaskProPanel>(this, false);
		}

		// Token: 0x0600D217 RID: 53783 RVA: 0x0033E102 File Offset: 0x0033C502
		public void OnFinishTask(uint iMissionID)
		{
			if (!Utility.IsChangeJobTask(iMissionID))
			{
				return;
			}
			this.UpdateTaskItem();
		}

		// Token: 0x0600D218 RID: 53784 RVA: 0x0033E118 File Offset: 0x0033C518
		private void InitTaskItem()
		{
			this.TaskList = Utility.GetChangeJobTaskList();
			if (this.TaskList.Count <= 0)
			{
				ChangeJobSelectFrame.Create(DataManager<PlayerBaseData>.GetInstance().JobTableID, true);
				this.OnClose();
			}
			for (int i = 0; i < this.TaskList.Count; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.ItemPath, true, 0U);
				gameObject.transform.SetParent(this.gameObjContent.transform, false);
				gameObject.transform.SetAsLastSibling();
				ComTaskProItem component = gameObject.GetComponent<ComTaskProItem>();
				if (!(component == null))
				{
					component.TaskID = (uint)this.TaskList[i];
				}
			}
			this.UpdateTaskItem();
		}

		// Token: 0x0600D219 RID: 53785 RVA: 0x0033E1D8 File Offset: 0x0033C5D8
		private void UpdateTaskItem()
		{
			if (this.TaskList == null)
			{
				return;
			}
			if (this.gameObjContent == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.TaskList.Count; i++)
			{
				Transform child = this.gameObjContent.transform.GetChild(i);
				if (!(child == null))
				{
					GameObject gameObject = child.gameObject;
					if (!(gameObject == null))
					{
						ComTaskProItem comItem = gameObject.GetComponent<ComTaskProItem>();
						if (!(comItem == null))
						{
							MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)comItem.TaskID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								if (i >= 0 && i < 3)
								{
									comItem.TaskTitle.text = string.Format("任务{0}", i + 1);
								}
								comItem.TaskName.text = tableItem.TaskName;
								List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards((int)comItem.TaskID, -1);
								if (missionAwards == null)
								{
									Logger.LogError("awards is null in [UpdateTaskItem]");
								}
								else
								{
									for (int j = 0; j < comItem.Reward.Count; j++)
									{
										if (j < missionAwards.Count)
										{
											ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(missionAwards[j].ID, string.Empty, string.Empty);
											if (tableItem2 == null)
											{
												comItem.Reward[j].SetActive(false);
											}
											else
											{
												Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(tableItem2.Icon, typeof(Sprite), true, 0U).obj as Sprite;
												if (sprite == null)
												{
													comItem.Reward[j].SetActive(false);
												}
												else
												{
													Image component = comItem.Reward[j].GetComponent<Image>();
													if (component == null)
													{
														Logger.LogError("img is null in [UpdateTaskItem]");
													}
													else
													{
														ETCImageLoader.LoadSprite(ref component, tableItem2.Icon, true);
														comItem.RewardNum[j].text = missionAwards[j].Num.ToString();
														comItem.Reward[j].gameObject.SetActive(true);
													}
												}
											}
										}
										else
										{
											comItem.Reward[j].SetActive(false);
										}
									}
									MissionManager.SingleMissionInfo singleMissionInfo = null;
									DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue(comItem.TaskID, out singleMissionInfo);
									if (singleMissionInfo != null)
									{
										flag = true;
										comItem.FinishText.CustomActive(false);
										comItem.FinishButton.CustomActive(true);
										comItem.FinishButton.interactable = true;
										comItem.LockObj.CustomActive(false);
										Color color = comItem.FinishButtonText.color;
										color.a = 1f;
										comItem.FinishButtonText.color = color;
										if (singleMissionInfo.status == 2)
										{
											if (i == this.TaskList.Count - 1)
											{
												comItem.FinishButtonText.text = "转职成功";
											}
											else
											{
												comItem.FinishButtonText.text = "领取奖励";
											}
											comItem.FinishButton.onClick.RemoveAllListeners();
											comItem.FinishButton.onClick.AddListener(delegate()
											{
												DataManager<MissionManager>.GetInstance().sendCmdSubmitTask(comItem.TaskID, TaskSubmitType.TASK_SUBMIT_UI, 0U);
											});
										}
										else
										{
											comItem.FinishButtonText.text = "进行中  前往";
											comItem.FinishButton.onClick.RemoveAllListeners();
											comItem.FinishButton.onClick.AddListener(delegate()
											{
												this.OnClose();
												DataManager<MissionManager>.GetInstance().AutoTraceTask((int)comItem.TaskID, null, null, false);
											});
										}
									}
									else if (flag)
									{
										comItem.FinishText.CustomActive(false);
										comItem.FinishButton.CustomActive(false);
										comItem.LockObj.CustomActive(true);
									}
									else
									{
										comItem.FinishText.CustomActive(true);
										comItem.FinishButton.CustomActive(false);
										comItem.LockObj.CustomActive(false);
									}
									comItem.TaskContent.SetText(Utility.ParseMissionText(tableItem.ID, true, !flag, false), true);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04007AFE RID: 31486
		private string ItemPath = "UIFlatten/Prefabs/ChangeJob/ChangeJobTaskProItem";

		// Token: 0x04007AFF RID: 31487
		private const int MaxTaskNum = 4;

		// Token: 0x04007B00 RID: 31488
		private List<int> TaskList = new List<int>();

		// Token: 0x04007B01 RID: 31489
		[UIObject("ScrollView/Viewport/Content")]
		private GameObject gameObjContent;
	}
}
