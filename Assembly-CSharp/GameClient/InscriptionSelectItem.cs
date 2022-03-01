using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B5F RID: 7007
	public class InscriptionSelectItem : MonoBehaviour
	{
		// Token: 0x17001D9B RID: 7579
		// (get) Token: 0x060112C4 RID: 70340 RVA: 0x004EF898 File Offset: 0x004EDC98
		// (set) Token: 0x060112C5 RID: 70341 RVA: 0x004EF8A0 File Offset: 0x004EDCA0
		public ItemData InscriptionItemData
		{
			get
			{
				return this.inscriptionItem;
			}
			set
			{
				this.inscriptionItem = value;
			}
		}

		// Token: 0x060112C6 RID: 70342 RVA: 0x004EF8AC File Offset: 0x004EDCAC
		private void Awake()
		{
			if (this.mInscriptionItemBtn != null)
			{
				this.mInscriptionItemBtn.onClick.RemoveAllListeners();
				this.mInscriptionItemBtn.onClick.AddListener(new UnityAction(this.OnInscriptionItemClick));
			}
			if (this.mAddInscriptionBtn != null)
			{
				this.mAddInscriptionBtn.onClick.RemoveAllListeners();
				this.mAddInscriptionBtn.onClick.AddListener(new UnityAction(this.OnInscriptionItemClick));
			}
		}

		// Token: 0x060112C7 RID: 70343 RVA: 0x004EF933 File Offset: 0x004EDD33
		private void OnDestroy()
		{
			this.comItem = null;
			this.inscriptionItem = null;
			this.mOnSelectInscriptionItemClick = null;
			this.mPutInscriptionItemList = null;
		}

		// Token: 0x060112C8 RID: 70344 RVA: 0x004EF954 File Offset: 0x004EDD54
		public void OnItemVisiable(ItemData data, int selectIncriptionQultity, OnSelectInscriptionItemClick onSelectInscriptionItemClick, List<ItemData> putIncriptionList)
		{
			if (data == null)
			{
				return;
			}
			this.currentselectIncriptionQultity = selectIncriptionQultity;
			this.mOnSelectInscriptionItemClick = onSelectInscriptionItemClick;
			this.mPutInscriptionItemList = putIncriptionList;
			this.inscriptionItem = data;
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.itemParent);
			}
			ComItem comItem = this.comItem;
			ItemData item = this.inscriptionItem;
			if (InscriptionSelectItem.<>f__mg$cache0 == null)
			{
				InscriptionSelectItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, InscriptionSelectItem.<>f__mg$cache0);
			this.itemName.text = this.inscriptionItem.GetColorName(string.Empty, false);
			this.itemAttrs.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(this.inscriptionItem.TableID, true);
			if (this.currentselectIncriptionQultity != 0)
			{
				if (this.currentselectIncriptionQultity != (int)data.Quality)
				{
					this.maskRoot.CustomActive(true);
					this.SetCheckMaskRoot(false);
				}
				else
				{
					this.maskRoot.CustomActive(false);
					this.UpdateSelectedInscriptionNumber();
				}
			}
			else
			{
				this.maskRoot.CustomActive(false);
				this.SetCheckMaskRoot(false);
			}
		}

		// Token: 0x060112C9 RID: 70345 RVA: 0x004EFA70 File Offset: 0x004EDE70
		private void UpdateSelectedInscriptionNumber()
		{
			if (this.mPutInscriptionItemList != null && this.mPutInscriptionItemList.Count > 0)
			{
				int num = 0;
				for (int i = 0; i < this.mPutInscriptionItemList.Count; i++)
				{
					ItemData itemData = this.mPutInscriptionItemList[i];
					if (itemData != null)
					{
						if (itemData.TableID == this.InscriptionItemData.TableID)
						{
							num++;
						}
					}
				}
				if (num > 0)
				{
					this.SetCheckMaskRoot(true);
					this.mSelectedInscrptionNum.text = string.Format("已选:{0}", num);
					this.mAddInscriptionGray.enabled = (num >= this.inscriptionItem.Count);
				}
				else
				{
					this.SetCheckMaskRoot(false);
				}
			}
			else
			{
				this.SetCheckMaskRoot(false);
			}
		}

		// Token: 0x060112CA RID: 70346 RVA: 0x004EFB4B File Offset: 0x004EDF4B
		private void OnInscriptionItemClick()
		{
			if (this.mOnSelectInscriptionItemClick != null)
			{
				this.mOnSelectInscriptionItemClick(this.InscriptionItemData, this);
			}
		}

		// Token: 0x060112CB RID: 70347 RVA: 0x004EFB6A File Offset: 0x004EDF6A
		public void SetCheckMaskRoot(bool value)
		{
			this.mCheckMaskRoot.CustomActive(value);
		}

		// Token: 0x0400B140 RID: 45376
		[SerializeField]
		private GameObject itemParent;

		// Token: 0x0400B141 RID: 45377
		[SerializeField]
		private Text itemName;

		// Token: 0x0400B142 RID: 45378
		[SerializeField]
		private Text itemAttrs;

		// Token: 0x0400B143 RID: 45379
		[SerializeField]
		private GameObject maskRoot;

		// Token: 0x0400B144 RID: 45380
		[SerializeField]
		private GameObject mCheckMaskRoot;

		// Token: 0x0400B145 RID: 45381
		[SerializeField]
		private Text mSelectedInscrptionNum;

		// Token: 0x0400B146 RID: 45382
		[SerializeField]
		private Button mAddInscriptionBtn;

		// Token: 0x0400B147 RID: 45383
		[SerializeField]
		private UIGray mAddInscriptionGray;

		// Token: 0x0400B148 RID: 45384
		[SerializeField]
		private Button mInscriptionItemBtn;

		// Token: 0x0400B149 RID: 45385
		private List<ItemData> mPutInscriptionItemList;

		// Token: 0x0400B14A RID: 45386
		private OnSelectInscriptionItemClick mOnSelectInscriptionItemClick;

		// Token: 0x0400B14B RID: 45387
		private ComItem comItem;

		// Token: 0x0400B14C RID: 45388
		private ItemData inscriptionItem;

		// Token: 0x0400B14D RID: 45389
		private int currentselectIncriptionQultity;

		// Token: 0x0400B14E RID: 45390
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
