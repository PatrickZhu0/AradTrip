using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B49 RID: 6985
	public class InscriptionHoleItem : MonoBehaviour
	{
		// Token: 0x06011239 RID: 70201 RVA: 0x004EB6F8 File Offset: 0x004E9AF8
		private void Awake()
		{
			if (this.mSelectedTog != null)
			{
				this.mSelectedTog.onValueChanged.RemoveAllListeners();
				this.mSelectedTog.onValueChanged.AddListener(new UnityAction<bool>(this.OnSelectedInscriptionHoleTogClick));
			}
			if (this.mCanOpenHoleBtn != null)
			{
				this.mCanOpenHoleBtn.onClick.RemoveAllListeners();
				this.mCanOpenHoleBtn.onClick.AddListener(new UnityAction(this.OnOpenInscriptionHoleClick));
			}
			if (this.mCanBeSetBtn != null)
			{
				this.mCanBeSetBtn.onClick.RemoveAllListeners();
				this.mCanBeSetBtn.onClick.AddListener(new UnityAction(this.OnCanBeSetBtnClick));
			}
			if (this.mCanBeSetToSetIncriptionIconBtn != null)
			{
				this.mCanBeSetToSetIncriptionIconBtn.onClick.RemoveAllListeners();
				this.mCanBeSetToSetIncriptionIconBtn.onClick.AddListener(new UnityAction(this.OnCanBeSetBtnClick));
			}
			if (this.mToSetIncriptionIconBtn != null)
			{
				this.mToSetIncriptionIconBtn.onClick.RemoveAllListeners();
				this.mToSetIncriptionIconBtn.onClick.AddListener(new UnityAction(this.OnToSetInscriptionItemClick));
			}
			if (this.mReplaceNewInscriptionBtn != null)
			{
				this.mReplaceNewInscriptionBtn.onClick.RemoveAllListeners();
				this.mReplaceNewInscriptionBtn.onClick.AddListener(new UnityAction(this.OnToSetInscriptionItemClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSelectedInscriptionHole, new ClientEventSystem.UIEventHandler(this.OnSelectedInscriptionHole));
		}

		// Token: 0x0601123A RID: 70202 RVA: 0x004EB890 File Offset: 0x004E9C90
		private void OnDestroy()
		{
			this.mData = null;
			this.mState = InscriptionMosaicState.None;
			this.iInscriptionHoleIndex = -1;
			this.mCurrentSelectedItemData = null;
			this.inscriptionHoleSetTable = null;
			this.mCurrentSelectedInscriptionItem = null;
			this.mOnSetInscriptionItemData = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSelectedInscriptionHole, new ClientEventSystem.UIEventHandler(this.OnSelectedInscriptionHole));
		}

		// Token: 0x0601123B RID: 70203 RVA: 0x004EB8EC File Offset: 0x004E9CEC
		public void OnItemVisiable(InscriptionHoleData data, ItemData currentSelectedItemData, ToggleGroup group, bool isSelected, OnSetInscriptionItemData onSet)
		{
			this.mData = data;
			if (this.mSelectedTog != null)
			{
				this.mSelectedTog.group = group;
			}
			this.mSelectedTog.image.raycastTarget = true;
			this.mSelectedTog.isOn = false;
			this.mCurrentSelectedItemData = currentSelectedItemData;
			this.iInscriptionHoleIndex = data.Index;
			this.mOnSetInscriptionItemData = onSet;
			if (isSelected)
			{
				this.mSelectedTog.isOn = true;
			}
			this.UpdateState();
			this.UpdateInterface();
		}

		// Token: 0x0601123C RID: 70204 RVA: 0x004EB974 File Offset: 0x004E9D74
		private void UpdateState()
		{
			this.inscriptionHoleSetTable = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionHoleSetTable>(this.mData.Type, string.Empty, string.Empty);
			if (!this.mData.IsOpenHole)
			{
				this.mStateControl.Key = "CanOpenHole";
				this.mState = InscriptionMosaicState.CanOpenHole;
			}
			else if (this.mData.InscriptionId == 0)
			{
				this.mStateControl.Key = "CanBeSet";
				this.mState = InscriptionMosaicState.CanBeSet;
			}
			else if (this.mData.InscriptionId > 0)
			{
				this.mStateControl.Key = "HasBeenSet";
				this.mState = InscriptionMosaicState.HasBeenSet;
			}
		}

		// Token: 0x0601123D RID: 70205 RVA: 0x004EBA28 File Offset: 0x004E9E28
		private void UpdateInterface()
		{
			switch (this.mState)
			{
			case InscriptionMosaicState.CanOpenHole:
				this.InitCanOpenHoleInfo();
				break;
			case InscriptionMosaicState.CanBeSet:
				this.InitCanBeSetInfo();
				break;
			case InscriptionMosaicState.HasBeenSet:
				this.InitHasBeenSetInfo();
				break;
			case InscriptionMosaicState.Replace:
				this.UpdateReplaceInfo();
				break;
			}
		}

		// Token: 0x0601123E RID: 70206 RVA: 0x004EBA8C File Offset: 0x004E9E8C
		private void InitCanOpenHoleInfo()
		{
			if (this.inscriptionHoleSetTable != null && this.mCanOpenHoleIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mCanOpenHoleIcon, this.inscriptionHoleSetTable.InscriptionHolePicture, true);
			}
			EquipInscriptionHoleData openInscriptionHoleConsume = DataManager<InscriptionMosaicDataManager>.GetInstance().GetOpenInscriptionHoleConsume(this.mCurrentSelectedItemData);
			if (openInscriptionHoleConsume.iItemConsume != null && openInscriptionHoleConsume.iGoldConsume != null)
			{
				int itemCount = DataManager<ItemDataManager>.GetInstance().GetItemCount(openInscriptionHoleConsume.iItemConsume.itemId);
				if (itemCount <= 0)
				{
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(openInscriptionHoleConsume.iGoldConsume.itemId, true);
					if (ownedItemCount > 0 && ownedItemCount >= openInscriptionHoleConsume.iGoldConsume.count)
					{
						this.SetConsumeInfo(openInscriptionHoleConsume.iGoldConsume, false);
					}
					else
					{
						this.SetConsumeInfo(openInscriptionHoleConsume.iItemConsume, true);
					}
				}
				else if (itemCount >= openInscriptionHoleConsume.iItemConsume.count)
				{
					this.SetConsumeInfo(openInscriptionHoleConsume.iItemConsume, false);
				}
				else
				{
					this.SetConsumeInfo(openInscriptionHoleConsume.iItemConsume, true);
				}
			}
			else if (openInscriptionHoleConsume.iItemConsume != null && openInscriptionHoleConsume.iGoldConsume == null)
			{
				int itemCount2 = DataManager<ItemDataManager>.GetInstance().GetItemCount(openInscriptionHoleConsume.iItemConsume.itemId);
				if (itemCount2 >= openInscriptionHoleConsume.iItemConsume.count)
				{
					this.SetConsumeInfo(openInscriptionHoleConsume.iItemConsume, false);
				}
				else
				{
					this.SetConsumeInfo(openInscriptionHoleConsume.iItemConsume, true);
				}
			}
			else if (openInscriptionHoleConsume.iItemConsume == null && openInscriptionHoleConsume.iGoldConsume != null)
			{
				int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(openInscriptionHoleConsume.iGoldConsume.itemId, true);
				if (ownedItemCount2 > 0 && ownedItemCount2 >= openInscriptionHoleConsume.iGoldConsume.count)
				{
					this.SetConsumeInfo(openInscriptionHoleConsume.iGoldConsume, false);
				}
				else
				{
					this.SetConsumeInfo(openInscriptionHoleConsume.iGoldConsume, true);
				}
			}
		}

		// Token: 0x0601123F RID: 70207 RVA: 0x004EBC64 File Offset: 0x004EA064
		private void SetConsumeInfo(InscriptionConsume consume, bool isShowRed = false)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(consume.itemId, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("ItemTable id is Null id = {0}", new object[]
				{
					consume.itemId
				});
			}
			if (itemData.SubType == 17)
			{
				this.mGoldRoot.CustomActive(true);
				this.mTapperRoot.CustomActive(false);
				if (this.mExpendIconBG != null)
				{
					ETCImageLoader.LoadSprite(ref this.mExpendIconBG, itemData.GetQualityInfo().Background, true);
				}
				if (this.mExpendIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mExpendIcon, itemData.Icon, true);
				}
				if (this.mExpendCount != null)
				{
					this.mExpendCount.text = consume.count.ToString();
				}
				if (isShowRed)
				{
					this.mExpendCount.color = Color.red;
				}
				else
				{
					this.mExpendCount.color = Color.white;
				}
			}
			else
			{
				this.mGoldRoot.CustomActive(false);
				this.mTapperRoot.CustomActive(true);
				if (this.mTapperIconBG != null)
				{
					ETCImageLoader.LoadSprite(ref this.mTapperIconBG, itemData.GetQualityInfo().Background, true);
				}
				if (this.mTapperIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mTapperIcon, itemData.Icon, true);
				}
				if (isShowRed)
				{
					this.mTapperExpendCount.text = TR.Value("Inscription_Expend_Red", itemData.GetColorName(string.Empty, false), consume.count);
				}
				else
				{
					this.mTapperExpendCount.text = TR.Value("Inscription_Expend_Green", itemData.GetColorName(string.Empty, false), consume.count);
				}
			}
		}

		// Token: 0x06011240 RID: 70208 RVA: 0x004EBE3C File Offset: 0x004EA23C
		private void OnOpenInscriptionHoleClick()
		{
			EquipInscriptionHoleData openInscriptionHoleConsume = DataManager<InscriptionMosaicDataManager>.GetInstance().GetOpenInscriptionHoleConsume(this.mCurrentSelectedItemData);
			if (openInscriptionHoleConsume != null)
			{
				if (openInscriptionHoleConsume.iItemConsume != null && openInscriptionHoleConsume.iGoldConsume != null)
				{
					int itemCount = DataManager<ItemDataManager>.GetInstance().GetItemCount(openInscriptionHoleConsume.iItemConsume.itemId);
					if (itemCount <= 0)
					{
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(openInscriptionHoleConsume.iGoldConsume.itemId, true);
						if (ownedItemCount > 0 && ownedItemCount >= openInscriptionHoleConsume.iGoldConsume.count)
						{
							this.OnSendEquipmentOpenInscriptionHole(openInscriptionHoleConsume.iGoldConsume);
						}
						else
						{
							ItemComeLink.OnLink(openInscriptionHoleConsume.iItemConsume.itemId, openInscriptionHoleConsume.iItemConsume.count - itemCount, true, new ComLinkFrame.OnClick(this.OnSceneEquipInscriptionOpenReq), false, false, false, null, string.Empty);
						}
					}
					else if (itemCount >= openInscriptionHoleConsume.iItemConsume.count)
					{
						this.OnSendEquipmentOpenInscriptionHole(openInscriptionHoleConsume.iItemConsume);
					}
					else
					{
						ItemComeLink.OnLink(openInscriptionHoleConsume.iItemConsume.itemId, openInscriptionHoleConsume.iItemConsume.count - itemCount, true, new ComLinkFrame.OnClick(this.OnSceneEquipInscriptionOpenReq), false, false, false, null, string.Empty);
					}
				}
				else if (openInscriptionHoleConsume.iItemConsume != null && openInscriptionHoleConsume.iGoldConsume == null)
				{
					int itemCount2 = DataManager<ItemDataManager>.GetInstance().GetItemCount(openInscriptionHoleConsume.iItemConsume.itemId);
					if (itemCount2 >= openInscriptionHoleConsume.iItemConsume.count)
					{
						this.OnSendEquipmentOpenInscriptionHole(openInscriptionHoleConsume.iItemConsume);
					}
					else
					{
						ItemComeLink.OnLink(openInscriptionHoleConsume.iItemConsume.itemId, openInscriptionHoleConsume.iItemConsume.count - itemCount2, true, new ComLinkFrame.OnClick(this.OnSceneEquipInscriptionOpenReq), false, false, false, null, string.Empty);
					}
				}
				else if (openInscriptionHoleConsume.iItemConsume == null && openInscriptionHoleConsume.iGoldConsume != null)
				{
					int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(openInscriptionHoleConsume.iGoldConsume.itemId, true);
					if (ownedItemCount2 > 0 && ownedItemCount2 >= openInscriptionHoleConsume.iGoldConsume.count)
					{
						this.OnSendEquipmentOpenInscriptionHole(openInscriptionHoleConsume.iGoldConsume);
					}
					else
					{
						ItemComeLink.OnLink(openInscriptionHoleConsume.iGoldConsume.itemId, openInscriptionHoleConsume.iGoldConsume.count - ownedItemCount2, true, new ComLinkFrame.OnClick(this.OnSceneEquipInscriptionOpenReq), false, false, false, null, string.Empty);
					}
				}
			}
		}

		// Token: 0x06011241 RID: 70209 RVA: 0x004EC080 File Offset: 0x004EA480
		private void OnSendEquipmentOpenInscriptionHole(InscriptionConsume consume)
		{
			if (consume == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(consume.itemId, 100, 0);
			if (itemData == null)
			{
				return;
			}
			string msgContent = string.Format("是否花费{0}*{1}开启一个插槽?", itemData.GetColorName(string.Empty, false), consume.count);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, new UnityAction(this.OnSceneEquipInscriptionOpenReq), null, 0f, false);
		}

		// Token: 0x06011242 RID: 70210 RVA: 0x004EC0E5 File Offset: 0x004EA4E5
		private void OnSceneEquipInscriptionOpenReq()
		{
			if (this.mCurrentSelectedItemData == null)
			{
				return;
			}
			DataManager<InscriptionMosaicDataManager>.GetInstance().OnSceneEquipInscriptionOpenReq(this.mCurrentSelectedItemData.GUID, (uint)this.iInscriptionHoleIndex);
		}

		// Token: 0x06011243 RID: 70211 RVA: 0x004EC110 File Offset: 0x004EA510
		private void InitCanBeSetInfo()
		{
			this.mCanBeSetSelectInscriptionRoot.CustomActive(true);
			this.mCanBeSetToSetRoot.CustomActive(false);
			if (this.inscriptionHoleSetTable != null && this.mCanBeSetIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mCanBeSetIcon, this.inscriptionHoleSetTable.InscriptionHolePicture, true);
			}
		}

		// Token: 0x06011244 RID: 70212 RVA: 0x004EC16C File Offset: 0x004EA56C
		private void OnCanBeSetBtnClick()
		{
			InscriptionItemDataModel inscriptionItemDataModel = new InscriptionItemDataModel();
			inscriptionItemDataModel.InscriptionHoleColor = this.mData.Type;
			InscriptionItemDataModel inscriptionItemDataModel2 = inscriptionItemDataModel;
			inscriptionItemDataModel2.OnSelectedClick = (UnityAction<ItemData>)Delegate.Combine(inscriptionItemDataModel2.OnSelectedClick, new UnityAction<ItemData>(this.UpdateCanBeSetInscriptionItemInfo));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<InscriptionItemFrame>(FrameLayer.Middle, inscriptionItemDataModel, string.Empty);
		}

		// Token: 0x06011245 RID: 70213 RVA: 0x004EC1C4 File Offset: 0x004EA5C4
		private void UpdateCanBeSetInscriptionItemInfo(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.mCurrentSelectedInscriptionItem = ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0);
			this.mCurrentSelectedInscriptionItem.GUID = itemData.GUID;
			this.mCanBeSetSelectInscriptionRoot.CustomActive(false);
			this.mCanBeSetToSetRoot.CustomActive(true);
			if (this.mCanBeSetToSetInscriptionQualityBox != null)
			{
				this.mCanBeSetToSetInscriptionQualityBox.color = this.mCurrentSelectedInscriptionItem.GetQualityInfo().Col;
			}
			if (this.mCanBeSetToSetInscriptionIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mCanBeSetToSetInscriptionIcon, this.mCurrentSelectedInscriptionItem.Icon, true);
			}
			if (this.mCanBeSetToSetInscriptionName != null)
			{
				this.mCanBeSetToSetInscriptionName.text = this.mCurrentSelectedInscriptionItem.GetColorName(string.Empty, false);
			}
			if (this.mCanBeSetToSetInscriptionAttr != null)
			{
				this.mCanBeSetToSetInscriptionAttr.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(this.mCurrentSelectedInscriptionItem.TableID, true);
			}
			this.OnSetInscriptionItem();
		}

		// Token: 0x06011246 RID: 70214 RVA: 0x004EC2D0 File Offset: 0x004EA6D0
		private void InitHasBeenSetInfo()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mData.InscriptionId, 100, 0);
			if (itemData != null)
			{
				if (this.mToSetIncriptionQualityBox != null)
				{
					this.mToSetIncriptionQualityBox.color = itemData.GetQualityInfo().Col;
				}
				if (this.mToSetIncriptionIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mToSetIncriptionIcon, itemData.Icon, true);
				}
				if (this.mToSetInscriptionName != null)
				{
					this.mToSetInscriptionName.text = itemData.GetColorName(string.Empty, false);
				}
				if (this.mToSetInscriptionAttr != null)
				{
					this.mToSetInscriptionAttr.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(itemData.TableID, true);
				}
			}
		}

		// Token: 0x06011247 RID: 70215 RVA: 0x004EC398 File Offset: 0x004EA798
		private void OnToSetInscriptionItemClick()
		{
			InscriptionItemDataModel inscriptionItemDataModel = new InscriptionItemDataModel();
			inscriptionItemDataModel.InscriptionHoleColor = this.mData.Type;
			InscriptionItemDataModel inscriptionItemDataModel2 = inscriptionItemDataModel;
			inscriptionItemDataModel2.OnSelectedClick = (UnityAction<ItemData>)Delegate.Combine(inscriptionItemDataModel2.OnSelectedClick, new UnityAction<ItemData>(this.UpdateReplaceInscriptionItemInfo));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<InscriptionItemFrame>(FrameLayer.Middle, inscriptionItemDataModel, string.Empty);
		}

		// Token: 0x06011248 RID: 70216 RVA: 0x004EC3F0 File Offset: 0x004EA7F0
		private void UpdateReplaceInscriptionItemInfo(ItemData item)
		{
			if (item == null)
			{
				return;
			}
			this.mCurrentSelectedInscriptionItem = ItemDataManager.CreateItemDataFromTable(item.TableID, 100, 0);
			this.mCurrentSelectedInscriptionItem.GUID = item.GUID;
			this.mState = InscriptionMosaicState.Replace;
			this.mStateControl.Key = "Replace";
			this.UpdateInterface();
			this.OnSetInscriptionItem();
		}

		// Token: 0x06011249 RID: 70217 RVA: 0x004EC44C File Offset: 0x004EA84C
		private void UpdateReplaceInfo()
		{
			this.mReplaceNewSeletInscriptionRoot.CustomActive(false);
			this.mReplaceNewInscriptionRoot.CustomActive(true);
			ItemData itemData = null;
			if (this.mData != null)
			{
				itemData = ItemDataManager.CreateItemDataFromTable(this.mData.InscriptionId, 100, 0);
			}
			if (itemData != null)
			{
				if (this.mReplaceOldInscriptionQualityBox != null)
				{
					this.mReplaceOldInscriptionQualityBox.color = itemData.GetQualityInfo().Col;
				}
				if (this.mReplaceOldInscriptionIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mReplaceOldInscriptionIcon, itemData.Icon, true);
				}
				if (this.mReplaceOldInscriptionName != null)
				{
					this.mReplaceOldInscriptionName.text = TR.Value("Inscription_Old", itemData.GetColorName(string.Empty, false));
				}
				if (this.mReplaceOldInscriptionAttr != null)
				{
					this.mReplaceOldInscriptionAttr.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(itemData.TableID, true);
				}
			}
			if (this.mCurrentSelectedInscriptionItem != null)
			{
				if (this.mReplaceNewInscriptionQualityBox != null)
				{
					ItemData.QualityInfo qualityInfo = this.mCurrentSelectedInscriptionItem.GetQualityInfo();
					if (qualityInfo != null)
					{
						this.mReplaceNewInscriptionQualityBox.color = qualityInfo.Col;
					}
				}
				if (this.mReplaceNewInscriptionIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mReplaceNewInscriptionIcon, this.mCurrentSelectedInscriptionItem.Icon, true);
				}
				if (this.mReplaceNewInscriptionName != null)
				{
					this.mReplaceNewInscriptionName.text = TR.Value("Inscription_New", this.mCurrentSelectedInscriptionItem.GetColorName(string.Empty, false));
				}
				if (this.mReplaceNewInscriptionAttr != null)
				{
					this.mReplaceNewInscriptionAttr.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(this.mCurrentSelectedInscriptionItem.TableID, true);
				}
			}
		}

		// Token: 0x0601124A RID: 70218 RVA: 0x004EC613 File Offset: 0x004EAA13
		private void OnSetInscriptionItem()
		{
			if (this.mOnSetInscriptionItemData != null)
			{
				this.mOnSetInscriptionItemData(this.mCurrentSelectedInscriptionItem, this.iInscriptionHoleIndex);
			}
		}

		// Token: 0x0601124B RID: 70219 RVA: 0x004EC637 File Offset: 0x004EAA37
		public void OnCancelInscription()
		{
			this.mCurrentSelectedInscriptionItem = null;
			this.OnSetInscriptionItem();
		}

		// Token: 0x0601124C RID: 70220 RVA: 0x004EC646 File Offset: 0x004EAA46
		private void OnSelectedInscriptionHoleTogClick(bool value)
		{
			if (value)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSelectedInscriptionHole, this.iInscriptionHoleIndex, null, null, null);
			}
		}

		// Token: 0x0601124D RID: 70221 RVA: 0x004EC66C File Offset: 0x004EAA6C
		private void OnSelectedInscriptionHole(UIEvent uiEvent)
		{
			int num = (int)uiEvent.Param1;
			if (num == this.iInscriptionHoleIndex)
			{
				this.mSelectedTog.image.raycastTarget = false;
				return;
			}
			this.mSelectedTog.image.raycastTarget = true;
		}

		// Token: 0x0400B0BE RID: 45246
		[SerializeField]
		private StateController mStateControl;

		// Token: 0x0400B0BF RID: 45247
		[SerializeField]
		private Button mCanOpenHoleBtn;

		// Token: 0x0400B0C0 RID: 45248
		[SerializeField]
		private Button mCanBeSetBtn;

		// Token: 0x0400B0C1 RID: 45249
		[SerializeField]
		private Button mCanBeSetToSetIncriptionIconBtn;

		// Token: 0x0400B0C2 RID: 45250
		[SerializeField]
		private Button mToSetIncriptionIconBtn;

		// Token: 0x0400B0C3 RID: 45251
		[SerializeField]
		private Button mReplaceNewInscriptionBtn;

		// Token: 0x0400B0C4 RID: 45252
		[SerializeField]
		private Toggle mSelectedTog;

		// Token: 0x0400B0C5 RID: 45253
		[SerializeField]
		private Image mExpendIconBG;

		// Token: 0x0400B0C6 RID: 45254
		[SerializeField]
		private Image mExpendIcon;

		// Token: 0x0400B0C7 RID: 45255
		[SerializeField]
		private Image mTapperIconBG;

		// Token: 0x0400B0C8 RID: 45256
		[SerializeField]
		private Image mTapperIcon;

		// Token: 0x0400B0C9 RID: 45257
		[SerializeField]
		private Image mCanOpenHoleIcon;

		// Token: 0x0400B0CA RID: 45258
		[SerializeField]
		private Image mCanBeSetIcon;

		// Token: 0x0400B0CB RID: 45259
		[SerializeField]
		private Image mCanBeSetToSetInscriptionQualityBox;

		// Token: 0x0400B0CC RID: 45260
		[SerializeField]
		private Image mCanBeSetToSetInscriptionIcon;

		// Token: 0x0400B0CD RID: 45261
		[SerializeField]
		private Image mToSetIncriptionQualityBox;

		// Token: 0x0400B0CE RID: 45262
		[SerializeField]
		private Image mToSetIncriptionIcon;

		// Token: 0x0400B0CF RID: 45263
		[SerializeField]
		private Image mReplaceOldInscriptionQualityBox;

		// Token: 0x0400B0D0 RID: 45264
		[SerializeField]
		private Image mReplaceNewInscriptionQualityBox;

		// Token: 0x0400B0D1 RID: 45265
		[SerializeField]
		private Image mReplaceOldInscriptionIcon;

		// Token: 0x0400B0D2 RID: 45266
		[SerializeField]
		private Image mReplaceNewInscriptionIcon;

		// Token: 0x0400B0D3 RID: 45267
		[SerializeField]
		private Text mExpendCount;

		// Token: 0x0400B0D4 RID: 45268
		[SerializeField]
		private Text mTapperExpendCount;

		// Token: 0x0400B0D5 RID: 45269
		[SerializeField]
		private Text mCanBeSetToSetInscriptionName;

		// Token: 0x0400B0D6 RID: 45270
		[SerializeField]
		private Text mCanBeSetToSetInscriptionAttr;

		// Token: 0x0400B0D7 RID: 45271
		[SerializeField]
		private Text mToSetInscriptionName;

		// Token: 0x0400B0D8 RID: 45272
		[SerializeField]
		private Text mToSetInscriptionAttr;

		// Token: 0x0400B0D9 RID: 45273
		[SerializeField]
		private Text mReplaceOldInscriptionName;

		// Token: 0x0400B0DA RID: 45274
		[SerializeField]
		private Text mReplaceNewInscriptionName;

		// Token: 0x0400B0DB RID: 45275
		[SerializeField]
		private Text mReplaceOldInscriptionAttr;

		// Token: 0x0400B0DC RID: 45276
		[SerializeField]
		private Text mReplaceNewInscriptionAttr;

		// Token: 0x0400B0DD RID: 45277
		[SerializeField]
		private GameObject mCanBeSetSelectInscriptionRoot;

		// Token: 0x0400B0DE RID: 45278
		[SerializeField]
		private GameObject mCanBeSetToSetRoot;

		// Token: 0x0400B0DF RID: 45279
		[SerializeField]
		private GameObject mSelectedRoot;

		// Token: 0x0400B0E0 RID: 45280
		[SerializeField]
		private GameObject mGoldRoot;

		// Token: 0x0400B0E1 RID: 45281
		[SerializeField]
		private GameObject mTapperRoot;

		// Token: 0x0400B0E2 RID: 45282
		[SerializeField]
		private GameObject mReplaceNewInscriptionRoot;

		// Token: 0x0400B0E3 RID: 45283
		[SerializeField]
		private GameObject mReplaceNewSeletInscriptionRoot;

		// Token: 0x0400B0E4 RID: 45284
		private InscriptionHoleData mData;

		// Token: 0x0400B0E5 RID: 45285
		private InscriptionMosaicState mState;

		// Token: 0x0400B0E6 RID: 45286
		private int iInscriptionHoleIndex;

		// Token: 0x0400B0E7 RID: 45287
		private ItemData mCurrentSelectedItemData;

		// Token: 0x0400B0E8 RID: 45288
		private InscriptionHoleSetTable inscriptionHoleSetTable;

		// Token: 0x0400B0E9 RID: 45289
		private ItemData mCurrentSelectedInscriptionItem;

		// Token: 0x0400B0EA RID: 45290
		private OnSetInscriptionItemData mOnSetInscriptionItemData;
	}
}
