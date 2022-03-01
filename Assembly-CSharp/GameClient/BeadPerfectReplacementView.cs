using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AC7 RID: 6855
	internal class BeadPerfectReplacementView : MonoBehaviour, IDisposable
	{
		// Token: 0x06010D56 RID: 68950 RVA: 0x004CCAE8 File Offset: 0x004CAEE8
		public void InitView(BeadPerfectReplacementModel mModel, BeadPerfectReplacementView.OnMountedItemSelect onMountedItemSelect, BeadPerfectReplacementView.OnUnMountedItemSelect onUnMountedItemSelect, BeadPerfectReplacementView.OnOkButtonClick onOkButtonClick, UnityAction closeCallBack)
		{
			this.mModelData = mModel;
			this.onMountedItemSelect = onMountedItemSelect;
			this.onUnMountedItemSelect = onUnMountedItemSelect;
			this.onOkButtonClick = onOkButtonClick;
			this.mCloseBtn.onClick.RemoveAllListeners();
			this.mCloseBtn.onClick.AddListener(closeCallBack);
			this.OnOKButoonAddListener();
			this.InitBeadComUIListScript();
			this.InitInalyBeadEquipmentComUIListScript();
		}

		// Token: 0x06010D57 RID: 68951 RVA: 0x004CCB48 File Offset: 0x004CAF48
		private void InitInalyBeadEquipmentComUIListScript()
		{
			this.mInalyBeadEquipmentComUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mInalyBeadEquipmentComUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mInalyBeadEquipmentComUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.mInalyBeadEquipmentComUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectDelegate));
			ComUIListScript comUIListScript4 = this.mInalyBeadEquipmentComUIListScript;
			comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
			this._LoadAllBeadEquipItems(ref this.equipments);
			this.TrySelectedItem(0);
		}

		// Token: 0x06010D58 RID: 68952 RVA: 0x004CCC10 File Offset: 0x004CB010
		private BeadItem _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<BeadItem>();
		}

		// Token: 0x06010D59 RID: 68953 RVA: 0x004CCC28 File Offset: 0x004CB028
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			BeadItem beadItem = item.gameObjectBindScript as BeadItem;
			if (beadItem != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				beadItem.OnItemVisible(this.equipments[item.m_index]);
			}
		}

		// Token: 0x06010D5A RID: 68954 RVA: 0x004CCC88 File Offset: 0x004CB088
		private void _OnItemSelectDelegate(ComUIListElementScript item)
		{
			BeadItem beadItem = item.gameObjectBindScript as BeadItem;
			BeadItem.ms_select = ((!(beadItem == null)) ? beadItem.Model : null);
			this.mCurrentSelectHoleType = BeadItem.ms_select.holeType;
			this.mCurrentSelectInalyBead = BeadItem.ms_select.beadItemData;
			if (this.onMountedItemSelect != null)
			{
				this.onMountedItemSelect(BeadItem.ms_select);
			}
		}

		// Token: 0x06010D5B RID: 68955 RVA: 0x004CCCFC File Offset: 0x004CB0FC
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			BeadItem beadItem = item.gameObjectBindScript as BeadItem;
			if (beadItem != null)
			{
				beadItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010D5C RID: 68956 RVA: 0x004CCD28 File Offset: 0x004CB128
		private void _LoadAllBeadEquipItems(ref List<BeadItemModel> kBeadItems)
		{
			kBeadItems.Clear();
			for (int i = 0; i < this.mModelData.mEquipItemData.PreciousBeadMountHole.Length; i++)
			{
				PrecBead precBead = this.mModelData.mEquipItemData.PreciousBeadMountHole[i];
				if (precBead != null)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(precBead.preciousBeadId);
					if (commonItemTableDataByID != null)
					{
						BeadItemModel item = new BeadItemModel(1, commonItemTableDataByID, precBead.index, this.mModelData.mEquipItemData, precBead.randomBuffId, precBead.pickNumber, precBead.type, precBead.beadReplaceNumber);
						kBeadItems.Add(item);
					}
				}
			}
			kBeadItems.Sort(new Comparison<BeadItemModel>(this._SortBeadItems));
			this.mInalyBeadEquipmentComUIListScript.SetElementAmount(this.equipments.Count);
		}

		// Token: 0x06010D5D RID: 68957 RVA: 0x004CCDFC File Offset: 0x004CB1FC
		private int _SortBeadItems(BeadItemModel left, BeadItemModel right)
		{
			if (left.beadItemData.Quality != right.beadItemData.Quality)
			{
				return right.beadItemData.Quality - left.beadItemData.Quality;
			}
			return this.GetBeadLevel(right.beadItemData.TableID) - this.GetBeadLevel(left.beadItemData.TableID);
		}

		// Token: 0x06010D5E RID: 68958 RVA: 0x004CCE60 File Offset: 0x004CB260
		private int GetBeadLevel(int beadId)
		{
			int result = 0;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(beadId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.Level;
			}
			return result;
		}

		// Token: 0x06010D5F RID: 68959 RVA: 0x004CCE94 File Offset: 0x004CB294
		private void TrySelectedItem(int iBindIndex)
		{
			if (iBindIndex < 0 || this.equipments.Count < 0)
			{
				return;
			}
			if (iBindIndex >= 0 && iBindIndex < this.equipments.Count)
			{
				BeadItem.ms_select = this.equipments[iBindIndex];
				if (!this.mInalyBeadEquipmentComUIListScript.IsElementInScrollArea(iBindIndex))
				{
					this.mInalyBeadEquipmentComUIListScript.EnsureElementVisable(iBindIndex);
				}
				this.mInalyBeadEquipmentComUIListScript.SelectElement(iBindIndex, true);
			}
			else
			{
				this.mInalyBeadEquipmentComUIListScript.SelectElement(-1, true);
				BeadItem.ms_select = null;
			}
			this.mCurrentSelectHoleType = BeadItem.ms_select.holeType;
			this.mCurrentSelectInalyBead = BeadItem.ms_select.beadItemData;
			if (this.onMountedItemSelect != null)
			{
				this.onMountedItemSelect(BeadItem.ms_select);
			}
		}

		// Token: 0x06010D60 RID: 68960 RVA: 0x004CCF60 File Offset: 0x004CB360
		private void UnInitInalyBeadEquipmentComUIListScript()
		{
			if (this.mInalyBeadEquipmentComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mInalyBeadEquipmentComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mInalyBeadEquipmentComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mInalyBeadEquipmentComUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectDelegate));
				ComUIListScript comUIListScript4 = this.mInalyBeadEquipmentComUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
				this.mInalyBeadEquipmentComUIListScript = null;
			}
		}

		// Token: 0x06010D61 RID: 68961 RVA: 0x004CD024 File Offset: 0x004CB424
		private void InitBeadComUIListScript()
		{
			this.mBeadComUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mBeadComUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBeadBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mBeadComUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnBeadItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.mBeadComUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnBeadItemSelectDelegate));
			ComUIListScript comUIListScript4 = this.mBeadComUIListScript;
			comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnBeadItemChangeDisplayDelegate));
		}

		// Token: 0x06010D62 RID: 68962 RVA: 0x004CD0D8 File Offset: 0x004CB4D8
		public void RefreshBeadItemList()
		{
			this._LoadAllBeadItems(ref this.beadList);
			this.UpdateNoBeadRoot();
		}

		// Token: 0x06010D63 RID: 68963 RVA: 0x004CD0EC File Offset: 0x004CB4EC
		private ComSarahCardInlayItem _OnBeadBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComSarahCardInlayItem>();
		}

		// Token: 0x06010D64 RID: 68964 RVA: 0x004CD104 File Offset: 0x004CB504
		private void _OnBeadItemVisiableDelegate(ComUIListElementScript item)
		{
			ComSarahCardInlayItem comSarahCardInlayItem = item.gameObjectBindScript as ComSarahCardInlayItem;
			if (comSarahCardInlayItem != null && item.m_index >= 0 && item.m_index < this.beadList.Count)
			{
				comSarahCardInlayItem.OnItemVisible(this.beadList[item.m_index]);
			}
		}

		// Token: 0x06010D65 RID: 68965 RVA: 0x004CD164 File Offset: 0x004CB564
		private void _OnBeadItemSelectDelegate(ComUIListElementScript item)
		{
			ComSarahCardInlayItem comSarahCardInlayItem = item.gameObjectBindScript as ComSarahCardInlayItem;
			ComSarahCardInlayItem.ms_selected = ((!(comSarahCardInlayItem == null)) ? comSarahCardInlayItem.ItemData : null);
			if (this.onUnMountedItemSelect != null)
			{
				this.onUnMountedItemSelect(ComSarahCardInlayItem.ms_selected);
			}
		}

		// Token: 0x06010D66 RID: 68966 RVA: 0x004CD1B8 File Offset: 0x004CB5B8
		private void _OnBeadItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComSarahCardInlayItem comSarahCardInlayItem = item.gameObjectBindScript as ComSarahCardInlayItem;
			if (comSarahCardInlayItem != null)
			{
				comSarahCardInlayItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010D67 RID: 68967 RVA: 0x004CD1E4 File Offset: 0x004CB5E4
		private void _LoadAllBeadItems(ref List<ItemData> kBeadItems)
		{
			kBeadItems.Clear();
			List<ulong> itemsByType = DataManager<ItemDataManager>.GetInstance().GetItemsByType(ItemTable.eType.EXPENDABLE);
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData itemData = ComSarahCardInlayItem._TryAddSarahCard(itemsByType[i]);
				if (itemData != null)
				{
					kBeadItems.Add(itemData);
				}
			}
			BeadTable mCurrentSelectInalyBeadTabel = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.mCurrentSelectInalyBead.TableID, string.Empty, string.Empty);
			if (mCurrentSelectInalyBeadTabel == null)
			{
				Logger.LogErrorFormat("[BeadPerfectReplacementView]  _LoadAllBeadItems 函数 当前选择已镶嵌的宝珠ID为 NULL", new object[0]);
			}
			kBeadItems.RemoveAll(delegate(ItemData x)
			{
				BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(x.TableID, string.Empty, string.Empty);
				return tableItem == null || (this.mCurrentSelectHoleType == 1 && tableItem.BeadType != 1) || (this.mModelData == null || this.mModelData.mEquipItemData == null) || !mCurrentSelectInalyBeadTabel.ReplacePearl.Contains(x.TableID) || !tableItem.Parts.Contains((int)this.mModelData.mEquipItemData.EquipWearSlotType);
			});
			List<ItemData> list = kBeadItems;
			if (BeadPerfectReplacementView.<>f__mg$cache0 == null)
			{
				BeadPerfectReplacementView.<>f__mg$cache0 = new Comparison<ItemData>(ComSarahCardInlayItem.Sort);
			}
			list.Sort(BeadPerfectReplacementView.<>f__mg$cache0);
			this.mBeadComUIListScript.SetElementAmount(this.beadList.Count);
		}

		// Token: 0x06010D68 RID: 68968 RVA: 0x004CD2D4 File Offset: 0x004CB6D4
		private void UnBeadComUIListScript()
		{
			if (this.mBeadComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mBeadComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBeadBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mBeadComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnBeadItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mBeadComUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnBeadItemSelectDelegate));
				ComUIListScript comUIListScript4 = this.mBeadComUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnBeadItemChangeDisplayDelegate));
				this.mBeadComUIListScript = null;
			}
		}

		// Token: 0x06010D69 RID: 68969 RVA: 0x004CD395 File Offset: 0x004CB795
		private void UpdateNoBeadRoot()
		{
			if (this.beadList.Count > 0)
			{
				this.mNoBeadRoot.CustomActive(false);
			}
			else
			{
				this.mNoBeadRoot.CustomActive(true);
			}
		}

		// Token: 0x06010D6A RID: 68970 RVA: 0x004CD3C8 File Offset: 0x004CB7C8
		public void UpdateExpendGoldInfo(ItemSimpleData mSimpleData)
		{
			if (mSimpleData == null)
			{
				return;
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(mSimpleData.ItemID);
			if (commonItemTableDataByID == null)
			{
				return;
			}
			if (this.mGoldIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mGoldIcon, commonItemTableDataByID.Icon, true);
			}
			if (this.mGoldInfo != null)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(mSimpleData.ItemID, true);
				if (ownedItemCount < mSimpleData.Count)
				{
					this.mGoldInfo.text = string.Format("<color={0}>{1}</color>", TR.Value("Bead_red_color"), mSimpleData.Count);
				}
				else
				{
					this.mGoldInfo.text = string.Format("<color={0}>{1}</color>", TR.Value("Bead_Green_color"), mSimpleData.Count);
				}
			}
		}

		// Token: 0x06010D6B RID: 68971 RVA: 0x004CD4A0 File Offset: 0x004CB8A0
		private void OnOKButoonAddListener()
		{
			if (this.mPrefectReplaceBtn != null)
			{
				this.mPrefectReplaceBtn.onClick.RemoveAllListeners();
				this.mPrefectReplaceBtn.onClick.AddListener(delegate()
				{
					if (this.onOkButtonClick != null)
					{
						this.onOkButtonClick();
					}
				});
			}
		}

		// Token: 0x06010D6C RID: 68972 RVA: 0x004CD4E0 File Offset: 0x004CB8E0
		public void Dispose()
		{
			this.mCloseBtn.onClick.RemoveAllListeners();
			this.mPrefectReplaceBtn.onClick.RemoveAllListeners();
			this.UnInitInalyBeadEquipmentComUIListScript();
			this.UnBeadComUIListScript();
			this.equipments.Clear();
			this.beadList.Clear();
			this.mCurrentSelectHoleType = 0;
			this.onMountedItemSelect = null;
			this.onUnMountedItemSelect = null;
			this.onOkButtonClick = null;
			this.mCurrentSelectInalyBead = null;
		}

		// Token: 0x0400ACA6 RID: 44198
		[SerializeField]
		private ComUIListScript mInalyBeadEquipmentComUIListScript;

		// Token: 0x0400ACA7 RID: 44199
		[SerializeField]
		private ComUIListScript mBeadComUIListScript;

		// Token: 0x0400ACA8 RID: 44200
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400ACA9 RID: 44201
		[SerializeField]
		private Button mPrefectReplaceBtn;

		// Token: 0x0400ACAA RID: 44202
		[SerializeField]
		private Text mGoldInfo;

		// Token: 0x0400ACAB RID: 44203
		[SerializeField]
		private Image mGoldIcon;

		// Token: 0x0400ACAC RID: 44204
		[SerializeField]
		private GameObject mNoBeadRoot;

		// Token: 0x0400ACAD RID: 44205
		private BeadPerfectReplacementModel mModelData;

		// Token: 0x0400ACAE RID: 44206
		public BeadPerfectReplacementView.OnMountedItemSelect onMountedItemSelect;

		// Token: 0x0400ACAF RID: 44207
		public BeadPerfectReplacementView.OnUnMountedItemSelect onUnMountedItemSelect;

		// Token: 0x0400ACB0 RID: 44208
		public BeadPerfectReplacementView.OnOkButtonClick onOkButtonClick;

		// Token: 0x0400ACB1 RID: 44209
		private List<BeadItemModel> equipments = new List<BeadItemModel>();

		// Token: 0x0400ACB2 RID: 44210
		private List<ItemData> beadList = new List<ItemData>();

		// Token: 0x0400ACB3 RID: 44211
		private int mCurrentSelectHoleType;

		// Token: 0x0400ACB4 RID: 44212
		private ItemData mCurrentSelectInalyBead;

		// Token: 0x0400ACB5 RID: 44213
		[CompilerGenerated]
		private static Comparison<ItemData> <>f__mg$cache0;

		// Token: 0x02001AC8 RID: 6856
		// (Invoke) Token: 0x06010D6F RID: 68975
		public delegate void OnMountedItemSelect(BeadItemModel model);

		// Token: 0x02001AC9 RID: 6857
		// (Invoke) Token: 0x06010D73 RID: 68979
		public delegate void OnUnMountedItemSelect(ItemData mItemData);

		// Token: 0x02001ACA RID: 6858
		// (Invoke) Token: 0x06010D77 RID: 68983
		public delegate void OnOkButtonClick();
	}
}
