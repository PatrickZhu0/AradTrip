using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B00 RID: 6912
	public class EnchantmentCardViceCardFrame : ClientFrame
	{
		// Token: 0x06010F5C RID: 69468 RVA: 0x004D895C File Offset: 0x004D6D5C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/EnchantmentCardUpgrade/EnchantmentCardViceCardFrame";
		}

		// Token: 0x06010F5D RID: 69469 RVA: 0x004D8963 File Offset: 0x004D6D63
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.mViceCardData = (this.userData as ViceCardDataModel);
			}
			this.GetEnchantmentCardViceCardList();
			this.InitViceCardScrollView();
		}

		// Token: 0x06010F5E RID: 69470 RVA: 0x004D898D File Offset: 0x004D6D8D
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitViceCardScrollView();
			this.mViceCardData = null;
			this.mEnchantmentCardViceCardList.Clear();
		}

		// Token: 0x06010F5F RID: 69471 RVA: 0x004D89A8 File Offset: 0x004D6DA8
		private void GetEnchantmentCardViceCardList()
		{
			if (this.mViceCardData == null || this.mViceCardData.mCurrentEnchantmentCardItemData == null)
			{
				return;
			}
			this.mEnchantmentCardViceCardList.Clear();
			this.mEnchantmentCardViceCardList = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardViceCardDatas(this.mViceCardData.mCurrentEnchantmentCardItemData, this.mViceCardData.mUpgradePrecType);
			this.mEnchantmentCardViceCardList.Sort();
		}

		// Token: 0x06010F60 RID: 69472 RVA: 0x004D8A10 File Offset: 0x004D6E10
		private void InitViceCardScrollView()
		{
			if (this.mViceCardScrollView != null)
			{
				this.mViceCardScrollView.Initialize();
				ComUIListScript comUIListScript = this.mViceCardScrollView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mViceCardScrollView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mViceCardScrollView;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mViceCardScrollView;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
				this.mViceCardScrollView.SetElementAmount(this.mEnchantmentCardViceCardList.Count);
			}
		}

		// Token: 0x06010F61 RID: 69473 RVA: 0x004D8AEC File Offset: 0x004D6EEC
		private void UnInitViceCardScrollView()
		{
			if (this.mViceCardScrollView != null)
			{
				ComUIListScript comUIListScript = this.mViceCardScrollView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mViceCardScrollView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mViceCardScrollView;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mViceCardScrollView;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06010F62 RID: 69474 RVA: 0x004D8BA6 File Offset: 0x004D6FA6
		private EnchantmentCardViceCardItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<EnchantmentCardViceCardItem>();
		}

		// Token: 0x06010F63 RID: 69475 RVA: 0x004D8BB0 File Offset: 0x004D6FB0
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			EnchantmentCardViceCardItem enchantmentCardViceCardItem = item.gameObjectBindScript as EnchantmentCardViceCardItem;
			if (enchantmentCardViceCardItem != null && item.m_index >= 0 && item.m_index < this.mEnchantmentCardViceCardList.Count)
			{
				enchantmentCardViceCardItem.OnItemVisiable(this.mEnchantmentCardViceCardList[item.m_index]);
			}
		}

		// Token: 0x06010F64 RID: 69476 RVA: 0x004D8C10 File Offset: 0x004D7010
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			EnchantmentCardViceCardItem enchantmentCardViceCardItem = item.gameObjectBindScript as EnchantmentCardViceCardItem;
			if (enchantmentCardViceCardItem != null)
			{
				this.OnEnchantmentCardViceCardClick(enchantmentCardViceCardItem.ViceCardData);
			}
		}

		// Token: 0x06010F65 RID: 69477 RVA: 0x004D8C44 File Offset: 0x004D7044
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			EnchantmentCardViceCardItem enchantmentCardViceCardItem = item.gameObjectBindScript as EnchantmentCardViceCardItem;
			if (enchantmentCardViceCardItem != null)
			{
				enchantmentCardViceCardItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010F66 RID: 69478 RVA: 0x004D8C70 File Offset: 0x004D7070
		private void OnEnchantmentCardViceCardClick(EnchantmentCardViceCardData viceCardData)
		{
			if (this.mViceCardData.mOnEnchantmentCardViceCardClick != null)
			{
				this.mViceCardData.mOnEnchantmentCardViceCardClick(viceCardData);
			}
			this.frameMgr.CloseFrame<EnchantmentCardViceCardFrame>(this, false);
		}

		// Token: 0x06010F67 RID: 69479 RVA: 0x004D8CA0 File Offset: 0x004D70A0
		protected sealed override void _bindExUI()
		{
			this.mViceCardScrollView = this.mBind.GetCom<ComUIListScript>("ViceCardScrollView");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x06010F68 RID: 69480 RVA: 0x004D8D06 File Offset: 0x004D7106
		protected sealed override void _unbindExUI()
		{
			this.mViceCardScrollView = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x06010F69 RID: 69481 RVA: 0x004D8D43 File Offset: 0x004D7143
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<EnchantmentCardViceCardFrame>(this, false);
		}

		// Token: 0x0400AE6A RID: 44650
		private ViceCardDataModel mViceCardData;

		// Token: 0x0400AE6B RID: 44651
		private List<EnchantmentCardViceCardData> mEnchantmentCardViceCardList = new List<EnchantmentCardViceCardData>();

		// Token: 0x0400AE6C RID: 44652
		private ComUIListScript mViceCardScrollView;

		// Token: 0x0400AE6D RID: 44653
		private Button mClose;
	}
}
