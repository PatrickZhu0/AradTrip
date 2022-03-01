using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018B2 RID: 6322
	public class SpringChallengeActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F718 RID: 63256 RVA: 0x0042D580 File Offset: 0x0042B980
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mModel = model;
			this.scoreActivityId = model.Param;
			this.mTimeTxt.SafeSetText(string.Format("{0}", Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime)));
			this.mRuleTxt.SafeSetText(model.RuleDesc.Replace('|', '\n'));
			this.mNum.SafeSetText(DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.TOTAL_SPRING_SCORE).ToString());
			this.mIntegrationBtn.SafeAddOnClickListener(new UnityAction(this._OnIntegrationBtnClick));
			this._InitItems(model);
		}

		// Token: 0x0600F719 RID: 63257 RVA: 0x0042D628 File Offset: 0x0042BA28
		public void Close()
		{
			this.Dispose();
			if (this.mUIList != null)
			{
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F71A RID: 63258 RVA: 0x0042D6A5 File Offset: 0x0042BAA5
		public void Dispose()
		{
			this.mIntegrationBtn.SafeRemoveOnClickListener(new UnityAction(this._OnIntegrationBtnClick));
		}

		// Token: 0x0600F71B RID: 63259 RVA: 0x0042D6BE File Offset: 0x0042BABE
		public void Hide()
		{
			base.gameObject.SetActive(false);
		}

		// Token: 0x0600F71C RID: 63260 RVA: 0x0042D6CC File Offset: 0x0042BACC
		private void _InitItems(ILimitTimeActivityModel data)
		{
			if (this.mUIList != null)
			{
				this.mUIList.Initialize();
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.mUIList.SetElementAmount(data.TaskDatas.Count);
		}

		// Token: 0x0600F71D RID: 63261 RVA: 0x0042D759 File Offset: 0x0042BB59
		private SpringChallengeItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<SpringChallengeItem>();
		}

		// Token: 0x0600F71E RID: 63262 RVA: 0x0042D764 File Offset: 0x0042BB64
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			SpringChallengeItem springChallengeItem = item.gameObjectBindScript as SpringChallengeItem;
			if (springChallengeItem != null && item.m_index >= 0 && item.m_index < this.mModel.TaskDatas.Count)
			{
				springChallengeItem.Init(this.mModel.TaskDatas[item.m_index].DataId, this.mModel.Id, this.mModel.TaskDatas[item.m_index], null);
				springChallengeItem.SetBackground(item.m_index);
			}
		}

		// Token: 0x0600F71F RID: 63263 RVA: 0x0042D800 File Offset: 0x0042BC00
		private void _OnIntegrationBtnClick()
		{
			LimitTimeActivityFrame limitTimeActivityFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(LimitTimeActivityFrame)) as LimitTimeActivityFrame;
			if (limitTimeActivityFrame != null)
			{
				limitTimeActivityFrame.OpenFrameByActivityId(this.scoreActivityId);
			}
		}

		// Token: 0x0600F720 RID: 63264 RVA: 0x0042D839 File Offset: 0x0042BC39
		public void Show()
		{
		}

		// Token: 0x0600F721 RID: 63265 RVA: 0x0042D83B File Offset: 0x0042BC3B
		public void UpdateData(ILimitTimeActivityModel data)
		{
		}

		// Token: 0x040097F3 RID: 38899
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x040097F4 RID: 38900
		[SerializeField]
		private Text mRuleTxt;

		// Token: 0x040097F5 RID: 38901
		[SerializeField]
		private Button mIntegrationBtn;

		// Token: 0x040097F6 RID: 38902
		[SerializeField]
		private ComUIListScript mUIList;

		// Token: 0x040097F7 RID: 38903
		[SerializeField]
		private Text mNum;

		// Token: 0x040097F8 RID: 38904
		private uint scoreActivityId;

		// Token: 0x040097F9 RID: 38905
		private ILimitTimeActivityModel mModel;
	}
}
