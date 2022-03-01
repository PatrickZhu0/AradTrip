using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200181E RID: 6174
	public class CourtesyPrivilegesActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F32C RID: 62252 RVA: 0x0041B764 File Offset: 0x00419B64
		private void Awake()
		{
			if (this.mGotoBtn != null)
			{
				this.mGotoBtn.onClick.RemoveAllListeners();
				this.mGotoBtn.onClick.AddListener(new UnityAction(this.OnGoToBtnClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
		}

		// Token: 0x0600F32D RID: 62253 RVA: 0x0041B7CC File Offset: 0x00419BCC
		private void OnDestroy()
		{
			if (this.mGotoBtn != null)
			{
				this.mGotoBtn.onClick.RemoveListener(new UnityAction(this.OnGoToBtnClick));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
			this.leaseItemTaskData = null;
			this.dailyLoginRewardList.Clear();
			this.numberDayRewardList.Clear();
			this.linkIds.Clear();
		}

		// Token: 0x0600F32E RID: 62254 RVA: 0x0041B84C File Offset: 0x00419C4C
		private void OnGoToBtnClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RecommendedDungeonsFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RecommendedDungeonsFrame>(null, false);
			}
			List<int> list = new List<int>();
			list.AddRange(this.linkIds);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RecommendedDungeonsFrame>(FrameLayer.Middle, list, string.Empty);
		}

		// Token: 0x0600F32F RID: 62255 RVA: 0x0041B899 File Offset: 0x00419C99
		private void OnCounterChanged(UIEvent uiEvent)
		{
			if (this.mCourtesyPrivilegeCardItem != null)
			{
				this.mCourtesyPrivilegeCardItem.UpdateCardIsActive();
			}
			this.UpdateState();
			this.UpdateGrandTotalDesc();
		}

		// Token: 0x0600F330 RID: 62256 RVA: 0x0041B8C4 File Offset: 0x00419CC4
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			if (model.ParamArray2.Length > 0)
			{
				this.totalDays = (int)model.ParamArray2[0];
			}
			if (this.mTime != null)
			{
				this.mTime.text = Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.Param);
			}
			this.linkIds.Clear();
			for (int i = 0; i < model.ParamArray.Length; i++)
			{
				int item = (int)model.ParamArray[i];
				this.linkIds.Add(item);
			}
			if (this.mCourtesyPrivilegeCardItem != null)
			{
				this.mCourtesyPrivilegeCardItem.InitItemInfo(model);
			}
			this.UpdateState();
			this.UpdateGrandTotalDesc();
			this.dailyLoginRewardList.Clear();
			this.numberDayRewardList.Clear();
			this.mItems.Clear();
			for (int j = 0; j < this.mModel.TaskDatas.Count; j++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = this.mModel.TaskDatas[j];
				if (limitTimeActivityTaskDataModel != null)
				{
					if (limitTimeActivityTaskDataModel.ParamNums.Count > 0)
					{
						int num = (int)limitTimeActivityTaskDataModel.ParamNums[0];
						if (num == 0)
						{
							this.dailyLoginRewardList.Add(limitTimeActivityTaskDataModel);
						}
						else if (num == 1)
						{
							this.numberDayRewardList.Add(limitTimeActivityTaskDataModel);
						}
						else if (num == 2)
						{
							this.leaseItemTaskData = limitTimeActivityTaskDataModel;
						}
					}
				}
			}
			this.InitLeaseItem(model);
			this.InitRewardItems(model, this.dailyLoginRewardList, this.mLoginRewardItemRoot);
			this.InitRewardItems(model, this.numberDayRewardList, this.mGrandTotalRewardItemRoot);
		}

		// Token: 0x0600F331 RID: 62257 RVA: 0x0041BA8C File Offset: 0x00419E8C
		private void InitLeaseItem(ILimitTimeActivityModel data)
		{
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mLeaseItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogErrorFormat("加载预制体失败，路径:" + this.mLeaseItemPath, new object[0]);
				return;
			}
			if (gameObject.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogErrorFormat("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + this.mLeaseItemPath, new object[0]);
				return;
			}
			GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
			gameObject2.transform.SetParent(this.mLeaseItemRoot, false);
			gameObject2.GetComponent<IActivityCommonItem>().Init(this.leaseItemTaskData.DataId, data.Id, this.leaseItemTaskData, this.mOnItemClick);
			this.mItems.Add(this.leaseItemTaskData.DataId, gameObject2.GetComponent<IActivityCommonItem>());
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F332 RID: 62258 RVA: 0x0041BB64 File Offset: 0x00419F64
		private void InitRewardItems(ILimitTimeActivityModel data, List<ILimitTimeActivityTaskDataModel> list, RectTransform parent)
		{
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mRewardItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogErrorFormat("加载预制体失败，路径:" + this.mRewardItemPath, new object[0]);
				return;
			}
			if (gameObject.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogErrorFormat("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + this.mRewardItemPath, new object[0]);
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = list[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					this.AddItem(gameObject, limitTimeActivityTaskDataModel, data, parent, false);
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F333 RID: 62259 RVA: 0x0041BC14 File Offset: 0x0041A014
		private void AddItem(GameObject go, ILimitTimeActivityTaskDataModel taskData, ILimitTimeActivityModel data, RectTransform goParent, bool bIsShowArrow = false)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(goParent, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(taskData.DataId, data.Id, taskData, this.mOnItemClick);
			(gameObject.GetComponent<IActivityCommonItem>() as CourtesyPrivilegesLoginRewardItem).OnSetArrowIsShow(bIsShowArrow);
			this.mItems.Add(taskData.DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x0600F334 RID: 62260 RVA: 0x0041BC80 File Offset: 0x0041A080
		private void UpdateState()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.GIFT_RIGHT_CARD);
			if (count == 1)
			{
				this.UpdateGotoBtnState(true);
			}
			else
			{
				this.UpdateGotoBtnState(false);
			}
		}

		// Token: 0x0600F335 RID: 62261 RVA: 0x0041BCB7 File Offset: 0x0041A0B7
		private void UpdateGotoBtnState(bool isFlag)
		{
			if (this.mGotoBtn != null)
			{
				this.mGotoBtn.enabled = isFlag;
			}
			if (this.mGotoGray != null)
			{
				this.mGotoGray.enabled = !isFlag;
			}
		}

		// Token: 0x0600F336 RID: 62262 RVA: 0x0041BCF8 File Offset: 0x0041A0F8
		private void UpdateGrandTotalDesc()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.OPACT_GIFT_RIGHT_CARD_LOGIN_TOTAL);
			if (this.mGrandTotalDesc != null)
			{
				this.mGrandTotalDesc.text = TR.Value("grand_total_desc", count, this.totalDays);
			}
		}

		// Token: 0x0600F337 RID: 62263 RVA: 0x0041BD4C File Offset: 0x0041A14C
		public void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					if (this.mItems.ContainsKey(limitTimeActivityTaskDataModel.DataId))
					{
						this.mItems[limitTimeActivityTaskDataModel.DataId].UpdateData(limitTimeActivityTaskDataModel);
					}
				}
			}
		}

		// Token: 0x0600F338 RID: 62264 RVA: 0x0041BDE6 File Offset: 0x0041A1E6
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F339 RID: 62265 RVA: 0x0041BDFC File Offset: 0x0041A1FC
		public void Dispose()
		{
			foreach (IActivityCommonItem activityCommonItem in this.mItems.Values)
			{
				activityCommonItem.Dispose();
			}
			this.mItems.Clear();
			this.mOnItemClick = null;
			this.mModel = null;
		}

		// Token: 0x0600F33A RID: 62266 RVA: 0x0041BE78 File Offset: 0x0041A278
		public void Hide()
		{
		}

		// Token: 0x0600F33B RID: 62267 RVA: 0x0041BE7A File Offset: 0x0041A27A
		public void Show()
		{
		}

		// Token: 0x040095AB RID: 38315
		[SerializeField]
		private RectTransform mLeaseItemRoot;

		// Token: 0x040095AC RID: 38316
		[SerializeField]
		private RectTransform mGrandTotalRewardItemRoot;

		// Token: 0x040095AD RID: 38317
		[SerializeField]
		private RectTransform mLoginRewardItemRoot;

		// Token: 0x040095AE RID: 38318
		[SerializeField]
		private Text mTime;

		// Token: 0x040095AF RID: 38319
		[SerializeField]
		private Button mGotoBtn;

		// Token: 0x040095B0 RID: 38320
		[SerializeField]
		private UIGray mGotoGray;

		// Token: 0x040095B1 RID: 38321
		[SerializeField]
		private Text mGrandTotalDesc;

		// Token: 0x040095B2 RID: 38322
		[SerializeField]
		private CourtesyPrivilegeCardItem mCourtesyPrivilegeCardItem;

		// Token: 0x040095B3 RID: 38323
		[SerializeField]
		private string mLeaseItemPath = "UIFlatten/Prefabs/OperateActivity/CourtesyPrivilegeActivity/CourtesyPrivilegesLeaseItem";

		// Token: 0x040095B4 RID: 38324
		[SerializeField]
		private string mRewardItemPath = "UIFlatten/Prefabs/OperateActivity/CourtesyPrivilegeActivity/CourtesyPrivilegesLoginRewardItem";

		// Token: 0x040095B5 RID: 38325
		protected readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();

		// Token: 0x040095B6 RID: 38326
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040095B7 RID: 38327
		protected ILimitTimeActivityModel mModel;

		// Token: 0x040095B8 RID: 38328
		private ILimitTimeActivityTaskDataModel leaseItemTaskData;

		// Token: 0x040095B9 RID: 38329
		private List<ILimitTimeActivityTaskDataModel> dailyLoginRewardList = new List<ILimitTimeActivityTaskDataModel>();

		// Token: 0x040095BA RID: 38330
		private List<ILimitTimeActivityTaskDataModel> numberDayRewardList = new List<ILimitTimeActivityTaskDataModel>();

		// Token: 0x040095BB RID: 38331
		private List<int> linkIds = new List<int>();

		// Token: 0x040095BC RID: 38332
		private int totalDays;
	}
}
