using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A63 RID: 6755
	internal class WeaponLeaseItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0601094A RID: 67914 RVA: 0x004AFC4C File Offset: 0x004AE04C
		public void UpdateWeaponLeaseItem(WeaponLeaseShopFrame frame, GoodsData goodsData, WeaponLeaseItem.OnClickLease onClickLease)
		{
			this.frame = frame;
			this.goodsData = goodsData;
			this.mOnClickLease = onClickLease;
			if (this.mComitem == null)
			{
				this.mComitem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComitem;
			ItemData itemData = this.goodsData.ItemData;
			if (WeaponLeaseItem.<>f__mg$cache0 == null)
			{
				WeaponLeaseItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(itemData, WeaponLeaseItem.<>f__mg$cache0);
			this.mName.text = this.goodsData.ItemData.GetColorName(string.Empty, false);
			ETCImageLoader.LoadSprite(ref this.mTicketIcon, this.goodsData.CostItemData.Icon, true);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.goodsData.CostItemData.TableID, true);
			this.mTicketCount.text = this.goodsData.CostItemCount.Value.ToString();
			this.mTicketCount.color = ((!(ownedItemCount >= this.goodsData.CostItemCount)) ? Color.red : Color.white);
			this.mGoReCommend.CustomActive(DataManager<ShopDataManager>.GetInstance().WeaponLeaseIsRecommendOccu(this.goodsData.ItemData.TableID));
			this.mLeaseBtn.onClick.RemoveAllListeners();
			this.mLeaseBtn.onClick.AddListener(delegate()
			{
				if (this.mOnClickLease != null)
				{
					this.mOnClickLease(this.goodsData);
				}
			});
			this.RefreshButtonState();
			this.UpdatemLeaseBtnIcon();
		}

		// Token: 0x0601094B RID: 67915 RVA: 0x004AFDEC File Offset: 0x004AE1EC
		private void RefreshButtonState()
		{
			if ((long)this.goodsData.LeaseEndTimeStamp - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()) > 0L)
			{
				this.mGoInTheLease.CustomActive(true);
				this.mGoLease.CustomActive(false);
			}
			else
			{
				this.mGoInTheLease.CustomActive(false);
				this.mGoLease.CustomActive(true);
			}
		}

		// Token: 0x0601094C RID: 67916 RVA: 0x004AFE50 File Offset: 0x004AE250
		private void UpdatemLeaseBtnIcon()
		{
			if (this.goodsData.ItemData.SubType == 84)
			{
				ETCImageLoader.LoadSprite(ref this.mLeaseBtnIcon, this.mBuyImagePath, true);
			}
			else
			{
				ETCImageLoader.LoadSprite(ref this.mLeaseBtnIcon, this.mLeaseImagePath, true);
			}
		}

		// Token: 0x0601094D RID: 67917 RVA: 0x004AFEA0 File Offset: 0x004AE2A0
		private void Update()
		{
			this.timer += (int)Time.deltaTime;
			if (this.timer > 10)
			{
				if ((long)this.goodsData.LeaseEndTimeStamp - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()) <= 0L)
				{
					this.isRefresh = true;
				}
				if (this.isRefresh)
				{
					this.RefreshButtonState();
					this.isRefresh = false;
				}
				this.timer = 0;
			}
		}

		// Token: 0x0601094E RID: 67918 RVA: 0x004AFF12 File Offset: 0x004AE312
		public void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x0601094F RID: 67919 RVA: 0x004AFF1C File Offset: 0x004AE31C
		public void Dispose()
		{
			this.frame = null;
			this.goodsData = null;
			this.mOnClickLease = null;
			if (this.mComitem != null)
			{
				this.mComitem.Setup(null, null);
				this.mComitem = null;
			}
			if (this.mLeaseBtn != null)
			{
				this.mLeaseBtn.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0400A913 RID: 43283
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400A914 RID: 43284
		[SerializeField]
		private Text mName;

		// Token: 0x0400A915 RID: 43285
		[SerializeField]
		private Image mTicketIcon;

		// Token: 0x0400A916 RID: 43286
		[SerializeField]
		private Text mTicketCount;

		// Token: 0x0400A917 RID: 43287
		[SerializeField]
		private Button mLeaseBtn;

		// Token: 0x0400A918 RID: 43288
		[SerializeField]
		private GameObject mGoLease;

		// Token: 0x0400A919 RID: 43289
		[SerializeField]
		private GameObject mGoInTheLease;

		// Token: 0x0400A91A RID: 43290
		[SerializeField]
		private GameObject mGoReCommend;

		// Token: 0x0400A91B RID: 43291
		[SerializeField]
		private Image mLeaseBtnIcon;

		// Token: 0x0400A91C RID: 43292
		[SerializeField]
		private string mLeaseImagePath;

		// Token: 0x0400A91D RID: 43293
		[SerializeField]
		private string mBuyImagePath;

		// Token: 0x0400A91E RID: 43294
		private WeaponLeaseItem.OnClickLease mOnClickLease;

		// Token: 0x0400A91F RID: 43295
		private WeaponLeaseShopFrame frame;

		// Token: 0x0400A920 RID: 43296
		private GoodsData goodsData;

		// Token: 0x0400A921 RID: 43297
		private ComItem mComitem;

		// Token: 0x0400A922 RID: 43298
		private bool isRefresh;

		// Token: 0x0400A923 RID: 43299
		private int timer;

		// Token: 0x0400A924 RID: 43300
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x02001A64 RID: 6756
		// (Invoke) Token: 0x06010952 RID: 67922
		public delegate void OnClickLease(GoodsData goodsData);
	}
}
