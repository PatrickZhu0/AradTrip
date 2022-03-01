using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001898 RID: 6296
	public class IntegrationChallengeActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F642 RID: 63042 RVA: 0x00427834 File Offset: 0x00425C34
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.scoreActivityId = model.Param;
			if (model.ParamArray2.Length > 0)
			{
				this.itemId = (int)model.ParamArray2[0];
			}
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(model.StartTime), this._TransTimeStampToStr(model.EndTime)));
			this.mRuleTxt.SafeSetText(model.RuleDesc.Replace('|', '\n'));
			this.mNum.SafeSetText(DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.TOTAL_CHALLENGE_SCORE).ToString());
			this.mIntegrationBtn.SafeAddOnClickListener(new UnityAction(this._OnIntegrationBtnClick));
			this.mGoBtn.SafeAddOnClickListener(new UnityAction(this._OnGoBtnClick));
			this._InitItems(model);
		}

		// Token: 0x0600F643 RID: 63043 RVA: 0x0042790D File Offset: 0x00425D0D
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F644 RID: 63044 RVA: 0x00427920 File Offset: 0x00425D20
		public void Dispose()
		{
			this.mIntegrationBtn.SafeRemoveOnClickListener(new UnityAction(this._OnIntegrationBtnClick));
			this.mGoBtn.SafeRemoveOnClickListener(new UnityAction(this._OnGoBtnClick));
		}

		// Token: 0x0600F645 RID: 63045 RVA: 0x00427950 File Offset: 0x00425D50
		public void Hide()
		{
			base.gameObject.SetActive(false);
		}

		// Token: 0x0600F646 RID: 63046 RVA: 0x00427960 File Offset: 0x00425D60
		private void _InitItems(ILimitTimeActivityModel data)
		{
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + data.ItemPath);
				return;
			}
			if (gameObject.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到IActivityCommonItem的脚本，预制体路径是:" + data.ItemPath);
				return;
			}
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (data.TaskDatas[i] != null)
				{
					this._AddItem(gameObject, i, data);
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F647 RID: 63047 RVA: 0x00427A0C File Offset: 0x00425E0C
		private void _AddItem(GameObject go, int id, ILimitTimeActivityModel data)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoot, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], null);
		}

		// Token: 0x0600F648 RID: 63048 RVA: 0x00427A64 File Offset: 0x00425E64
		private void _OnIntegrationBtnClick()
		{
			LimitTimeActivityFrame limitTimeActivityFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(LimitTimeActivityFrame)) as LimitTimeActivityFrame;
			if (limitTimeActivityFrame != null)
			{
				limitTimeActivityFrame.OpenFrameByActivityId(this.scoreActivityId);
			}
		}

		// Token: 0x0600F649 RID: 63049 RVA: 0x00427AA0 File Offset: 0x00425EA0
		private void _OnGoBtnClick()
		{
			ItemComeLink.OnLink(this.itemId, 0, true, null, false, false, false, null, TR.Value("IntegrationChallenge_GoChallengeTitle"));
		}

		// Token: 0x0600F64A RID: 63050 RVA: 0x00427ACC File Offset: 0x00425ECC
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}年{1}月{2}日{3:HH:mm}", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day,
				dateTime
			});
		}

		// Token: 0x0600F64B RID: 63051 RVA: 0x00427B41 File Offset: 0x00425F41
		public void Show()
		{
		}

		// Token: 0x0600F64C RID: 63052 RVA: 0x00427B43 File Offset: 0x00425F43
		public void UpdateData(ILimitTimeActivityModel data)
		{
		}

		// Token: 0x04009716 RID: 38678
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009717 RID: 38679
		[SerializeField]
		private Text mRuleTxt;

		// Token: 0x04009718 RID: 38680
		[SerializeField]
		private Button mIntegrationBtn;

		// Token: 0x04009719 RID: 38681
		[SerializeField]
		private Button mGoBtn;

		// Token: 0x0400971A RID: 38682
		[SerializeField]
		private Transform mItemRoot;

		// Token: 0x0400971B RID: 38683
		[SerializeField]
		private Text mNum;

		// Token: 0x0400971C RID: 38684
		private uint scoreActivityId;

		// Token: 0x0400971D RID: 38685
		private int itemId;
	}
}
