using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018A6 RID: 6310
	public class MouseYearRedPackageView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F6BE RID: 63166 RVA: 0x0042AE54 File Offset: 0x00429254
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this._InitNote(model);
			this.mOnItemClick = onItemClick;
			this._InitItems(model);
			this._ShowTotalRechargeNum();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueUpdate));
		}

		// Token: 0x0600F6BF RID: 63167 RVA: 0x0042AEA8 File Offset: 0x004292A8
		public void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			GameObject gameObject = null;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (this.mItems.ContainsKey(data.TaskDatas[i].DataId))
				{
					this.mItems[data.TaskDatas[i].DataId].UpdateData(data.TaskDatas[i]);
				}
				else
				{
					if (gameObject == null)
					{
						gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
					}
					this._AddItem(gameObject, i, data);
				}
			}
			List<uint> list = new List<uint>(this.mItems.Keys);
			for (int j = 0; j < list.Count; j++)
			{
				bool flag = false;
				for (int k = 0; k < data.TaskDatas.Count; k++)
				{
					if (list[j] == data.TaskDatas[k].DataId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					IActivityCommonItem activityCommonItem = this.mItems[list[j]];
					this.mItems.Remove(list[j]);
					activityCommonItem.Destroy();
				}
			}
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600F6C0 RID: 63168 RVA: 0x0042B034 File Offset: 0x00429434
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
				Logger.LogError("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + data.ItemPath);
				return;
			}
			this.mItems.Clear();
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (data.TaskDatas[i] != null)
				{
					this._AddItem(gameObject, i, data);
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F6C1 RID: 63169 RVA: 0x0042B0EC File Offset: 0x004294EC
		private void _AddItem(GameObject go, int id, ILimitTimeActivityModel data)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoot, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x0600F6C2 RID: 63170 RVA: 0x0042B168 File Offset: 0x00429568
		private void _InitNote(ILimitTimeActivityModel model)
		{
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(model.StartTime), this._TransTimeStampToStr(model.EndTime)));
			if (!string.IsNullOrEmpty(model.LogoDesc))
			{
				this.mTextLogo.SafeSetText(model.LogoDesc);
			}
			else
			{
				this.mTextLogo.SafeSetText(TR.Value("activity_login_introduce"));
			}
			if (this.mImageLogo != null)
			{
				if (!string.IsNullOrEmpty(model.LogoPath))
				{
					ETCImageLoader.LoadSprite(ref this.mImageLogo, model.LogoPath, true);
				}
				else
				{
					ETCImageLoader.LoadSprite(ref this.mImageLogo, this.mDefaultLogoPath, true);
				}
				this.mImageLogo.SetNativeSize();
			}
		}

		// Token: 0x0600F6C3 RID: 63171 RVA: 0x0042B234 File Offset: 0x00429634
		private void _OnCountValueUpdate(UIEvent uiEvent)
		{
			string a = uiEvent.Param1 as string;
			if (a == CounterKeys.TOTAL_RECHARGENUM)
			{
				this._ShowTotalRechargeNum();
			}
		}

		// Token: 0x0600F6C4 RID: 63172 RVA: 0x0042B264 File Offset: 0x00429664
		private void _ShowTotalRechargeNum()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.TOTAL_RECHARGENUM);
			this.mTotalCashTxt.SafeSetText(string.Format(TR.Value("TotalRechargeNum"), count));
		}

		// Token: 0x0600F6C5 RID: 63173 RVA: 0x0042B2A4 File Offset: 0x004296A4
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

		// Token: 0x0600F6C6 RID: 63174 RVA: 0x0042B319 File Offset: 0x00429719
		public void Show()
		{
		}

		// Token: 0x0600F6C7 RID: 63175 RVA: 0x0042B31B File Offset: 0x0042971B
		public void Hide()
		{
			base.gameObject.SetActive(false);
		}

		// Token: 0x0600F6C8 RID: 63176 RVA: 0x0042B329 File Offset: 0x00429729
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F6C9 RID: 63177 RVA: 0x0042B33C File Offset: 0x0042973C
		public void Dispose()
		{
			foreach (IActivityCommonItem activityCommonItem in this.mItems.Values)
			{
				activityCommonItem.Dispose();
			}
			this.mItems.Clear();
			this.mOnItemClick = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueUpdate));
		}

		// Token: 0x0400979E RID: 38814
		[SerializeField]
		private string mDefaultLogoPath = "UI/Image/Background/UI_Xianshihuodong_SloganBg_01";

		// Token: 0x0400979F RID: 38815
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x040097A0 RID: 38816
		[SerializeField]
		private Image mImageLogo;

		// Token: 0x040097A1 RID: 38817
		[SerializeField]
		private Text mTextLogo;

		// Token: 0x040097A2 RID: 38818
		[SerializeField]
		private Text mTotalCashTxt;

		// Token: 0x040097A3 RID: 38819
		private readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();

		// Token: 0x040097A4 RID: 38820
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040097A5 RID: 38821
		[SerializeField]
		private Transform mItemRoot;
	}
}
