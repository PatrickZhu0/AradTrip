using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A67 RID: 6759
	internal class WeaponLeaseShopView : MonoBehaviour
	{
		// Token: 0x06010960 RID: 67936 RVA: 0x004B0340 File Offset: 0x004AE740
		public void InitView(WeaponLeaseShopFrame frame, ShopData shopData, WeaponLeaseItem.OnClickLease onClickLease)
		{
			this.frame = frame;
			this.mOnClickLease = onClickLease;
			this.shopData = shopData;
			this.InitShopGoodDatas();
			this.BindUIEvent();
			this.InitWeaponLeaseItemComUIListScript();
			this.mCloseBtn.onClick.RemoveAllListeners();
			this.mCloseBtn.onClick.AddListener(delegate()
			{
				this.frame.Close(false);
			});
		}

		// Token: 0x06010961 RID: 67937 RVA: 0x004B03A0 File Offset: 0x004AE7A0
		private void InitShopGoodDatas()
		{
			List<GoodsData> goodDataList = this.GetGoodDataList(ShopGoodDataType.LuckCharm);
			List<GoodsData> goodDataList2 = this.GetGoodDataList(ShopGoodDataType.ReComend);
			List<GoodsData> goodDataList3 = this.GetGoodDataList(ShopGoodDataType.Nomal);
			goodDataList2.Sort(new Comparison<GoodsData>(this.SortGoodsData));
			goodDataList3.Sort(new Comparison<GoodsData>(this.SortGoodsData));
			this.mShopGoodDatas.AddRange(goodDataList);
			this.mShopGoodDatas.AddRange(goodDataList2);
			this.mShopGoodDatas.AddRange(goodDataList3);
		}

		// Token: 0x06010962 RID: 67938 RVA: 0x004B0410 File Offset: 0x004AE810
		private List<GoodsData> GetGoodDataList(ShopGoodDataType type)
		{
			List<GoodsData> list = new List<GoodsData>();
			for (int i = 0; i < this.shopData.Goods.Count; i++)
			{
				GoodsData goodsData = this.shopData.Goods[i];
				if (type == ShopGoodDataType.LuckCharm)
				{
					if (goodsData.ItemData.Type == ItemTable.eType.INCOME)
					{
						if (goodsData.ItemData.SubType == 84)
						{
							list.Add(goodsData);
						}
					}
				}
				else if (type == ShopGoodDataType.Nomal)
				{
					if (goodsData.ItemData.Type != ItemTable.eType.INCOME)
					{
						if (goodsData.ItemData.SubType != 84)
						{
							if (!DataManager<ShopDataManager>.GetInstance().WeaponLeaseIsRecommendOccu(goodsData.ItemData.TableID))
							{
								list.Add(goodsData);
							}
						}
					}
				}
				else if (DataManager<ShopDataManager>.GetInstance().WeaponLeaseIsRecommendOccu(goodsData.ItemData.TableID))
				{
					list.Add(goodsData);
				}
			}
			return list;
		}

		// Token: 0x06010963 RID: 67939 RVA: 0x004B0518 File Offset: 0x004AE918
		private int SortGoodsData(GoodsData x, GoodsData y)
		{
			if (x.shopItem != y.shopItem)
			{
				return x.shopItem.SortID - y.shopItem.SortID;
			}
			return (x.ItemData.FixTimeLeft - y.ItemData.FixTimeLeft >= 0) ? 1 : -1;
		}

		// Token: 0x06010964 RID: 67940 RVA: 0x004B0574 File Offset: 0x004AE974
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._RereshAllGoods));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChange));
		}

		// Token: 0x06010965 RID: 67941 RVA: 0x004B05C4 File Offset: 0x004AE9C4
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._RereshAllGoods));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChange));
		}

		// Token: 0x06010966 RID: 67942 RVA: 0x004B0614 File Offset: 0x004AEA14
		private void InitWeaponLeaseItemComUIListScript()
		{
			this.mWeaponLeaseItemComUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mWeaponLeaseItemComUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mWeaponLeaseItemComUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			this.SetElementAmount();
		}

		// Token: 0x06010967 RID: 67943 RVA: 0x004B0680 File Offset: 0x004AEA80
		private WeaponLeaseItem _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<WeaponLeaseItem>();
		}

		// Token: 0x06010968 RID: 67944 RVA: 0x004B0698 File Offset: 0x004AEA98
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			WeaponLeaseItem weaponLeaseItem = item.gameObjectBindScript as WeaponLeaseItem;
			if (weaponLeaseItem != null && item.m_index >= 0 && item.m_index < this.shopData.Goods.Count)
			{
				weaponLeaseItem.UpdateWeaponLeaseItem(this.frame, this.mShopGoodDatas[item.m_index], this.mOnClickLease);
			}
		}

		// Token: 0x06010969 RID: 67945 RVA: 0x004B0707 File Offset: 0x004AEB07
		private void _RereshAllGoods(UIEvent uiEvent)
		{
			this.SetElementAmount();
		}

		// Token: 0x0601096A RID: 67946 RVA: 0x004B070F File Offset: 0x004AEB0F
		private void _OnMoneyChange(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			if (eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_GOLD || eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_WEAPON_LEASE_TICKET)
			{
				this.SetElementAmount();
			}
		}

		// Token: 0x0601096B RID: 67947 RVA: 0x004B0725 File Offset: 0x004AEB25
		private void SetElementAmount()
		{
			this.mWeaponLeaseItemComUIListScript.SetElementAmount(this.mShopGoodDatas.Count);
		}

		// Token: 0x0601096C RID: 67948 RVA: 0x004B0740 File Offset: 0x004AEB40
		public void UnInitView()
		{
			if (this.mWeaponLeaseItemComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mWeaponLeaseItemComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mWeaponLeaseItemComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				this.mWeaponLeaseItemComUIListScript = null;
			}
			this.frame = null;
			this.mOnClickLease = null;
			this.shopData = null;
			this.UnBindUIEvent();
			this.mShopGoodDatas.Clear();
		}

		// Token: 0x0400A92D RID: 43309
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400A92E RID: 43310
		[SerializeField]
		private GameObject mWeaponLeaseGoodsParent;

		// Token: 0x0400A92F RID: 43311
		[SerializeField]
		private GameObject mWeaponLeaseGoodsPrefab;

		// Token: 0x0400A930 RID: 43312
		[SerializeField]
		private ComUIListScript mWeaponLeaseItemComUIListScript;

		// Token: 0x0400A931 RID: 43313
		private WeaponLeaseShopFrame frame;

		// Token: 0x0400A932 RID: 43314
		private WeaponLeaseItem.OnClickLease mOnClickLease;

		// Token: 0x0400A933 RID: 43315
		private ShopData shopData;

		// Token: 0x0400A934 RID: 43316
		private List<GoodsData> mShopGoodDatas = new List<GoodsData>();
	}
}
