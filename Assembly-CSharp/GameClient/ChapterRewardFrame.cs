using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001534 RID: 5428
	public class ChapterRewardFrame : ClientFrame
	{
		// Token: 0x0600D3AF RID: 54191 RVA: 0x003494AA File Offset: 0x003478AA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/SelectReward/ChapterSelectRewardFrame.prefab";
		}

		// Token: 0x0600D3B0 RID: 54192 RVA: 0x003494B4 File Offset: 0x003478B4
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mFinishcount = this.mBind.GetCom<Text>("finishcount");
			this.mSumcount = this.mBind.GetCom<Text>("sumcount");
			this.mContent = this.mBind.GetGameObject("content");
			this.mProcess = this.mBind.GetCom<Slider>("process");
			this.mChapterNum = this.mBind.GetCom<Text>("chapterNum");
			this.mToggleUIList = this.mBind.GetCom<ComUIListScript>("ToggleUIList");
			this.mChapterSelectRewardBox1 = this.mBind.GetGameObject("ChapterSelectRewardBox1");
			this.mChapterSelectRewardBox2 = this.mBind.GetGameObject("ChapterSelectRewardBox2");
			this.mChapterSelectRewardBox3 = this.mBind.GetGameObject("ChapterSelectRewardBox3");
			this.mScoreCount = this.mBind.GetCom<Text>("ScoreCount");
			this.mTaskItemComUIList = this.mBind.GetCom<ComUIListScript>("TaskItemComUIList");
			this.mChapterReward = this.mBind.GetCom<Button>("chapterReward");
			this.mChapterReward.onClick.AddListener(new UnityAction(this._onChapterRewardButtonClick));
			this.mChapterRewardText = this.mBind.GetCom<Text>("chapterRewardText");
			this.mCharpterRewardGray = this.mBind.GetCom<UIGray>("charpterRewardGray");
			this.mChapterRewardRoot = this.mBind.GetGameObject("chapterRewardRoot");
			this.mChapterRewardBoxStatus = this.mBind.GetCom<Image>("chapterRewardBoxStatus");
			this.mChapterRewardBox = this.mBind.GetCom<Button>("chapterRewardBox");
			this.mChapterRewardBox.onClick.AddListener(new UnityAction(this._onChapterRewardBoxButtonClick));
			this.mChapterRewardBoxBg = this.mBind.GetCom<Button>("chapterRewardBoxBg");
			this.mChapterRewardBoxBg.onClick.AddListener(new UnityAction(this._onChapterRewardBoxBgButtonClick));
			this.mChapterRewardBoxClose = this.mBind.GetCom<Button>("chapterRewardBoxClose");
			this.mChapterRewardBoxClose.onClick.AddListener(new UnityAction(this._onChapterRewardBoxCloseButtonClick));
			this.mChapterRewardRed = this.mBind.GetGameObject("chapterRewardRed");
			this.mEffectRoot = this.mBind.GetGameObject("effectRoot");
			this.mEffectAnimate = this.mBind.GetCom<DOTweenAnimation>("effectAnimate");
			this.mAllreward = this.mBind.GetCom<ComItemList>("allreward");
			this.mTaskScroll = this.mBind.GetCom<ScrollRect>("TaskScroll");
		}

		// Token: 0x0600D3B1 RID: 54193 RVA: 0x00349774 File Offset: 0x00347B74
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mFinishcount = null;
			this.mSumcount = null;
			this.mContent = null;
			this.mProcess = null;
			this.mChapterNum = null;
			this.mToggleUIList = null;
			this.mChapterSelectRewardBox1 = null;
			this.mChapterSelectRewardBox2 = null;
			this.mChapterSelectRewardBox3 = null;
			this.mScoreCount = null;
			this.mTaskItemComUIList = null;
			this.mChapterReward.onClick.RemoveListener(new UnityAction(this._onChapterRewardButtonClick));
			this.mChapterReward = null;
			this.mChapterRewardText = null;
			this.mChapterNum = null;
			this.mChapterRewardRoot = null;
			this.mChapterRewardBoxStatus = null;
			this.mChapterRewardBox.onClick.RemoveListener(new UnityAction(this._onChapterRewardBoxButtonClick));
			this.mChapterRewardBox = null;
			this.mChapterRewardBoxBg.onClick.RemoveListener(new UnityAction(this._onChapterRewardBoxBgButtonClick));
			this.mChapterRewardBoxBg = null;
			this.mChapterRewardBoxClose.onClick.RemoveListener(new UnityAction(this._onChapterRewardBoxCloseButtonClick));
			this.mChapterRewardBoxClose = null;
			this.mChapterRewardRed = null;
			this.mEffectRoot = null;
			this.mEffectAnimate = null;
			this.mAllreward = null;
			this.mTaskScroll = null;
		}

		// Token: 0x0600D3B2 RID: 54194 RVA: 0x003498BC File Offset: 0x00347CBC
		private void _onCloseButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<ChapterRewardFrame>(this, false);
		}

		// Token: 0x0600D3B3 RID: 54195 RVA: 0x003498CA File Offset: 0x00347CCA
		private void _onChapterRewardButtonClick()
		{
			this._onChapterRewardButtonClickByIdx(this.mCurSelectChapterIdx);
		}

		// Token: 0x0600D3B4 RID: 54196 RVA: 0x003498D8 File Offset: 0x00347CD8
		private void _onChapterRewardBoxButtonClick()
		{
			this.mChapterRewardRoot.CustomActive(true);
		}

		// Token: 0x0600D3B5 RID: 54197 RVA: 0x003498E6 File Offset: 0x00347CE6
		private void _onChapterRewardBoxBgButtonClick()
		{
			this.mChapterRewardRoot.CustomActive(false);
		}

		// Token: 0x0600D3B6 RID: 54198 RVA: 0x003498F4 File Offset: 0x00347CF4
		private void _onChapterRewardBoxCloseButtonClick()
		{
			this.mChapterRewardRoot.CustomActive(false);
		}

		// Token: 0x0600D3B7 RID: 54199 RVA: 0x00349904 File Offset: 0x00347D04
		private void _onChapterRewardButtonClickByIdx(int chidx)
		{
			List<MissionManager.SingleMissionInfo> list = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Chest, chidx);
			if (list != null && list.Count > 0 && list[0].status == 2)
			{
				DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)list[0].missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
			}
		}

		// Token: 0x0600D3B8 RID: 54200 RVA: 0x0034995C File Offset: 0x00347D5C
		private IEnumerator MoveToChapter(int id)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChapterRewardFrame>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChapterNormalHalfFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChapterNormalHalfFrame>(null, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNormalHalfFrameClose, null, null, null, null);
			}
			yield return new WaitForSeconds(0.5f);
			ClientSystemTown systemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (systemTown != null)
			{
				systemTown.ReturnToTown();
			}
			yield return new WaitForSeconds(2f);
			DataManager<MissionManager>.GetInstance().AutoTraceTask(id, null, null, false);
			yield break;
		}

		// Token: 0x0600D3B9 RID: 54201 RVA: 0x00349977 File Offset: 0x00347D77
		private void _unloadChapter()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this._onUpdateMission));
		}

		// Token: 0x0600D3BA RID: 54202 RVA: 0x003499A0 File Offset: 0x00347DA0
		protected override void _OnOpenFrame()
		{
			this.rewardBoxArr[0] = this.mChapterSelectRewardBox1;
			this.rewardBoxArr[1] = this.mChapterSelectRewardBox2;
			this.rewardBoxArr[2] = this.mChapterSelectRewardBox3;
			this.defaultChapterIdx = 1;
			try
			{
				this.defaultChapterIdx = (int)this.userData;
			}
			catch (Exception ex)
			{
			}
			this.curSelectToggle = this.defaultChapterIdx;
			this._InitData();
			this._InitChapterList();
			this._InitComUIList();
			this._UpdateChapterList();
		}

		// Token: 0x0600D3BB RID: 54203 RVA: 0x00349A30 File Offset: 0x00347E30
		private void _InitData()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this._onUpdateMission));
			this.chapterIDList.Clear();
			this.rewardBoxArr[0] = this.mChapterSelectRewardBox1;
			this.rewardBoxArr[1] = this.mChapterSelectRewardBox2;
			this.rewardBoxArr[2] = this.mChapterSelectRewardBox3;
		}

		// Token: 0x0600D3BC RID: 54204 RVA: 0x00349A98 File Offset: 0x00347E98
		private void _InitChapterList()
		{
			this.chapterIDList.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChapterTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ChapterTable chapterTable = keyValuePair.Value as ChapterTable;
				if (chapterTable.RewardIsOpen == 1)
				{
					this.chapterIDList.Add(chapterTable.ID);
				}
			}
			this.chapterToggleList = new Toggle[this.chapterIDList.Count];
		}

		// Token: 0x0600D3BD RID: 54205 RVA: 0x00349B1C File Offset: 0x00347F1C
		private void _UpdateChapterList()
		{
			this.mToggleUIList.SetElementAmount(this.chapterIDList.Count);
			for (int i = 0; i < this.chapterIDList.Count; i++)
			{
				if (this.chapterIDList[i] == this.curSelectToggle)
				{
					if (this.chapterToggleList[i] == null)
					{
						this.mCurSelectChapterIdx = this.chapterIDList[i];
						this.allRewardList = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Mission, this.chapterIDList[i]);
						this.allRewardList.Sort(new Comparison<MissionManager.SingleMissionInfo>(this.SortList));
						this.mTaskItemComUIList.SetElementAmount(this.allRewardList.Count);
						this._updateProcess(this.chapterIDList[i]);
						this._initAllReward(this.chapterIDList[i]);
						this.mChapterNum.text = this.chapterIDList[i].ToString();
					}
					else
					{
						this.chapterToggleList[i].isOn = true;
					}
				}
			}
		}

		// Token: 0x0600D3BE RID: 54206 RVA: 0x00349C38 File Offset: 0x00348038
		private void _InitComUIList()
		{
			this.mToggleUIList.Initialize();
			this.mToggleUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateBind(item);
				}
			};
			this.mToggleUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					Toggle com = this.mBind.GetCom<Toggle>("Func");
					GameObject gameObject = this.mBind.GetGameObject("Select");
					if (com != null)
					{
						com.isOn = false;
						com.onValueChanged.RemoveAllListeners();
					}
					if (gameObject != null)
					{
						gameObject.CustomActive(false);
					}
					return;
				}
			};
			this.mTaskItemComUIList.Initialize();
			this.mTaskItemComUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateTaskBind(item);
				}
			};
			this.mTaskItemComUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					Button com = component.GetCom<Button>("getbutton");
					if (com != null)
					{
						com.onClick.RemoveAllListeners();
					}
					Button com2 = component.GetCom<Button>("GoChapter");
					if (com2 != null)
					{
						com2.onClick.RemoveAllListeners();
					}
				}
			};
		}

		// Token: 0x0600D3BF RID: 54207 RVA: 0x00349CC8 File Offset: 0x003480C8
		private void _UpdateBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0)
			{
				return;
			}
			if (this.chapterIDList.Count <= 0)
			{
				return;
			}
			Toggle com = component.GetCom<Toggle>("Func");
			Text com2 = component.GetCom<Text>("TabText");
			GameObject mSelect = component.GetGameObject("Select");
			GameObject gameObject = component.GetGameObject("Finished");
			GameObject gameObject2 = component.GetGameObject("NoOpen");
			Text com3 = component.GetCom<Text>("Schedule");
			Image com4 = component.GetCom<Image>("bg");
			com2.text = string.Format("第{0}章", this.chapterIDList[item.m_index]);
			this.chapterToggleList[item.m_index] = com;
			com.onValueChanged.RemoveAllListeners();
			com.onValueChanged.AddListener(delegate(bool value)
			{
				if (value)
				{
					this.mCurSelectChapterIdx = this.chapterIDList[item.m_index];
					this.allRewardList = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Mission, this.chapterIDList[item.m_index]);
					this.allRewardList.Sort(new Comparison<MissionManager.SingleMissionInfo>(this.SortList));
					this.mTaskItemComUIList.SetElementAmount(this.allRewardList.Count);
					if (this.mCurSelectChapterIdx <= 0)
					{
						Logger.LogErrorFormat("[关卡宝箱] 页签索引错误，mCurSelectChapterIdx = {0}", new object[]
						{
							this.mCurSelectChapterIdx
						});
					}
					this._updateProcess(this.chapterIDList[item.m_index]);
					this._initAllReward(this.chapterIDList[item.m_index]);
					this._updateAllRewardStaus(this.chapterIDList[item.m_index]);
					this.mChapterNum.text = this.chapterIDList[item.m_index].ToString();
					this.mTaskScroll.verticalNormalizedPosition = 1f;
				}
				mSelect.CustomActive(value);
			});
			if (this.chapterIDList[item.m_index] == this.mCurSelectChapterIdx)
			{
				com.isOn = true;
				mSelect.CustomActive(true);
			}
			else
			{
				mSelect.CustomActive(false);
			}
			KeyValuePair<int, int> chapterRewardByChapterIdx = ChapterUtility.GetChapterRewardByChapterIdx(this.chapterIDList[item.m_index]);
			int key = chapterRewardByChapterIdx.Key;
			int value2 = chapterRewardByChapterIdx.Value;
			gameObject.CustomActive(false);
			gameObject2.CustomActive(false);
			com3.CustomActive(false);
			com3.text = string.Format("{0}/{1}", key, value2);
			if (key == value2)
			{
				gameObject.CustomActive(true);
			}
			else
			{
				com3.CustomActive(true);
			}
			ChapterTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChapterTable>(this.chapterIDList[item.m_index], string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref com4, tableItem.ChapterIconPath, true);
			}
		}

		// Token: 0x0600D3C0 RID: 54208 RVA: 0x00349EF0 File Offset: 0x003482F0
		private void _UpdateTaskBind(ComUIListElementScript item)
		{
			MissionManager.SingleMissionInfo singleMissionInfo = this.allRewardList[item.m_index];
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0)
			{
				return;
			}
			if (null != component)
			{
				Utility.AttachTo(component.gameObject, this.mContent, false);
				component.gameObject.name = string.Format("{0}", singleMissionInfo.taskID);
				Text com = component.GetCom<Text>("desc");
				ComItemList com2 = component.GetCom<ComItemList>("reward");
				Button com3 = component.GetCom<Button>("getbutton");
				UIGray com4 = component.GetCom<UIGray>("gray");
				Text com5 = component.GetCom<Text>("NowScore");
				Button com6 = component.GetCom<Button>("GoChapter");
				UIGray com7 = component.GetCom<UIGray>("S1");
				UIGray com8 = component.GetCom<UIGray>("S2");
				UIGray com9 = component.GetCom<UIGray>("S3");
				com5.CustomActive(true);
				int curTaskID = singleMissionInfo.missionItem.ID;
				string missionValueByKey = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)curTaskID, "parameter");
				string missionValueByKey2 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)curTaskID, "score");
				int num = -1;
				int num2 = -1;
				int.TryParse(missionValueByKey2, out num);
				int.TryParse(missionValueByKey, out num2);
				com7.enabled = false;
				com8.enabled = false;
				com9.enabled = false;
				if (num != 0)
				{
					switch (num)
					{
					case 3:
						com5.text = "S";
						com7.enabled = true;
						com8.enabled = true;
						break;
					case 4:
						com5.text = "SS";
						com7.enabled = true;
						break;
					case 5:
						com5.text = "SSS";
						break;
					default:
						com5.CustomActive(false);
						com7.enabled = true;
						com8.enabled = true;
						com9.enabled = true;
						break;
					}
				}
				else if (num2 != 1)
				{
					com5.CustomActive(false);
					com7.enabled = true;
					com8.enabled = true;
					com9.enabled = true;
				}
				else
				{
					com5.text = "SSS";
				}
				ChapterRewardFrame.Node node = new ChapterRewardFrame.Node
				{
					bind = component,
					info = singleMissionInfo
				};
				this._updateSingleItemStatus(node);
				MissionTable taskTableData = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(curTaskID, string.Empty, string.Empty);
				if (taskTableData != null)
				{
					com.text = taskTableData.TaskName;
				}
				List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(curTaskID, -1);
				List<ComItemList.Items> list = new List<ComItemList.Items>();
				for (int i = 0; i < missionAwards.Count; i++)
				{
					list.Add(new ComItemList.Items
					{
						id = missionAwards[i].ID,
						count = (uint)missionAwards[i].Num
					});
				}
				com2.SetItems(list.ToArray());
				com3.onClick.RemoveAllListeners();
				com3.onClick.AddListener(delegate()
				{
					DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)curTaskID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
				});
				com6.onClick.RemoveAllListeners();
				int tempMissionId = curTaskID;
				com6.onClick.AddListener(delegate()
				{
					if (tempMissionId != 0)
					{
						if (this.mCurSelectChapterIdx == this.defaultChapterIdx)
						{
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChapterRewardFrame>(null, false);
							if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChapterNormalHalfFrame>(null))
							{
								Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChapterNormalHalfFrame>(null, false);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNormalHalfFrameClose, null, null, null, null);
							}
							ChapterSelectFrame.SetDungeonID(taskTableData.DungeonTableID);
						}
						else
						{
							this.StartCoroutine(this.MoveToChapter(tempMissionId));
						}
					}
				});
			}
		}

		// Token: 0x0600D3C1 RID: 54209 RVA: 0x0034A272 File Offset: 0x00348672
		protected override void _OnCloseFrame()
		{
			this._unloadChapter();
			this.chapterIDList.Clear();
		}

		// Token: 0x0600D3C2 RID: 54210 RVA: 0x0034A288 File Offset: 0x00348688
		private void _onUpdateMission(uint taskID)
		{
			this.mToggleUIList.SetElementAmount(this.chapterIDList.Count);
			this.allRewardList = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Mission, this.mCurSelectChapterIdx);
			this.allRewardList.Sort(new Comparison<MissionManager.SingleMissionInfo>(this.SortList));
			this.mTaskItemComUIList.SetElementAmount(this.allRewardList.Count);
			this._updateProcess(this.mCurSelectChapterIdx);
			this._updateAllRewardStaus(this.mCurSelectChapterIdx);
			this._initAllReward(this.mCurSelectChapterIdx);
		}

		// Token: 0x0600D3C3 RID: 54211 RVA: 0x0034A310 File Offset: 0x00348710
		private int SortList(MissionManager.SingleMissionInfo a, MissionManager.SingleMissionInfo b)
		{
			if (a.status == 2 && b.status != 2)
			{
				return -1;
			}
			if (a.status == 1)
			{
				if (b.status == 2)
				{
					return 1;
				}
				if (b.status == 5)
				{
					return -1;
				}
			}
			if (a.status == 5 && b.status != 5)
			{
				return 1;
			}
			if (a.taskID > b.taskID)
			{
				return 1;
			}
			if (a.taskID < b.taskID)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x0600D3C4 RID: 54212 RVA: 0x0034A3A0 File Offset: 0x003487A0
		private void _updateAllRewardStaus(int chidx)
		{
			List<MissionManager.SingleMissionInfo> list = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Chest, chidx);
			if (list != null && list.Count > 0)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = list[0];
				TaskStatus status = (TaskStatus)singleMissionInfo.status;
				if (status != TaskStatus.TASK_FINISHED)
				{
					if (status != TaskStatus.TASK_OVER)
					{
						this.mBind.GetSprite("close", ref this.mChapterRewardBoxStatus);
						this.mChapterRewardRed.CustomActive(false);
						this.mChapterReward.gameObject.SetActive(true);
						this.mChapterRewardText.text = "未达成";
						this.mCharpterRewardGray.enabled = true;
						this.mEffectRoot.SetActive(false);
						this.mEffectAnimate.DOKill();
						this.mEffectAnimate.isActive = false;
						this.mEffectAnimate.transform.localRotation = Quaternion.Euler(Vector3.zero);
					}
					else
					{
						this.mBind.GetSprite("open", ref this.mChapterRewardBoxStatus);
						this.mChapterRewardRed.CustomActive(false);
						this.mChapterReward.gameObject.SetActive(false);
						this.mEffectRoot.SetActive(false);
						this.mEffectAnimate.DOKill();
						this.mEffectAnimate.isActive = false;
						this.mEffectAnimate.transform.localRotation = Quaternion.Euler(Vector3.zero);
					}
				}
				else
				{
					this.mBind.GetSprite("close", ref this.mChapterRewardBoxStatus);
					this.mChapterReward.gameObject.SetActive(true);
					this.mChapterRewardText.text = "可领取";
					this.mCharpterRewardGray.enabled = false;
					this.mChapterRewardRed.CustomActive(true);
					this.mEffectRoot.SetActive(true);
					this.mEffectAnimate.transform.localRotation = Quaternion.Euler(Vector3.zero);
					this.mEffectAnimate.isActive = true;
					this.mEffectAnimate.DOPlay();
				}
			}
			else
			{
				this.mChapterRewardText.text = string.Empty;
				this.mCharpterRewardGray.enabled = true;
				if (list == null)
				{
					Logger.LogErrorFormat("[关卡宝箱] 总章节奖励未配置,allReward == null,chidx = {0}", new object[]
					{
						chidx
					});
				}
				else
				{
					Logger.LogErrorFormat("[关卡宝箱] 总章节奖励未配置,allReward != null,allReward.Count = {0},chidx = {1}", new object[]
					{
						list.Count,
						chidx
					});
				}
			}
		}

		// Token: 0x0600D3C5 RID: 54213 RVA: 0x0034A5EC File Offset: 0x003489EC
		private void _updateSingleItemStatus(ChapterRewardFrame.Node node)
		{
			ComCommonBind bind = node.bind;
			if (null != bind)
			{
				Button com = bind.GetCom<Button>("getbutton");
				UIGray com2 = bind.GetCom<UIGray>("gray");
				GameObject gameObject = bind.GetGameObject("complete");
				GameObject gameObject2 = bind.GetGameObject("unfinish");
				Button com3 = bind.GetCom<Button>("GoChapter");
				TaskStatus status = (TaskStatus)node.info.status;
				if (status != TaskStatus.TASK_FINISHED)
				{
					if (status != TaskStatus.TASK_OVER)
					{
						com.gameObject.CustomActive(false);
						gameObject.CustomActive(false);
						com3.CustomActive(false);
						gameObject2.CustomActive(false);
						MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)node.info.taskID, string.Empty, string.Empty);
						if (tableItem != null && tableItem.DungeonTableID != 0)
						{
							if (ChapterUtility.GetDungeonState(tableItem.DungeonTableID) == ComChapterDungeonUnit.eState.Locked)
							{
								gameObject2.CustomActive(true);
							}
							else
							{
								com3.CustomActive(true);
							}
						}
					}
					else
					{
						com.gameObject.SetActive(false);
						gameObject.CustomActive(true);
						gameObject2.CustomActive(false);
						com3.CustomActive(false);
					}
				}
				else
				{
					com.gameObject.CustomActive(true);
					com3.CustomActive(false);
				}
			}
		}

		// Token: 0x0600D3C6 RID: 54214 RVA: 0x0034A738 File Offset: 0x00348B38
		private void _updateProcess(int chidx)
		{
			KeyValuePair<int, int> chapterRewardByChapterIdx = ChapterUtility.GetChapterRewardByChapterIdx(chidx);
			int key = chapterRewardByChapterIdx.Key;
			int value = chapterRewardByChapterIdx.Value;
			this.mSumcount.text = string.Format("{0}", value);
			this.mFinishcount.text = string.Format("{0}", key);
			this.mScoreCount.text = key.ToString();
			this.maxSCount = value;
			if (value <= 0)
			{
				this.mProcess.value = 1f;
			}
			else
			{
				this.mProcess.value = (float)key * 1f / (float)value;
			}
		}

		// Token: 0x0600D3C7 RID: 54215 RVA: 0x0034A7E4 File Offset: 0x00348BE4
		private void _initAllReward(int chid)
		{
			List<MissionManager.SingleMissionInfo> list = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Chest, chid);
			for (int i = 0; i < this.rewardBoxArr.Length; i++)
			{
				this.rewardBoxArr[i].CustomActive(false);
			}
			for (int j = 0; j < list.Count; j++)
			{
				uint taskID = list[j].taskID;
				if (j < this.rewardBoxArr.Length)
				{
					int num = 3 - (list.Count - (j + 1)) - 1;
					List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(list[j].missionItem.ID, -1);
					if (missionAwards.Count > 0)
					{
						this.rewardBoxArr[num].CustomActive(true);
						ComCommonBind component = this.rewardBoxArr[num].GetComponent<ComCommonBind>();
						if (!(component == null))
						{
							GameObject gameObject = component.GetGameObject("itemRoot");
							Button mItemBtn = component.GetCom<Button>("itemBtn");
							GameObject mFinishImage = component.GetGameObject("finishImage");
							GameObject mEffectRoot = component.GetGameObject("effectRoot");
							Text com = component.GetCom<Text>("Score");
							mItemBtn.onClick.RemoveAllListeners();
							mItemBtn.onClick.AddListener(delegate()
							{
								DataManager<MissionManager>.GetInstance().sendCmdSubmitTask(taskID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
								mItemBtn.CustomActive(false);
								mEffectRoot.CustomActive(false);
								mFinishImage.CustomActive(true);
							});
							mItemBtn.CustomActive(false);
							mFinishImage.CustomActive(false);
							mEffectRoot.CustomActive(false);
							TaskStatus status = (TaskStatus)list[j].status;
							if (status != TaskStatus.TASK_FINISHED)
							{
								if (status == TaskStatus.TASK_OVER)
								{
									mFinishImage.CustomActive(true);
								}
							}
							else
							{
								mItemBtn.CustomActive(true);
								mEffectRoot.CustomActive(true);
							}
							if (num + 1 == 3)
							{
								com.text = this.maxSCount.ToString();
							}
							else
							{
								com.text = (this.maxSCount / 3 * (num + 1)).ToString();
							}
							ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
							if (comItem == null)
							{
								comItem = base.CreateComItem(gameObject);
							}
							ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(missionAwards[0].ID, 100, 0);
							if (ItemDetailData == null)
							{
								return;
							}
							int num2 = missionAwards[0].Num;
							if (num2 > 10000 && num2 % 10000 == 0)
							{
								ItemDetailData.Count = 0;
								string tempStrCount = (num2 / 10000).ToString();
								comItem.SetCountFormatter((ComItem var) => tempStrCount + "万");
							}
							else
							{
								ItemDetailData.Count = missionAwards[0].Num;
								comItem.SetCountFormatter(null);
							}
							comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
							{
								this._OnShowTips(ItemDetailData);
							});
						}
					}
				}
			}
			if (list != null && list.Count > 0)
			{
				List<AwardItemData> missionAwards2 = DataManager<MissionManager>.GetInstance().GetMissionAwards(list[0].missionItem.ID, -1);
				List<ComItemList.Items> list2 = new List<ComItemList.Items>();
				for (int k = 0; k < missionAwards2.Count; k++)
				{
					list2.Add(new ComItemList.Items
					{
						id = missionAwards2[k].ID,
						count = (uint)missionAwards2[k].Num
					});
				}
				this.mAllreward.SetItems(list2.ToArray());
			}
		}

		// Token: 0x0600D3C8 RID: 54216 RVA: 0x0034ABC9 File Offset: 0x00348FC9
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x04007C05 RID: 31749
		private List<int> chapterIDList = new List<int>();

		// Token: 0x04007C06 RID: 31750
		private Toggle[] chapterToggleList = new Toggle[0];

		// Token: 0x04007C07 RID: 31751
		private GameObject[] rewardBoxArr = new GameObject[3];

		// Token: 0x04007C08 RID: 31752
		private int curSelectToggle;

		// Token: 0x04007C09 RID: 31753
		private int maxSCount;

		// Token: 0x04007C0A RID: 31754
		private int defaultChapterIdx = 1;

		// Token: 0x04007C0B RID: 31755
		private List<MissionManager.SingleMissionInfo> allRewardList;

		// Token: 0x04007C0C RID: 31756
		private Button mClose;

		// Token: 0x04007C0D RID: 31757
		private Text mFinishcount;

		// Token: 0x04007C0E RID: 31758
		private Text mSumcount;

		// Token: 0x04007C0F RID: 31759
		private GameObject mContent;

		// Token: 0x04007C10 RID: 31760
		private Slider mProcess;

		// Token: 0x04007C11 RID: 31761
		private Text mChapterNum;

		// Token: 0x04007C12 RID: 31762
		private ComUIListScript mToggleUIList;

		// Token: 0x04007C13 RID: 31763
		private GameObject mChapterSelectRewardBox1;

		// Token: 0x04007C14 RID: 31764
		private GameObject mChapterSelectRewardBox2;

		// Token: 0x04007C15 RID: 31765
		private GameObject mChapterSelectRewardBox3;

		// Token: 0x04007C16 RID: 31766
		private Text mScoreCount;

		// Token: 0x04007C17 RID: 31767
		private ComUIListScript mTaskItemComUIList;

		// Token: 0x04007C18 RID: 31768
		private Button mChapterReward;

		// Token: 0x04007C19 RID: 31769
		private Text mChapterRewardText;

		// Token: 0x04007C1A RID: 31770
		private UIGray mCharpterRewardGray;

		// Token: 0x04007C1B RID: 31771
		private GameObject mChapterRewardRoot;

		// Token: 0x04007C1C RID: 31772
		private Image mChapterRewardBoxStatus;

		// Token: 0x04007C1D RID: 31773
		private Button mChapterRewardBox;

		// Token: 0x04007C1E RID: 31774
		private Button mChapterRewardBoxBg;

		// Token: 0x04007C1F RID: 31775
		private Button mChapterRewardBoxClose;

		// Token: 0x04007C20 RID: 31776
		private GameObject mChapterRewardRed;

		// Token: 0x04007C21 RID: 31777
		private GameObject mEffectRoot;

		// Token: 0x04007C22 RID: 31778
		private DOTweenAnimation mEffectAnimate;

		// Token: 0x04007C23 RID: 31779
		private ComItemList mAllreward;

		// Token: 0x04007C24 RID: 31780
		private ScrollRect mTaskScroll;

		// Token: 0x04007C25 RID: 31781
		private int mCurSelectChapterIdx = 1;

		// Token: 0x02001535 RID: 5429
		private class Node : IComparable<ChapterRewardFrame.Node>
		{
			// Token: 0x0600D3CE RID: 54222 RVA: 0x0034ACF2 File Offset: 0x003490F2
			public int CompareTo(ChapterRewardFrame.Node other)
			{
				return this.info.CompareTo(other.info);
			}

			// Token: 0x04007C27 RID: 31783
			public ComCommonBind bind;

			// Token: 0x04007C28 RID: 31784
			public MissionManager.SingleMissionInfo info;
		}

		// Token: 0x02001536 RID: 5430
		private class SelectNode
		{
			// Token: 0x04007C29 RID: 31785
			public int chapterID;

			// Token: 0x04007C2A RID: 31786
			public ComCommonBind bind;
		}
	}
}
