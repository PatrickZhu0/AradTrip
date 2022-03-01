using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020016EB RID: 5867
	public class ItemTipModelAvatarRootView : MonoBehaviour
	{
		// Token: 0x0600E5D9 RID: 58841 RVA: 0x003BE91C File Offset: 0x003BCD1C
		private void OnDestroy()
		{
			this._itemTable = null;
			this._itemTipShowAvatarType = ItemTipShowAvatarType.None;
			this._showModelAvatarDelayTimeInterval = -1f;
			this._itemTipModelAvatarLayerIndex = 0;
			this._giftPackModelAvatarDataModel = null;
			this._otherProfessionId = 0;
		}

		// Token: 0x0600E5DA RID: 58842 RVA: 0x003BE94C File Offset: 0x003BCD4C
		public void UpdateModelAvatarRootViewByCompareItemType(ItemTable itemTable, ItemTipShowAvatarType itemTipShowAvatarType, int itemTipModelAvatarLayerIndex = 0, int otherProfessionId = 0)
		{
			this._itemTipShowAvatarType = itemTipShowAvatarType;
			this._itemTable = itemTable;
			this._otherProfessionId = otherProfessionId;
			if (this._itemTable == null)
			{
				return;
			}
			this._itemTipModelAvatarLayerIndex = itemTipModelAvatarLayerIndex;
			this.OnShowModelAvatarView();
		}

		// Token: 0x0600E5DB RID: 58843 RVA: 0x003BE980 File Offset: 0x003BCD80
		public void UpdateModelAvatarRootViewBySingleItemType(ItemTable itemTable, ItemTipShowAvatarType itemTipShowAvatarType, int itemTipModelAvatarLayerIndex, GiftPackModelAvatarDataModel giftPackModelAvatarDataModel = null, int otherProfessionId = 0)
		{
			this.ResetShowModelAvatarDelayTimeInterval();
			this._itemTipShowAvatarType = itemTipShowAvatarType;
			this._itemTable = itemTable;
			this._giftPackModelAvatarDataModel = giftPackModelAvatarDataModel;
			this._otherProfessionId = otherProfessionId;
			if (this._itemTable == null)
			{
				return;
			}
			this._itemTipModelAvatarLayerIndex = itemTipModelAvatarLayerIndex;
			this._showModelAvatarDelayTimeInterval = 0f;
		}

		// Token: 0x0600E5DC RID: 58844 RVA: 0x003BE9D0 File Offset: 0x003BCDD0
		private void Update()
		{
			if (this._itemTipShowAvatarType != ItemTipShowAvatarType.SingleTipType)
			{
				return;
			}
			if (this._showModelAvatarDelayTimeInterval < 0f)
			{
				return;
			}
			this._showModelAvatarDelayTimeInterval += Time.deltaTime;
			if (this._showModelAvatarDelayTimeInterval >= 0.3f)
			{
				this.OnShowModelAvatarView();
			}
		}

		// Token: 0x0600E5DD RID: 58845 RVA: 0x003BEA23 File Offset: 0x003BCE23
		public void OnDisappearShowModelAvatarView()
		{
			this.ResetShowModelAvatarDelayTimeInterval();
			if (this._itemTipModelAvatarController != null)
			{
				this._itemTipModelAvatarController.ResetModelAvatarEx();
			}
			CommonUtility.UpdateGameObjectVisible(this.tipModelAvatarRoot, false);
		}

		// Token: 0x0600E5DE RID: 58846 RVA: 0x003BEA53 File Offset: 0x003BCE53
		public void OnShowModelAvatarView()
		{
			this.ResetShowModelAvatarDelayTimeInterval();
			this.ShowModelAvatarControllerView();
		}

		// Token: 0x0600E5DF RID: 58847 RVA: 0x003BEA64 File Offset: 0x003BCE64
		private void ShowModelAvatarControllerView()
		{
			if (this.tipModelAvatarRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.tipModelAvatarRoot, true);
			if (this._itemTipModelAvatarController == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.tipModelAvatarRoot);
				if (gameObject != null)
				{
					this._itemTipModelAvatarController = gameObject.GetComponent<ItemTipModelAvatarController>();
				}
			}
			if (this._itemTipModelAvatarController != null)
			{
				this._itemTipModelAvatarController.UpdateModelAvatarController(this._itemTable, this._itemTipModelAvatarLayerIndex, this._giftPackModelAvatarDataModel, this._otherProfessionId);
			}
		}

		// Token: 0x0600E5E0 RID: 58848 RVA: 0x003BEAF8 File Offset: 0x003BCEF8
		private void ResetShowModelAvatarDelayTimeInterval()
		{
			this._showModelAvatarDelayTimeInterval = -1f;
		}

		// Token: 0x04008B29 RID: 35625
		private ItemTipShowAvatarType _itemTipShowAvatarType;

		// Token: 0x04008B2A RID: 35626
		private ItemTipModelAvatarController _itemTipModelAvatarController;

		// Token: 0x04008B2B RID: 35627
		private ItemTable _itemTable;

		// Token: 0x04008B2C RID: 35628
		private int _itemTipModelAvatarLayerIndex;

		// Token: 0x04008B2D RID: 35629
		private int _otherProfessionId;

		// Token: 0x04008B2E RID: 35630
		private const float ShowModelAvatarDelayTime = 0.3f;

		// Token: 0x04008B2F RID: 35631
		private float _showModelAvatarDelayTimeInterval = -1f;

		// Token: 0x04008B30 RID: 35632
		private GiftPackModelAvatarDataModel _giftPackModelAvatarDataModel;

		// Token: 0x04008B31 RID: 35633
		[Space(10f)]
		[Header("ItemTipModelAvatarRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject tipModelAvatarRoot;
	}
}
