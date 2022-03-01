using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001894 RID: 6292
	public class GoblinShopActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F626 RID: 63014 RVA: 0x00426BE8 File Offset: 0x00424FE8
		public void SetCallBack(GoblinShopActivityView.BuyCallBack callback)
		{
			this.mGoToGoblinShopCallback = callback;
		}

		// Token: 0x0600F627 RID: 63015 RVA: 0x00426BF4 File Offset: 0x00424FF4
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.InitLocalData();
			if (model.ParamArray2 != null && model.ParamArray2.Length > 0)
			{
				this.iGoblinShopPreviewItemID = (int)model.ParamArray2[0];
			}
			this.mOnItemClick = onItemClick;
			this.mNote.Init(model, true, base.GetComponent<ComCommonBind>());
			this.mGoToGloblinBtn.onClick.RemoveAllListeners();
			this.mGoToGloblinBtn.onClick.AddListener(delegate()
			{
				if (this.mGoToGoblinShopCallback != null)
				{
					this.mGoToGoblinShopCallback();
				}
			});
			if (model.ParamArray != null && model.ParamArray.Length > 1)
			{
				MallLimitTimeActivity tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallLimitTimeActivity>((int)model.ParamArray[1], string.Empty, string.Empty);
				if (tableItem != null && this.mBg != null)
				{
					ETCImageLoader.LoadSprite(ref this.mBg, tableItem.BackgroundImgPath, true);
				}
				if (model.ParamArray.Length >= 2)
				{
					this.mMallItemTableId = (int)model.ParamArray[1];
					MallItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>(this.mMallItemTableId, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						string giftpackitems = tableItem2.giftpackitems;
						string[] array = giftpackitems.Split(new char[]
						{
							'|'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string[] array2 = array[i].Split(new char[]
							{
								':'
							});
							int id = 0;
							if (array.Length >= 1)
							{
								int.TryParse(array2[0], out id);
								if (this.mTmpGo != null)
								{
									GameObject gameObject = Object.Instantiate<GameObject>(this.mTmpGo);
									gameObject.transform.SetParent(this.mItemsRoot);
									gameObject.transform.localScale = Vector3.one;
									GoblinShopActivityItem component = gameObject.GetComponent<GoblinShopActivityItem>();
									if (component != null)
									{
										component.Init(id, this.mComItemSize);
									}
								}
							}
						}
					}
					if (this.mTmpGo)
					{
						Object.Destroy(this.mTmpGo);
					}
				}
			}
			this.SetPreviewBtn(model);
		}

		// Token: 0x0600F628 RID: 63016 RVA: 0x00426E0C File Offset: 0x0042520C
		private void InitLocalData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(570, string.Empty, string.Empty);
			this.iGoblinShopActivityID = tableItem.Value;
		}

		// Token: 0x0600F629 RID: 63017 RVA: 0x00426E40 File Offset: 0x00425240
		private void SetPreviewBtn(ILimitTimeActivityModel model)
		{
			if (model == null)
			{
				return;
			}
			if (this.mPreViewBtn != null)
			{
				this.mPreViewBtn.gameObject.CustomActive(0 != this.iGoblinShopActivityID);
				PreViewDataModel mPreViewData = new PreViewDataModel();
				mPreViewData.isCreatItem = false;
				mPreViewData.preViewItemList = new List<PreViewItemData>();
				PreViewItemData preViewItemData = new PreViewItemData();
				preViewItemData.activityId = this.iGoblinShopActivityID;
				preViewItemData.itemId = this.iGoblinShopPreviewItemID;
				mPreViewData.preViewItemList.Add(preViewItemData);
				this.mPreViewBtn.onClick.RemoveAllListeners();
				this.mPreViewBtn.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, mPreViewData, string.Empty);
				});
			}
		}

		// Token: 0x0600F62A RID: 63018 RVA: 0x00426F0C File Offset: 0x0042530C
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
			this.iGoblinShopActivityID = 0;
			this.iGoblinShopPreviewItemID = 0;
			this.mMallItemTableId = 0;
		}

		// Token: 0x0600F62B RID: 63019 RVA: 0x00426F79 File Offset: 0x00425379
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x040096F8 RID: 38648
		[SerializeField]
		private Button mGoToGloblinBtn;

		// Token: 0x040096F9 RID: 38649
		[SerializeField]
		private Image mBg;

		// Token: 0x040096FA RID: 38650
		[SerializeField]
		private Button mPreViewBtn;

		// Token: 0x040096FB RID: 38651
		private GoblinShopActivityView.BuyCallBack mGoToGoblinShopCallback;

		// Token: 0x040096FC RID: 38652
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x040096FD RID: 38653
		private int iGoblinShopActivityID;

		// Token: 0x040096FE RID: 38654
		private int iGoblinShopPreviewItemID;

		// Token: 0x040096FF RID: 38655
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(120f, 120f);

		// Token: 0x04009700 RID: 38656
		[SerializeField]
		private GameObject mTmpGo;

		// Token: 0x04009701 RID: 38657
		[SerializeField]
		private Transform mItemsRoot;

		// Token: 0x04009702 RID: 38658
		private int mMallItemTableId;

		// Token: 0x02001895 RID: 6293
		// (Invoke) Token: 0x0600F62E RID: 63022
		public delegate void BuyCallBack();
	}
}
