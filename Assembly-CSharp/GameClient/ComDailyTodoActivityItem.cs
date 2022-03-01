using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200159F RID: 5535
	public class ComDailyTodoActivityItem : MonoBehaviour
	{
		// Token: 0x0600D87E RID: 55422 RVA: 0x00362B93 File Offset: 0x00360F93
		private void Awake()
		{
			if (this.gotoBtn)
			{
				this.gotoBtn.onClick.AddListener(new UnityAction(this._OnGotoBtnClick));
			}
			this._InitView();
		}

		// Token: 0x0600D87F RID: 55423 RVA: 0x00362BC7 File Offset: 0x00360FC7
		private void OnDestroy()
		{
			if (this.gotoBtn)
			{
				this.gotoBtn.onClick.RemoveListener(new UnityAction(this._OnGotoBtnClick));
			}
			this._ClearView();
		}

		// Token: 0x0600D880 RID: 55424 RVA: 0x00362BFC File Offset: 0x00360FFC
		private void _InitView()
		{
			if (this.tempRewardItems == null)
			{
				this.tempRewardItems = new List<ComDailyTodoActivityRewardItem>();
			}
			if (this.rewardScroll != null)
			{
				if (!this.rewardScroll.IsInitialised())
				{
					this.rewardScroll.Initialize();
				}
				ComUIListScript comUIListScript = this.rewardScroll;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnActivityDropItemBind));
				ComUIListScript comUIListScript2 = this.rewardScroll;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnActivityDropItemVisable));
				ComUIListScript comUIListScript3 = this.rewardScroll;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnActivityDropItemRecycle));
			}
		}

		// Token: 0x0600D881 RID: 55425 RVA: 0x00362CC0 File Offset: 0x003610C0
		private void _ClearView()
		{
			if (this.tempRewardItems != null)
			{
				for (int i = 0; i < this.tempRewardItems.Count; i++)
				{
					ComDailyTodoActivityRewardItem comDailyTodoActivityRewardItem = this.tempRewardItems[i];
					if (comDailyTodoActivityRewardItem != null)
					{
						comDailyTodoActivityRewardItem.UnInit();
					}
				}
			}
			if (this.rewardScroll != null)
			{
				ComUIListScript comUIListScript = this.rewardScroll;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnActivityDropItemBind));
				ComUIListScript comUIListScript2 = this.rewardScroll;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnActivityDropItemVisable));
				ComUIListScript comUIListScript3 = this.rewardScroll;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnActivityDropItemRecycle));
				this.rewardScroll.UnInitialize();
			}
			this.tempModel = null;
		}

		// Token: 0x0600D882 RID: 55426 RVA: 0x00362DAB File Offset: 0x003611AB
		private void _OnGotoBtnClick()
		{
			if (this.tempModel != null && this.tempModel.gotoHandler != null)
			{
				this.tempModel.gotoHandler(this.tempModel);
			}
		}

		// Token: 0x0600D883 RID: 55427 RVA: 0x00362DDE File Offset: 0x003611DE
		private void _SetName(string name)
		{
			if (this.nameText)
			{
				this.nameText.text = name;
			}
		}

		// Token: 0x0600D884 RID: 55428 RVA: 0x00362DFC File Offset: 0x003611FC
		private void _SetBackground(string imgPath)
		{
			if (!string.IsNullOrEmpty(imgPath) && this.backgroundImg)
			{
				this.backgroundImg.color = Color.white;
				if (!ETCImageLoader.LoadSprite(ref this.backgroundImg, imgPath, true))
				{
					Logger.LogErrorFormat("[ComDailyTodoActivityItem] - SetBackground can not load img : {0}", new object[]
					{
						imgPath
					});
				}
			}
		}

		// Token: 0x0600D885 RID: 55429 RVA: 0x00362E5C File Offset: 0x0036125C
		private void _SetTime(string time)
		{
			if (this.timeText)
			{
				this.timeText.text = time;
			}
		}

		// Token: 0x0600D886 RID: 55430 RVA: 0x00362E7C File Offset: 0x0036127C
		private void _SetActivityState(eActivityDungeonState state)
		{
			if (state == eActivityDungeonState.Start)
			{
				this.gotoBtn.CustomActive(true);
				this.endTagGo.CustomActive(false);
				this.notStartRagGo.CustomActive(false);
			}
			else if (state == eActivityDungeonState.End)
			{
				this.gotoBtn.CustomActive(false);
				this.endTagGo.CustomActive(true);
				this.notStartRagGo.CustomActive(false);
			}
			else
			{
				this.gotoBtn.CustomActive(false);
				this.endTagGo.CustomActive(false);
				this.notStartRagGo.CustomActive(true);
			}
		}

		// Token: 0x0600D887 RID: 55431 RVA: 0x00362F0C File Offset: 0x0036130C
		private void _SetActivityRewardItems()
		{
			if (this.rewardScroll != null && this.tempModel.rewardItemIds != null)
			{
				this.rewardScroll.SetElementAmount(this.tempModel.rewardItemIds.Count);
			}
		}

		// Token: 0x0600D888 RID: 55432 RVA: 0x00362F4A File Offset: 0x0036134A
		private ComDailyTodoActivityRewardItem _OnActivityDropItemBind(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.GetComponent<ComDailyTodoActivityRewardItem>();
		}

		// Token: 0x0600D889 RID: 55433 RVA: 0x00362F60 File Offset: 0x00361360
		private void _OnActivityDropItemVisable(ComUIListElementScript item)
		{
			if (item == null || this.tempModel == null)
			{
				return;
			}
			if (this.tempModel.rewardItemIds == null || this.tempModel.rewardItemIds.Count <= 0)
			{
				return;
			}
			int index = item.m_index;
			if (index < 0 || index >= this.tempModel.rewardItemIds.Count)
			{
				return;
			}
			ComDailyTodoActivityRewardItem comDailyTodoActivityRewardItem = item.gameObjectBindScript as ComDailyTodoActivityRewardItem;
			if (comDailyTodoActivityRewardItem == null)
			{
				return;
			}
			comDailyTodoActivityRewardItem.Init(this.tempModel.rewardItemIds[index]);
			if (this.tempRewardItems != null && !this.tempRewardItems.Contains(comDailyTodoActivityRewardItem))
			{
				this.tempRewardItems.Add(comDailyTodoActivityRewardItem);
			}
		}

		// Token: 0x0600D88A RID: 55434 RVA: 0x0036302C File Offset: 0x0036142C
		private void _OnActivityDropItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ComDailyTodoActivityRewardItem comDailyTodoActivityRewardItem = item.gameObjectBindScript as ComDailyTodoActivityRewardItem;
			if (comDailyTodoActivityRewardItem != null)
			{
				comDailyTodoActivityRewardItem.UnInit();
			}
		}

		// Token: 0x0600D88B RID: 55435 RVA: 0x00363064 File Offset: 0x00361464
		public void RefreshView(DailyTodoActivity model)
		{
			if (model == null)
			{
				return;
			}
			this.tempModel = model;
			this._SetActivityState(model.activityDungeonState);
			this._SetTime(model.timeDesc);
			this._SetBackground(model.backgroundImgPath);
			this._SetName(model.name);
			this._SetActivityRewardItems();
		}

		// Token: 0x0600D88C RID: 55436 RVA: 0x003630B5 File Offset: 0x003614B5
		public void Recycle()
		{
			this._ClearView();
		}

		// Token: 0x04007F1F RID: 32543
		private List<ComDailyTodoActivityRewardItem> tempRewardItems;

		// Token: 0x04007F20 RID: 32544
		private DailyTodoActivity tempModel;

		// Token: 0x04007F21 RID: 32545
		[SerializeField]
		private Image backgroundImg;

		// Token: 0x04007F22 RID: 32546
		[SerializeField]
		private Text nameText;

		// Token: 0x04007F23 RID: 32547
		[SerializeField]
		private Text timeText;

		// Token: 0x04007F24 RID: 32548
		[SerializeField]
		private GameObject endTagGo;

		// Token: 0x04007F25 RID: 32549
		[SerializeField]
		private Button gotoBtn;

		// Token: 0x04007F26 RID: 32550
		[SerializeField]
		private GameObject notStartRagGo;

		// Token: 0x04007F27 RID: 32551
		[SerializeField]
		private ComUIListScript rewardScroll;
	}
}
