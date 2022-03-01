using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001893 RID: 6291
	public sealed class FlyingGiftPackActivityView : MonoBehaviour, IDisposable, IGiftPackActivityView
	{
		// Token: 0x0600F619 RID: 63001 RVA: 0x0042674C File Offset: 0x00424B4C
		private void Awake()
		{
			if (this.mMallBuyBtn1 != null)
			{
				this.mMallBuyBtn1.onClick.RemoveAllListeners();
				this.mMallBuyBtn1.onClick.AddListener(delegate()
				{
					if (this.mOnItemClick != null)
					{
						this.mOnItemClick(0, 0, 0UL);
					}
				});
			}
			if (this.mMallBuyBtn2 != null)
			{
				this.mMallBuyBtn2.onClick.RemoveAllListeners();
				this.mMallBuyBtn2.onClick.AddListener(delegate()
				{
					if (this.mOnItemClick != null)
					{
						this.mOnItemClick(1, 0, 0UL);
					}
				});
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F61A RID: 63002 RVA: 0x004267EE File Offset: 0x00424BEE
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F61B RID: 63003 RVA: 0x0042680C File Offset: 0x00424C0C
		public void Init(LimitTimeGiftPackModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.mNote.Init(model, false, base.GetComponent<ComCommonBind>());
			this.InitItems();
		}

		// Token: 0x0600F61C RID: 63004 RVA: 0x0042685C File Offset: 0x00424C5C
		private void UpdateBuyBtnState()
		{
			if (this.mMallBuyBtn1 != null)
			{
				this.mMallBuyBtn1.enabled = (this.gift1AccountRestBuyNum > 0);
			}
			if (this.mMallBuyGray1 != null)
			{
				this.mMallBuyGray1.enabled = (this.gift1AccountRestBuyNum <= 0);
			}
			if (this.mMallBuyBtn2 != null)
			{
				this.mMallBuyBtn2.enabled = (this.gift2AccountRestBuyNum > 0);
			}
			if (this.mMallBuyGray2 != null)
			{
				this.mMallBuyGray2.enabled = (this.gift2AccountRestBuyNum <= 0);
			}
		}

		// Token: 0x0600F61D RID: 63005 RVA: 0x00426904 File Offset: 0x00424D04
		private void InitItems()
		{
			for (int i = 0; i < this.mGiftItems1.Count; i++)
			{
				this.mItems1[i].CustomActive(true);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mGiftItems1[i], 100, 0);
				if (itemData != null)
				{
					ComItem comItem = ComItemManager.Create(this.mItems1[i]);
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (FlyingGiftPackActivityView.<>f__mg$cache0 == null)
					{
						FlyingGiftPackActivityView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, FlyingGiftPackActivityView.<>f__mg$cache0);
				}
			}
			for (int j = 0; j < this.mGiftItems2.Count; j++)
			{
				this.mItems2[j].CustomActive(true);
				ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(this.mGiftItems2[j], 100, 0);
				if (itemData2 != null)
				{
					ComItem comItem3 = ComItemManager.Create(this.mItems2[j]);
					ComItem comItem4 = comItem3;
					ItemData item2 = itemData2;
					if (FlyingGiftPackActivityView.<>f__mg$cache1 == null)
					{
						FlyingGiftPackActivityView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem4.Setup(item2, FlyingGiftPackActivityView.<>f__mg$cache1);
				}
			}
		}

		// Token: 0x0600F61E RID: 63006 RVA: 0x00426A20 File Offset: 0x00424E20
		private void UpdateItemAccountRestBuyNum()
		{
			if (this.mModel.DetailDatas.Count >= 2)
			{
				this.gift1AccountRestBuyNum = (int)this.mModel.DetailDatas[0].AccountRestBuyNum;
				this.gift2AccountRestBuyNum = (int)this.mModel.DetailDatas[1].AccountRestBuyNum;
			}
		}

		// Token: 0x0600F61F RID: 63007 RVA: 0x00426A81 File Offset: 0x00424E81
		public void UpdateData(LimitTimeGiftPackModel model)
		{
			this.mModel = model;
			this.UpdateItemAccountRestBuyNum();
			this.UpdateBuyBtnState();
		}

		// Token: 0x0600F620 RID: 63008 RVA: 0x00426A98 File Offset: 0x00424E98
		private void OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			int num2 = -1;
			for (int i = 0; i < this.mModel.DetailDatas.Count; i++)
			{
				if (num == this.mModel.DetailDatas[i].Id)
				{
					num2 = i;
					break;
				}
			}
			if (num2 == 0)
			{
				this.gift1AccountRestBuyNum = (int)uiEvent.Param3;
			}
			else if (num2 == 1)
			{
				this.gift2AccountRestBuyNum = (int)uiEvent.Param3;
			}
			this.UpdateBuyBtnState();
		}

		// Token: 0x0600F621 RID: 63009 RVA: 0x00426B57 File Offset: 0x00424F57
		public void Dispose()
		{
			if (this.mNote != null)
			{
				this.mNote.Dispose();
			}
		}

		// Token: 0x0600F622 RID: 63010 RVA: 0x00426B75 File Offset: 0x00424F75
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x040096E9 RID: 38633
		[SerializeField]
		protected ActivityNote mNote;

		// Token: 0x040096EA RID: 38634
		[SerializeField]
		protected List<GameObject> mItems1;

		// Token: 0x040096EB RID: 38635
		[SerializeField]
		protected List<GameObject> mItems2;

		// Token: 0x040096EC RID: 38636
		[SerializeField]
		protected Button mMallBuyBtn1;

		// Token: 0x040096ED RID: 38637
		[SerializeField]
		protected Button mMallBuyBtn2;

		// Token: 0x040096EE RID: 38638
		[SerializeField]
		protected UIGray mMallBuyGray1;

		// Token: 0x040096EF RID: 38639
		[SerializeField]
		protected UIGray mMallBuyGray2;

		// Token: 0x040096F0 RID: 38640
		[SerializeField]
		protected List<int> mGiftItems1;

		// Token: 0x040096F1 RID: 38641
		[SerializeField]
		protected List<int> mGiftItems2;

		// Token: 0x040096F2 RID: 38642
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040096F3 RID: 38643
		private LimitTimeGiftPackModel mModel;

		// Token: 0x040096F4 RID: 38644
		private int gift1AccountRestBuyNum;

		// Token: 0x040096F5 RID: 38645
		private int gift2AccountRestBuyNum;

		// Token: 0x040096F6 RID: 38646
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x040096F7 RID: 38647
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;
	}
}
