using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001788 RID: 6024
	public class FashionMallSuitElementItem : MonoBehaviour
	{
		// Token: 0x0600EDCA RID: 60874 RVA: 0x003FC18E File Offset: 0x003FA58E
		private void Awake()
		{
			this._fashionMallElementData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x0600EDCB RID: 60875 RVA: 0x003FC1A0 File Offset: 0x003FA5A0
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

		// Token: 0x0600EDCC RID: 60876 RVA: 0x003FC25D File Offset: 0x003FA65D
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600EDCD RID: 60877 RVA: 0x003FC26C File Offset: 0x003FA66C
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

		// Token: 0x0600EDCE RID: 60878 RVA: 0x003FC30D File Offset: 0x003FA70D
		private void ClearData()
		{
			this._fashionMallElementData = null;
			this._elementItemTryOnDelegate = null;
			this._elementItemBuyDelegate = null;
			this._isUpdate = false;
		}

		// Token: 0x0600EDCF RID: 60879 RVA: 0x003FC32C File Offset: 0x003FA72C
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

		// Token: 0x0600EDD0 RID: 60880 RVA: 0x003FC3B1 File Offset: 0x003FA7B1
		public void InitData(FashionMallElementData fashionMallElementData, OnFashionMallElementItemBuy elementItemBuy = null, OnFashionMallElementItemTryOn elementItemTryOn = null)
		{
			this._fashionMallElementData = fashionMallElementData;
			this._elementItemBuyDelegate = elementItemBuy;
			this._elementItemTryOnDelegate = elementItemTryOn;
			this.UpdateSuitElementVisible();
			this.InitSuitElement();
			this.UpdateIntergralInfo();
			this.UpdateCreditPointFlag();
		}

		// Token: 0x0600EDD1 RID: 60881 RVA: 0x003FC3E0 File Offset: 0x003FA7E0
		private void UpdateSuitElementVisible()
		{
			if (this.suitImage != null && !this.suitImage.gameObject.activeSelf)
			{
				this.suitImage.gameObject.CustomActive(true);
			}
			if (this.buttonRoot != null && !this.buttonRoot.activeSelf)
			{
				this.buttonRoot.CustomActive(true);
			}
		}

		// Token: 0x0600EDD2 RID: 60882 RVA: 0x003FC454 File Offset: 0x003FA854
		private void InitSuitElement()
		{
			if (this._fashionMallElementData == null)
			{
				return;
			}
			string suitItemImagePath = this.GetSuitItemImagePath();
			if (this.suitImage != null)
			{
				this.suitImage.sprite = (Singleton<AssetLoader>.instance.LoadRes(suitItemImagePath, typeof(Sprite), true, 0U).obj as Sprite);
			}
		}

		// Token: 0x0600EDD3 RID: 60883 RVA: 0x003FC4B4 File Offset: 0x003FA8B4
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
			if (this.intergralMutiple != null)
			{
				ETCImageLoader.LoadSprite(ref this.intergralMutiple, TR.Value("mall_new_limit_item_left_intergral_multiple_sprit_path", this._fashionMallElementData.MallItemInfo.multiple), true);
			}
			this.intergralLimtText.text = TR.Value("mall_new_limit_item_left_intergral_multiple_limit", this._fashionMallElementData.MallItemInfo.multiple, Function.SetShowTimeDay((int)this._fashionMallElementData.MallItemInfo.multipleEndTime));
		}

		// Token: 0x0600EDD4 RID: 60884 RVA: 0x003FC5C4 File Offset: 0x003FA9C4
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

		// Token: 0x0600EDD5 RID: 60885 RVA: 0x003FC60D File Offset: 0x003FAA0D
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

		// Token: 0x0600EDD6 RID: 60886 RVA: 0x003FC63D File Offset: 0x003FAA3D
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
			this._elementItemBuyDelegate(this._fashionMallElementData.MallItemInfo);
		}

		// Token: 0x0600EDD7 RID: 60887 RVA: 0x003FC670 File Offset: 0x003FAA70
		private string GetSuitItemImagePath()
		{
			string result = "UI/Image/Background/UI_Beijing_Shangdian_Hunsha_05.jpg:UI_Beijing_Shangdian_Hunsha_05";
			if (this._fashionMallElementData == null)
			{
				return result;
			}
			return this._fashionMallElementData.MallItemInfo.fashionImagePath;
		}

		// Token: 0x0600EDD8 RID: 60888 RVA: 0x003FC6A0 File Offset: 0x003FAAA0
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

		// Token: 0x0600EDD9 RID: 60889 RVA: 0x003FC6F6 File Offset: 0x003FAAF6
		private void OnQueryMallItenInfoSuccess(UIEvent uiEvent)
		{
			this._fashionMallElementData.MallItemInfo = DataManager<MallNewDataManager>.GetInstance().QueryMallItemInfo;
			this.UpdateIntergralInfo();
		}

		// Token: 0x0400913F RID: 37183
		private FashionMallElementData _fashionMallElementData;

		// Token: 0x04009140 RID: 37184
		private OnFashionMallElementItemBuy _elementItemBuyDelegate;

		// Token: 0x04009141 RID: 37185
		private OnFashionMallElementItemTryOn _elementItemTryOnDelegate;

		// Token: 0x04009142 RID: 37186
		[SerializeField]
		private Image suitImage;

		// Token: 0x04009143 RID: 37187
		[SerializeField]
		private Image intergralMutiple;

		// Token: 0x04009144 RID: 37188
		[SerializeField]
		private GameObject discountRoot;

		// Token: 0x04009145 RID: 37189
		[Header("Button")]
		[SerializeField]
		private GameObject buttonRoot;

		// Token: 0x04009146 RID: 37190
		[SerializeField]
		private Button tryOnButton;

		// Token: 0x04009147 RID: 37191
		[SerializeField]
		private Button buyButton;

		// Token: 0x04009148 RID: 37192
		[Header("Gameobject")]
		[SerializeField]
		private GameObject intergralRoot;

		// Token: 0x04009149 RID: 37193
		[SerializeField]
		private GameObject intergralFlagRoot;

		// Token: 0x0400914A RID: 37194
		[SerializeField]
		private GameObject singleRoot;

		// Token: 0x0400914B RID: 37195
		[SerializeField]
		private GameObject multiplePlictityRoot;

		// Token: 0x0400914C RID: 37196
		[Header("Text")]
		[SerializeField]
		private Text intergralLimtText;

		// Token: 0x0400914D RID: 37197
		[Space(10f)]
		[Header("CreditTicketFlag")]
		[Space(10f)]
		[SerializeField]
		private GameObject creditTicketFlag;

		// Token: 0x0400914E RID: 37198
		private bool _isUpdate;
	}
}
