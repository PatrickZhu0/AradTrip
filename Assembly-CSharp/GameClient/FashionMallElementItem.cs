using System;
using FashionLimitTimeBuy;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001783 RID: 6019
	public class FashionMallElementItem : MonoBehaviour
	{
		// Token: 0x0600EDAD RID: 60845 RVA: 0x003FB87E File Offset: 0x003F9C7E
		private void Awake()
		{
			this._fashionMallElementData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x0600EDAE RID: 60846 RVA: 0x003FB890 File Offset: 0x003F9C90
		private void BindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
				this.buyButton.onClick.AddListener(new UnityAction(this.OnBuyButtonClickCallBack));
			}
			if (this.tryOnButton != null)
			{
				this.tryOnButton.onClick.RemoveAllListeners();
				this.tryOnButton.onClick.AddListener(new UnityAction(this.OnTryOnButtonClickCallBack));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSendQueryMallItemInfo, new ClientEventSystem.UIEventHandler(this.ReqQueryMallItemInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnQueryMallItenInfoSuccess, new ClientEventSystem.UIEventHandler(this.OnQueryMallItenInfoSuccess));
		}

		// Token: 0x0600EDAF RID: 60847 RVA: 0x003FB94D File Offset: 0x003F9D4D
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600EDB0 RID: 60848 RVA: 0x003FB95C File Offset: 0x003F9D5C
		private void Update()
		{
			if (this._fashionMallElementData != null && this._fashionMallElementData.MallItemInfo != null && this._fashionMallElementData.MallItemInfo.multipleEndTime > 0U)
			{
				this._isUpdate = true;
			}
			if (this._isUpdate)
			{
				int num = (int)(this._fashionMallElementData.MallItemInfo.multipleEndTime - DataManager<TimeManager>.GetInstance().GetServerTime());
				if (num <= 0)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSendQueryMallItemInfo, this._fashionMallElementData.MallItemInfo.itemid, null, null, null);
					this._isUpdate = false;
				}
			}
		}

		// Token: 0x0600EDB1 RID: 60849 RVA: 0x003FB9FD File Offset: 0x003F9DFD
		private void ClearData()
		{
			this._fashionMallElementData = null;
			this._elementItemTryOnDelegate = null;
			this._elementItemBuyDelegate = null;
			this._isUpdate = false;
		}

		// Token: 0x0600EDB2 RID: 60850 RVA: 0x003FBA1C File Offset: 0x003F9E1C
		private void UnBindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
			}
			if (this.tryOnButton != null)
			{
				this.tryOnButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSendQueryMallItemInfo, new ClientEventSystem.UIEventHandler(this.ReqQueryMallItemInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnQueryMallItenInfoSuccess, new ClientEventSystem.UIEventHandler(this.OnQueryMallItenInfoSuccess));
		}

		// Token: 0x0600EDB3 RID: 60851 RVA: 0x003FBAA1 File Offset: 0x003F9EA1
		public void InitData(FashionMallElementData fashionMallElementData, OnFashionMallElementItemBuy onFashionMallElementItemBuy = null, OnFashionMallElementItemTryOn onFashionMallElementItemTryOn = null)
		{
			this._fashionMallElementData = fashionMallElementData;
			this._elementItemBuyDelegate = onFashionMallElementItemBuy;
			this._elementItemTryOnDelegate = onFashionMallElementItemTryOn;
			this.InitElementView();
			this.UpdateIntergralInfo();
			this.UpdateCreditPointFlag();
		}

		// Token: 0x0600EDB4 RID: 60852 RVA: 0x003FBACC File Offset: 0x003F9ECC
		private void InitElementView()
		{
			if (this._fashionMallElementData == null)
			{
				return;
			}
			MallItemInfo mallItemInfo = this._fashionMallElementData.MallItemInfo;
			if (mallItemInfo == null)
			{
				return;
			}
			int fashionItemId = DataManager<MallNewDataManager>.GetInstance().GetFashionItemId(mallItemInfo, this._fashionMallElementData.ClothTabType);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(fashionItemId, string.Empty, string.Empty);
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(fashionItemId, 100, 0);
			if (itemData == null)
			{
				return;
			}
			if (itemData.SubType != 17 && itemData.SubType != 27)
			{
				itemData.Count = (int)mallItemInfo.itemnum;
			}
			if (this.itemRoot != null)
			{
				ComItem comItem = this.itemRoot.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = ComItemManager.Create(this.itemRoot);
				}
				if (this._fashionMallElementData.ClothTabType == FashionMallClothTabType.Single || this._fashionMallElementData.ClothTabType == FashionMallClothTabType.Weapon)
				{
					comItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTipFrame));
				}
				else
				{
					comItem.Setup(itemData, null);
				}
			}
			if (this._fashionMallElementData.ClothTabType == FashionMallClothTabType.Suit)
			{
				this.nameText.text = mallItemInfo.giftName;
				DataManager<FashionLimitTimeBuyManager>.GetInstance().ResetItemNameColor(tableItem, this.nameText);
			}
			else if (this.nameText != null)
			{
				this.nameText.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, (PetTable.eQuality)tableItem.Color);
			}
			if (this.costIcon != null)
			{
				ItemTable costItemTableByCostType = DataManager<MallNewDataManager>.GetInstance().GetCostItemTableByCostType(mallItemInfo.moneytype);
				if (costItemTableByCostType != null)
				{
					ETCImageLoader.LoadSprite(ref this.costIcon, costItemTableByCostType.Icon, true);
				}
				else
				{
					Logger.LogErrorFormat("CostItemTable is null and moneyType is {0}", new object[]
					{
						mallItemInfo.moneytype
					});
				}
			}
			if (this.curPriceText != null)
			{
				this.curPriceText.text = Utility.GetMallRealPrice(mallItemInfo).ToString();
			}
		}

		// Token: 0x0600EDB5 RID: 60853 RVA: 0x003FBCD4 File Offset: 0x003FA0D4
		private void UpdateIntergralInfo()
		{
			if (this._fashionMallElementData == null)
			{
				return;
			}
			this.intergralFlagRoot.CustomActive(this._fashionMallElementData.MallItemInfo.multiple > 0);
			this.intergralRoot.CustomActive(this._fashionMallElementData.MallItemInfo.multipleEndTime > 0U);
			this.singleRoot.CustomActive(this._fashionMallElementData.MallItemInfo.multiple == 1);
			this.multiplePlictityRoot.CustomActive(this._fashionMallElementData.MallItemInfo.multiple > 1);
			if (this.intergralMultiple != null)
			{
				ETCImageLoader.LoadSprite(ref this.intergralMultiple, TR.Value("mall_new_limit_item_left_intergral_multiple_sprit_path", this._fashionMallElementData.MallItemInfo.multiple), true);
			}
			this.intergralLimtText.text = TR.Value("mall_new_limit_item_left_intergral_multiple_limit", this._fashionMallElementData.MallItemInfo.multiple, Function.SetShowTimeDay((int)this._fashionMallElementData.MallItemInfo.multipleEndTime));
		}

		// Token: 0x0600EDB6 RID: 60854 RVA: 0x003FBDE4 File Offset: 0x003FA1E4
		private void UpdateCreditPointFlag()
		{
			if (this.creditTicketFlag == null)
			{
				return;
			}
			bool flag = false;
			if (this._fashionMallElementData != null)
			{
				flag = MallNewUtility.IsMallItemCanCreditPointDeduction(this._fashionMallElementData.MallItemInfo);
			}
			CommonUtility.UpdateGameObjectVisible(this.creditTicketFlag, flag);
		}

		// Token: 0x0600EDB7 RID: 60855 RVA: 0x003FBE2D File Offset: 0x003FA22D
		private void OnTryOnButtonClickCallBack()
		{
			if (this._fashionMallElementData == null)
			{
				return;
			}
			if (this._elementItemTryOnDelegate == null)
			{
				return;
			}
			this._elementItemTryOnDelegate(this._fashionMallElementData.MallItemInfo);
		}

		// Token: 0x0600EDB8 RID: 60856 RVA: 0x003FBE60 File Offset: 0x003FA260
		private void OnBuyButtonClickCallBack()
		{
			if (this._fashionMallElementData == null)
			{
				return;
			}
			if (this._elementItemBuyDelegate == null)
			{
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			this._elementItemBuyDelegate(this._fashionMallElementData.MallItemInfo);
		}

		// Token: 0x0600EDB9 RID: 60857 RVA: 0x003FBEAD File Offset: 0x003FA2AD
		private void ShowItemTipFrame(GameObject go, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTipWithoutModelAvatar(itemData);
		}

		// Token: 0x0600EDBA RID: 60858 RVA: 0x003FBEBC File Offset: 0x003FA2BC
		private void ReqQueryMallItemInfo(UIEvent uiEvent)
		{
			if (this._fashionMallElementData == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (this._fashionMallElementData.MallItemInfo.itemid != num)
			{
				return;
			}
			DataManager<MallNewDataManager>.GetInstance().ReqQueryMallItemInfo((int)this._fashionMallElementData.MallItemInfo.itemid);
		}

		// Token: 0x0600EDBB RID: 60859 RVA: 0x003FBF12 File Offset: 0x003FA312
		private void OnQueryMallItenInfoSuccess(UIEvent uiEvent)
		{
			this._fashionMallElementData.MallItemInfo = DataManager<MallNewDataManager>.GetInstance().QueryMallItemInfo;
			this.UpdateIntergralInfo();
		}

		// Token: 0x04009116 RID: 37142
		private FashionMallElementData _fashionMallElementData;

		// Token: 0x04009117 RID: 37143
		private OnFashionMallElementItemBuy _elementItemBuyDelegate;

		// Token: 0x04009118 RID: 37144
		private OnFashionMallElementItemTryOn _elementItemTryOnDelegate;

		// Token: 0x04009119 RID: 37145
		[Header("Text")]
		[SerializeField]
		private Text nameText;

		// Token: 0x0400911A RID: 37146
		[SerializeField]
		private Text prePriceText;

		// Token: 0x0400911B RID: 37147
		[SerializeField]
		private Text curPriceText;

		// Token: 0x0400911C RID: 37148
		[SerializeField]
		private Text intergralLimtText;

		// Token: 0x0400911D RID: 37149
		[Header("Image")]
		[SerializeField]
		private Image costIcon;

		// Token: 0x0400911E RID: 37150
		[SerializeField]
		private Image intergralMultiple;

		// Token: 0x0400911F RID: 37151
		[Header("Button")]
		[SerializeField]
		private Button tryOnButton;

		// Token: 0x04009120 RID: 37152
		[SerializeField]
		private Button buyButton;

		// Token: 0x04009121 RID: 37153
		[SerializeField]
		private UIGray buyButtonGray;

		// Token: 0x04009122 RID: 37154
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x04009123 RID: 37155
		[SerializeField]
		private GameObject limitRoot;

		// Token: 0x04009124 RID: 37156
		[SerializeField]
		private Text limitText;

		// Token: 0x04009125 RID: 37157
		[SerializeField]
		private GameObject discountIcon;

		// Token: 0x04009126 RID: 37158
		[SerializeField]
		private GameObject discountGo;

		// Token: 0x04009127 RID: 37159
		[SerializeField]
		private GameObject intergralFlagRoot;

		// Token: 0x04009128 RID: 37160
		[SerializeField]
		private GameObject intergralRoot;

		// Token: 0x04009129 RID: 37161
		[SerializeField]
		private GameObject singleRoot;

		// Token: 0x0400912A RID: 37162
		[SerializeField]
		private GameObject multiplePlictityRoot;

		// Token: 0x0400912B RID: 37163
		[Space(10f)]
		[Header("CreditTicketFlag")]
		[Space(10f)]
		[SerializeField]
		private GameObject creditTicketFlag;

		// Token: 0x0400912C RID: 37164
		private bool _isUpdate;
	}
}
