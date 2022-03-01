using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018A2 RID: 6306
	public class LimitTimeHellActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F693 RID: 63123 RVA: 0x004293CB File Offset: 0x004277CB
		public void SetCallBack(LimitTimeHellActivityView.CallBack callback)
		{
			this.mGoToCallback = callback;
		}

		// Token: 0x0600F694 RID: 63124 RVA: 0x004293D4 File Offset: 0x004277D4
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			if (this.time != null)
			{
				this.time.text = string.Format("{0}-{1}", Function.GetDateTime((int)model.StartTime, false), Function.GetDateTime((int)model.EndTime, false));
			}
			this._InitItems(model);
			this.mGoToGloblinBtn.onClick.RemoveAllListeners();
			this.mGoToGloblinBtn.onClick.AddListener(delegate()
			{
				if (this.mGoToCallback != null)
				{
					this.mGoToCallback();
				}
			});
			if (model.ParamArray != null && model.ParamArray.Length > 1)
			{
				MallLimitTimeActivity tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallLimitTimeActivity>((int)model.ParamArray[1], string.Empty, string.Empty);
				if (tableItem != null && this.mBg != null)
				{
					ETCImageLoader.LoadSprite(ref this.mBg, tableItem.BackgroundImgPath, true);
				}
			}
		}

		// Token: 0x0600F695 RID: 63125 RVA: 0x004294CC File Offset: 0x004278CC
		protected sealed override void _InitItems(ILimitTimeActivityModel data)
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
			GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
			gameObject2.transform.SetParent(this.mItemRoot, false);
			this.mActivityItemData = gameObject2.GetComponent<IActivityCommonItem>();
			this.mActivityItemData.InitFromMode(data, this.mOnItemClick);
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F696 RID: 63126 RVA: 0x0042957D File Offset: 0x0042797D
		public override void UpdateData(ILimitTimeActivityModel data)
		{
			(this.mActivityItemData as LimitTimeHellItem).UpdateFromMode(data);
		}

		// Token: 0x0600F697 RID: 63127 RVA: 0x00429590 File Offset: 0x00427990
		public override void Dispose()
		{
		}

		// Token: 0x0600F698 RID: 63128 RVA: 0x00429592 File Offset: 0x00427992
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x04009782 RID: 38786
		[SerializeField]
		private Button mGoToGloblinBtn;

		// Token: 0x04009783 RID: 38787
		[SerializeField]
		private Image mBg;

		// Token: 0x04009784 RID: 38788
		[SerializeField]
		private Text time;

		// Token: 0x04009785 RID: 38789
		private LimitTimeHellActivityView.CallBack mGoToCallback;

		// Token: 0x04009786 RID: 38790
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009787 RID: 38791
		private IActivityCommonItem mActivityItemData;

		// Token: 0x020018A3 RID: 6307
		// (Invoke) Token: 0x0600F69B RID: 63131
		public delegate void CallBack();
	}
}
