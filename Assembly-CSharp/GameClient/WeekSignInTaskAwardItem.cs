using System;
using DG.Tweening;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A97 RID: 6807
	public class WeekSignInTaskAwardItem : MonoBehaviour
	{
		// Token: 0x06010B5B RID: 68443 RVA: 0x004BD45C File Offset: 0x004BB85C
		private void Awake()
		{
			this.BindComEvents();
		}

		// Token: 0x06010B5C RID: 68444 RVA: 0x004BD464 File Offset: 0x004BB864
		private void OnDestroy()
		{
			this.UnBindComEvents();
			this.ClearData();
		}

		// Token: 0x06010B5D RID: 68445 RVA: 0x004BD472 File Offset: 0x004BB872
		private void OnEnable()
		{
			this.BindUiEvents();
		}

		// Token: 0x06010B5E RID: 68446 RVA: 0x004BD47A File Offset: 0x004BB87A
		private void OnDisable()
		{
			this.UnBindUiEvents();
			this._boxOpenType = BoxOpenType.None;
		}

		// Token: 0x06010B5F RID: 68447 RVA: 0x004BD48C File Offset: 0x004BB88C
		private void BindUiEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnOpActTaskUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnOpActTaskDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncSceneWeekSignBoxNotify, new ClientEventSystem.UIEventHandler(this.OnSyncSceneWeekSignBoxNotify));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnBoxOpenFinished, new ClientEventSystem.UIEventHandler(this.OnBoxOpenFinished));
		}

		// Token: 0x06010B60 RID: 68448 RVA: 0x004BD508 File Offset: 0x004BB908
		private void UnBindUiEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnOpActTaskUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnOpActTaskDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncSceneWeekSignBoxNotify, new ClientEventSystem.UIEventHandler(this.OnSyncSceneWeekSignBoxNotify));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnBoxOpenFinished, new ClientEventSystem.UIEventHandler(this.OnBoxOpenFinished));
		}

		// Token: 0x06010B61 RID: 68449 RVA: 0x004BD581 File Offset: 0x004BB981
		private void BindComEvents()
		{
			if (this.taskAwardButton != null)
			{
				this.taskAwardButton.onClick.RemoveAllListeners();
				this.taskAwardButton.onClick.AddListener(new UnityAction(this.OnTaskAwardButtonClick));
			}
		}

		// Token: 0x06010B62 RID: 68450 RVA: 0x004BD5C0 File Offset: 0x004BB9C0
		private void UnBindComEvents()
		{
			if (this.taskAwardButton != null)
			{
				this.taskAwardButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06010B63 RID: 68451 RVA: 0x004BD5E3 File Offset: 0x004BB9E3
		private void ClearData()
		{
			this._opActTaskData = null;
			this._opActTask = null;
			this._commonNewItem = null;
			this._weekSignBox = null;
			this._opActTaskId = 0U;
			this._opActTaskDes = null;
			this._boxOpenType = BoxOpenType.None;
		}

		// Token: 0x06010B64 RID: 68452 RVA: 0x004BD618 File Offset: 0x004BBA18
		public void InitItem(WeekSignInType weekSignInType, uint opActId, OpActTaskData opActTaskData)
		{
			this._weekSignInType = weekSignInType;
			this._opActId = opActId;
			this._opActTaskData = opActTaskData;
			if (this._opActTaskData == null)
			{
				Logger.LogErrorFormat("OpActTaskData is null ", new object[0]);
				return;
			}
			this._opActTaskId = this._opActTaskData.dataid;
			this._opActTask = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(this._opActTaskId);
			if (this._opActTask == null)
			{
				Logger.LogErrorFormat("OpActTask is null", new object[0]);
				return;
			}
			this._opActTaskDes = DataManager<ActivityDataManager>.GetInstance().GetTaskDesByTaskId(this._opActTaskId, this._opActId);
			this.InitTaskAwardItemBoxImage();
			this.UpdateItemView();
		}

		// Token: 0x06010B65 RID: 68453 RVA: 0x004BD6C4 File Offset: 0x004BBAC4
		private void InitTaskAwardItemBoxImage()
		{
			if (this.taskAwardBoxImage != null)
			{
				if (this._weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
				{
					ETCImageLoader.LoadSprite(ref this.taskAwardBoxImage, "UI/Image/Icon/Icon_Jar/item_jar_01.png:item_jar_01", true);
				}
				else
				{
					ETCImageLoader.LoadSprite(ref this.taskAwardBoxImage, "UI/Image/Icon/Icon_Jar/item_jar_05.png:item_jar_05", true);
				}
			}
		}

		// Token: 0x06010B66 RID: 68454 RVA: 0x004BD717 File Offset: 0x004BBB17
		public void OnItemRecycle()
		{
			this.ClearData();
		}

		// Token: 0x06010B67 RID: 68455 RVA: 0x004BD71F File Offset: 0x004BBB1F
		public void OnItemUpdate()
		{
			if (this._opActTaskData == null)
			{
				return;
			}
			this.UpdateItemByChanged();
		}

		// Token: 0x06010B68 RID: 68456 RVA: 0x004BD734 File Offset: 0x004BBB34
		private void UpdateItemView()
		{
			OpActTaskState state = (OpActTaskState)this._opActTask.state;
			if (state != OpActTaskState.OATS_OVER)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					this._taskAwardState = WeekSignInAwardState.UnFinished;
					this.UpdateUnFinishedItemView();
				}
				else
				{
					this._taskAwardState = WeekSignInAwardState.Finished;
					this.UpdateFinishedItemView();
				}
			}
			else
			{
				this._taskAwardState = WeekSignInAwardState.Received;
				this.UpdateReceivedItemView();
			}
		}

		// Token: 0x06010B69 RID: 68457 RVA: 0x004BD798 File Offset: 0x004BBB98
		private void UpdateTaskAwardDescription()
		{
			if (this.taskAwardDescription != null && !string.IsNullOrEmpty(this._opActTaskDes))
			{
				string text = string.Format(this._opActTaskDes, this._opActTask.curNum, this._opActTaskData.completeNum);
				this.taskAwardDescription.text = text;
			}
		}

		// Token: 0x06010B6A RID: 68458 RVA: 0x004BD800 File Offset: 0x004BBC00
		private void UpdateReceivedItemView()
		{
			this.UpdateAwardItemFlag(true);
			this.UpdateBoxFinishTweenAnimation(false);
			this.UpdateFinishFlag(false);
			this.UpdateReceivedFlag(true);
			this.UpdateTaskAwardDescription();
			this._weekSignBox = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignBoxByWeekSignInType(this._weekSignInType, (int)this._opActTaskId);
			this.UpdateReceivedItemBox();
		}

		// Token: 0x06010B6B RID: 68459 RVA: 0x004BD854 File Offset: 0x004BBC54
		private void UpdateAwardItemFlag(bool flag)
		{
			if (this.itemName != null)
			{
				this.itemName.gameObject.CustomActive(flag);
			}
			if (this.itemRoot != null)
			{
				this.itemRoot.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x06010B6C RID: 68460 RVA: 0x004BD8A8 File Offset: 0x004BBCA8
		private void UpdateReceivedItemBox()
		{
			if (this._weekSignBox != null && this._weekSignBox.itemVec.Length > 0)
			{
				ItemReward itemReward = this._weekSignBox.itemVec[0];
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)itemReward.id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string itemColorName = CommonUtility.GetItemColorName(tableItem);
					if (this.itemName != null)
					{
						this.itemName.text = itemColorName;
					}
				}
				if (this.itemRoot != null)
				{
					this._commonNewItem = this.itemRoot.GetComponentInChildren<CommonNewItem>();
					if (this._commonNewItem == null)
					{
						this._commonNewItem = CommonUtility.CreateCommonNewItem(this.itemRoot);
					}
					if (this._commonNewItem != null)
					{
						CommonNewItemDataModel dataModel = new CommonNewItemDataModel
						{
							ItemId = (int)itemReward.id,
							ItemCount = (int)itemReward.num
						};
						this._commonNewItem.InitItem(dataModel);
					}
				}
			}
		}

		// Token: 0x06010B6D RID: 68461 RVA: 0x004BD9AB File Offset: 0x004BBDAB
		private void UpdateFinishedItemView()
		{
			this.UpdateAwardItemFlag(false);
			this.UpdateReceivedFlag(true);
			this.UpdateBoxFinishTweenAnimation(true);
			this.UpdateFinishFlag(true);
			this.UpdateTaskAwardDescription();
		}

		// Token: 0x06010B6E RID: 68462 RVA: 0x004BD9D0 File Offset: 0x004BBDD0
		private void UpdateUnFinishedItemView()
		{
			this.UpdateAwardItemFlag(false);
			this.UpdateReceivedFlag(false);
			this.UpdateFinishFlag(true);
			this.UpdateBoxFinishTweenAnimation(false);
			if (this.taskAwardFinishFlag != null)
			{
				this.taskAwardFinishFlag.gameObject.CustomActive(false);
			}
			this.UpdateTaskAwardDescription();
		}

		// Token: 0x06010B6F RID: 68463 RVA: 0x004BDA21 File Offset: 0x004BBE21
		private void UpdateReceivedFlag(bool flag)
		{
			if (this.taskAwardReceivedFlag != null)
			{
				this.taskAwardReceivedFlag.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x06010B70 RID: 68464 RVA: 0x004BDA48 File Offset: 0x004BBE48
		private void UpdateFinishFlag(bool flag)
		{
			if (this.taskAwardFinishFlag != null)
			{
				this.taskAwardFinishFlag.CustomActive(flag);
			}
			if (this.taskAwardBoxImage != null)
			{
				this.taskAwardBoxImage.CustomActive(flag);
			}
			if (this.taskAwardButton != null)
			{
				this.taskAwardButton.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x06010B71 RID: 68465 RVA: 0x004BDAB1 File Offset: 0x004BBEB1
		private void OnBoxOpenFinished(UIEvent uiEvent)
		{
			if (this._boxOpenType != BoxOpenType.Opening)
			{
				return;
			}
			this._boxOpenType = BoxOpenType.Finished;
			this.UpdateItemByChanged();
		}

		// Token: 0x06010B72 RID: 68466 RVA: 0x004BDAD0 File Offset: 0x004BBED0
		private void OnSyncSceneWeekSignBoxNotify(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			WeekSignInType weekSignInType = (WeekSignInType)uiEvent.Param1;
			if (weekSignInType != this._weekSignInType)
			{
				return;
			}
			WeekSignBox weekSignBoxByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignBoxByWeekSignInType(this._weekSignInType, (int)this._opActTaskId);
			if (weekSignBoxByWeekSignInType != null)
			{
				if (this._boxOpenType == BoxOpenType.Preparing)
				{
					if (weekSignBoxByWeekSignInType.itemVec != null && weekSignBoxByWeekSignInType.itemVec.Length > 0)
					{
						this._boxOpenType = BoxOpenType.Opening;
						WeekSignInUtility.OpenBoxOpenFrame(this._weekSignInType, (int)weekSignBoxByWeekSignInType.itemVec[0].id, (int)weekSignBoxByWeekSignInType.itemVec[0].num);
						return;
					}
				}
				else if (this._boxOpenType == BoxOpenType.Opening)
				{
					return;
				}
				this._weekSignBox = weekSignBoxByWeekSignInType;
				this.UpdateReceivedItemBox();
			}
		}

		// Token: 0x06010B73 RID: 68467 RVA: 0x004BDB98 File Offset: 0x004BBF98
		private void OnOpActTaskUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			LimitTimeActivityTaskUpdateData limitTimeActivityTaskUpdateData = (LimitTimeActivityTaskUpdateData)uiEvent.Param1;
			if (limitTimeActivityTaskUpdateData == null)
			{
				return;
			}
			if ((long)limitTimeActivityTaskUpdateData.ActivityId != (long)((ulong)this._opActId) || (long)limitTimeActivityTaskUpdateData.TaskId != (long)((ulong)this._opActTaskId))
			{
				return;
			}
			if (this._boxOpenType == BoxOpenType.Preparing || this._boxOpenType == BoxOpenType.Opening)
			{
				return;
			}
			this.UpdateItemByChanged();
		}

		// Token: 0x06010B74 RID: 68468 RVA: 0x004BDC10 File Offset: 0x004BC010
		private void OnOpActTaskDataUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			LimitTimeActivityTaskUpdateData limitTimeActivityTaskUpdateData = (LimitTimeActivityTaskUpdateData)uiEvent.Param1;
			if (limitTimeActivityTaskUpdateData == null)
			{
				return;
			}
			if ((long)limitTimeActivityTaskUpdateData.ActivityId != (long)((ulong)this._opActId) || (long)limitTimeActivityTaskUpdateData.TaskId != (long)((ulong)this._opActTaskId))
			{
				return;
			}
			if (this._boxOpenType == BoxOpenType.Preparing || this._boxOpenType == BoxOpenType.Opening)
			{
				return;
			}
			this.UpdateItemByChanged();
		}

		// Token: 0x06010B75 RID: 68469 RVA: 0x004BDC88 File Offset: 0x004BC088
		private void UpdateItemByChanged()
		{
			OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(this._opActTaskId);
			if (limitTimeTaskData == null)
			{
				return;
			}
			this._opActTask = limitTimeTaskData;
			this.UpdateItemView();
		}

		// Token: 0x06010B76 RID: 68470 RVA: 0x004BDCBC File Offset: 0x004BC0BC
		private void OnTaskAwardButtonClick()
		{
			if (this._opActTaskData == null)
			{
				return;
			}
			if (this._opActTask == null)
			{
				return;
			}
			if (this._taskAwardState == WeekSignInAwardState.UnFinished)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("week_sing_in_task_unfinished"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._taskAwardState == WeekSignInAwardState.Finished)
			{
				if (this._boxOpenType == BoxOpenType.None)
				{
					this._boxOpenType = BoxOpenType.Preparing;
				}
				DataManager<WeekSignInDataManager>.GetInstance().OnSendRequestOnTakeActTask(this._opActId, this._opActTaskId);
			}
		}

		// Token: 0x06010B77 RID: 68471 RVA: 0x004BDD33 File Offset: 0x004BC133
		private void UpdateBoxFinishTweenAnimation(bool flag)
		{
			if (this.boxTweenAnimation != null)
			{
				if (flag)
				{
					TweenExtensions.Restart(this.boxTweenAnimation.tween, true);
				}
				else
				{
					TweenExtensions.Pause<Tween>(this.boxTweenAnimation.tween);
				}
			}
		}

		// Token: 0x0400AADF RID: 43743
		private WeekSignInType _weekSignInType;

		// Token: 0x0400AAE0 RID: 43744
		private OpActTaskData _opActTaskData;

		// Token: 0x0400AAE1 RID: 43745
		private OpActTask _opActTask;

		// Token: 0x0400AAE2 RID: 43746
		private uint _opActId;

		// Token: 0x0400AAE3 RID: 43747
		private uint _opActTaskId;

		// Token: 0x0400AAE4 RID: 43748
		private CommonNewItem _commonNewItem;

		// Token: 0x0400AAE5 RID: 43749
		private WeekSignBox _weekSignBox;

		// Token: 0x0400AAE6 RID: 43750
		private WeekSignInAwardState _taskAwardState;

		// Token: 0x0400AAE7 RID: 43751
		private string _opActTaskDes;

		// Token: 0x0400AAE8 RID: 43752
		private BoxOpenType _boxOpenType;

		// Token: 0x0400AAE9 RID: 43753
		[Space(10f)]
		[Header("item")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400AAEA RID: 43754
		[SerializeField]
		private Text itemName;

		// Token: 0x0400AAEB RID: 43755
		[Space(10f)]
		[Header("Description")]
		[Space(10f)]
		[SerializeField]
		private Text taskAwardDescription;

		// Token: 0x0400AAEC RID: 43756
		[SerializeField]
		private GameObject taskAwardReceivedFlag;

		// Token: 0x0400AAED RID: 43757
		[Space(10f)]
		[Header("Flag")]
		[Space(10f)]
		[SerializeField]
		private GameObject taskAwardFinishFlag;

		// Token: 0x0400AAEE RID: 43758
		[SerializeField]
		private Image taskAwardBoxImage;

		// Token: 0x0400AAEF RID: 43759
		[SerializeField]
		private Button taskAwardButton;

		// Token: 0x0400AAF0 RID: 43760
		[SerializeField]
		private DOTweenAnimation boxTweenAnimation;
	}
}
