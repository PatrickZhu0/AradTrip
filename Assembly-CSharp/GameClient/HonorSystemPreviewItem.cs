using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001675 RID: 5749
	public class HonorSystemPreviewItem : MonoBehaviour
	{
		// Token: 0x0600E201 RID: 57857 RVA: 0x003A11CB File Offset: 0x0039F5CB
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600E202 RID: 57858 RVA: 0x003A11D3 File Offset: 0x0039F5D3
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600E203 RID: 57859 RVA: 0x003A11E1 File Offset: 0x0039F5E1
		private void ClearData()
		{
			this._previewLevelItemDataModel = null;
			this._unlockShopItemList = null;
		}

		// Token: 0x0600E204 RID: 57860 RVA: 0x003A11F4 File Offset: 0x0039F5F4
		private void BindEvents()
		{
			if (this.unLockShopItemList != null)
			{
				this.unLockShopItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.unLockShopItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnUnLockShopItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.unLockShopItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnUnLockShopItemRecycle));
			}
		}

		// Token: 0x0600E205 RID: 57861 RVA: 0x003A126C File Offset: 0x0039F66C
		private void UnBindEvents()
		{
			if (this.unLockShopItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.unLockShopItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnUnLockShopItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.unLockShopItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnUnLockShopItemRecycle));
			}
		}

		// Token: 0x0600E206 RID: 57862 RVA: 0x003A12D8 File Offset: 0x0039F6D8
		private void OnUnLockShopItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._unlockShopItemList == null || this._unlockShopItemList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._unlockShopItemList.Count)
			{
				return;
			}
			HonorSystemUnLockShopItem component = item.GetComponent<HonorSystemUnLockShopItem>();
			int shopItemId = this._unlockShopItemList[item.m_index];
			if (component != null)
			{
				component.InitUnLockShopItem(shopItemId);
			}
		}

		// Token: 0x0600E207 RID: 57863 RVA: 0x003A1360 File Offset: 0x0039F760
		private void OnUnLockShopItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			HonorSystemUnLockShopItem component = item.GetComponent<HonorSystemUnLockShopItem>();
			if (component != null)
			{
				component.OnRecycleItem();
			}
		}

		// Token: 0x0600E208 RID: 57864 RVA: 0x003A1393 File Offset: 0x0039F793
		public void InitPreviewItem(PreviewLevelItemDataModel previewLevelItemDataModel)
		{
			this._previewLevelItemDataModel = previewLevelItemDataModel;
			if (this._previewLevelItemDataModel == null)
			{
				Logger.LogErrorFormat("PreviewLevelItemDataModel is null", new object[0]);
				return;
			}
			this._unlockShopItemList = this._previewLevelItemDataModel.UnLockShopItemList;
			this.InitBaseView();
		}

		// Token: 0x0600E209 RID: 57865 RVA: 0x003A13D0 File Offset: 0x0039F7D0
		private void InitBaseView()
		{
			if (this.specialFlag != null)
			{
				if (this._previewLevelItemDataModel.HonorSystemLevel == (int)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel)
				{
					CommonUtility.UpdateGameObjectVisible(this.specialFlag, true);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.specialFlag, false);
				}
			}
			string titleNameByTitleId = HonorSystemUtility.GetTitleNameByTitleId(this._previewLevelItemDataModel.TitleId);
			if (this.levelNameLabel != null)
			{
				this.levelNameLabel.text = titleNameByTitleId;
			}
			if (this.levelValueLabel != null)
			{
				string text = TR.Value("Honor_System_Current_Level_Format", this._previewLevelItemDataModel.HonorSystemLevel);
				this.levelValueLabel.text = text;
			}
			if (this.leftLevelFlagImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.leftLevelFlagImage, this._previewLevelItemDataModel.HonorLevelFlagPath, true);
			}
			if (this.rightLevelFlagImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.rightLevelFlagImage, this._previewLevelItemDataModel.HonorLevelFlagPath, true);
			}
			if (this.titleRewardLabel != null)
			{
				this.titleRewardLabel.text = titleNameByTitleId;
			}
			if (this.honorImg != null)
			{
				ETCImageLoader.LoadSprite(ref this.honorImg, HonorSystemUtility.GetTitleIconPathByTitleId(this._previewLevelItemDataModel.TitleId), true);
			}
		}

		// Token: 0x0600E20A RID: 57866 RVA: 0x003A1528 File Offset: 0x0039F928
		private void InitUnLockShopItemList()
		{
			if (this.unLockShopItemList == null)
			{
				return;
			}
			this.unLockShopItemList.ResetComUiListScriptEx();
			int elementAmount = 0;
			if (this._unlockShopItemList != null)
			{
				elementAmount = this._unlockShopItemList.Count;
			}
			this.unLockShopItemList.SetElementAmount(elementAmount);
		}

		// Token: 0x0600E20B RID: 57867 RVA: 0x003A1577 File Offset: 0x0039F977
		public void OnRecycleItem()
		{
			this.ClearData();
		}

		// Token: 0x04008742 RID: 34626
		private PreviewLevelItemDataModel _previewLevelItemDataModel;

		// Token: 0x04008743 RID: 34627
		private List<int> _unlockShopItemList;

		// Token: 0x04008744 RID: 34628
		[Space(10f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private GameObject specialFlag;

		// Token: 0x04008745 RID: 34629
		[SerializeField]
		private Text levelNameLabel;

		// Token: 0x04008746 RID: 34630
		[Space(10f)]
		[Header("LevelIcon")]
		[Space(10f)]
		[SerializeField]
		private Image leftLevelFlagImage;

		// Token: 0x04008747 RID: 34631
		[SerializeField]
		private Image rightLevelFlagImage;

		// Token: 0x04008748 RID: 34632
		[SerializeField]
		private Image honorImg;

		// Token: 0x04008749 RID: 34633
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private Text levelValueLabel;

		// Token: 0x0400874A RID: 34634
		[SerializeField]
		private Text needExpValueLabel;

		// Token: 0x0400874B RID: 34635
		[SerializeField]
		private Text titleRewardLabel;

		// Token: 0x0400874C RID: 34636
		[SerializeField]
		private Text shopDiscountValueLabel;

		// Token: 0x0400874D RID: 34637
		[Space(10f)]
		[Header("UnlockShopItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx unLockShopItemList;
	}
}
