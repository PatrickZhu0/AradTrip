using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200187B RID: 6267
	public class ChangeFashionActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F58B RID: 62859 RVA: 0x00423F36 File Offset: 0x00422336
		public void SetGoFashionCallBack(ChangeFashionActivityView.GoFashionMergeCallBack callback)
		{
			this.mGoFashionCallBack = callback;
		}

		// Token: 0x0600F58C RID: 62860 RVA: 0x00423F3F File Offset: 0x0042233F
		public void SetLookUpCallBack(ChangeFashionActivityView.LookUpCallBack callback)
		{
			this.mLookUpCallBack = callback;
		}

		// Token: 0x0600F58D RID: 62861 RVA: 0x00423F48 File Offset: 0x00422348
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			this.mNote.Init(model, true, base.GetComponent<ComCommonBind>());
			if (model.ParamArray != null && model.ParamArray.Length != 0)
			{
				int num = (int)model.ParamArray[0];
				if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty) == null)
				{
					Logger.LogErrorFormat("扩展参数{0}在道具表中无法被找到", new object[0]);
					return;
				}
				ComItem comItem = this.mFashionRoot.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					ComItem comItem2 = ComItemManager.Create(this.mFashionRoot);
					comItem = comItem2;
					this.mComItems.Add(comItem);
				}
				ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
				if (ItemDetailData == null)
				{
					return;
				}
				ItemDetailData.Count = 1;
				comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
				{
					this._OnShowTips(ItemDetailData);
				});
				this.mFashionName.text = ItemDetailData.Name;
			}
			if (this.mGoFashionMerge != null)
			{
				this.mGoFashionMerge.onClick.RemoveAllListeners();
				this.mGoFashionMerge.onClick.AddListener(delegate()
				{
					if (this.mGoFashionCallBack != null)
					{
						this.mGoFashionCallBack();
					}
				});
			}
			if (this.mLookUp != null)
			{
				int itemID = (int)model.ParamArray[0];
				this.mLookUp.onClick.RemoveAllListeners();
				this.mLookUp.onClick.AddListener(delegate()
				{
					if (this.mLookUpCallBack != null)
					{
						this.mLookUpCallBack(itemID);
					}
				});
			}
		}

		// Token: 0x0600F58E RID: 62862 RVA: 0x00424100 File Offset: 0x00422500
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
		}

		// Token: 0x0600F58F RID: 62863 RVA: 0x00424158 File Offset: 0x00422558
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x040096A0 RID: 38560
		[SerializeField]
		private Button mGoFashionMerge;

		// Token: 0x040096A1 RID: 38561
		[SerializeField]
		private Button mLookUp;

		// Token: 0x040096A2 RID: 38562
		[SerializeField]
		private GameObject mFashionRoot;

		// Token: 0x040096A3 RID: 38563
		[SerializeField]
		private Text mFashionName;

		// Token: 0x040096A4 RID: 38564
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x040096A5 RID: 38565
		private ChangeFashionActivityView.GoFashionMergeCallBack mGoFashionCallBack;

		// Token: 0x040096A6 RID: 38566
		private ChangeFashionActivityView.LookUpCallBack mLookUpCallBack;

		// Token: 0x0200187C RID: 6268
		// (Invoke) Token: 0x0600F592 RID: 62866
		public delegate void GoFashionMergeCallBack();

		// Token: 0x0200187D RID: 6269
		// (Invoke) Token: 0x0600F596 RID: 62870
		public delegate void LookUpCallBack(int itemID);
	}
}
