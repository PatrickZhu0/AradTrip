using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001ABB RID: 6843
	public class BeadItemElement : MonoBehaviour
	{
		// Token: 0x06010CDD RID: 68829 RVA: 0x004CA108 File Offset: 0x004C8508
		private void Awake()
		{
			if (this.mOpenBeadFrameBtn != null)
			{
				this.mOpenBeadFrameBtn.onClick.RemoveAllListeners();
				this.mOpenBeadFrameBtn.onClick.AddListener(new UnityAction(this.OnOpenBeadFrameClick));
			}
			if (this.mReplaceNewBeadCardOpenBeadFrameBtn != null)
			{
				this.mReplaceNewBeadCardOpenBeadFrameBtn.onClick.RemoveAllListeners();
				this.mReplaceNewBeadCardOpenBeadFrameBtn.onClick.AddListener(new UnityAction(this.OnOpenBeadFrameClick));
			}
		}

		// Token: 0x06010CDE RID: 68830 RVA: 0x004CA190 File Offset: 0x004C8590
		private void OnDestroy()
		{
			this.mPrecBeadData = null;
			this.mOnBeadItemClick = null;
			this.mBeadCardState = BeadCardState.None;
			this.mToBeInlaidBeadItemData = null;
			this.mCurrentBeadCardItem = null;
			this.mCanBeSetBeadComItem = null;
			this.mHasBeenSetBeadComItem = null;
			this.mReplaceOldBeadComItem = null;
			this.mReplaceNewBeadComItem = null;
			this.mCloseCallBack = null;
		}

		// Token: 0x06010CDF RID: 68831 RVA: 0x004CA1E4 File Offset: 0x004C85E4
		public void InitBeadItemVisiable(PrecBead beadData, OnBeadItemClick onBeadItemClick, Action closeCallBack)
		{
			if (beadData == null)
			{
				return;
			}
			this.mPrecBeadData = beadData;
			this.mOnBeadItemClick = onBeadItemClick;
			this.mCloseCallBack = closeCallBack;
			this.mCurrentBeadCardItem = ItemDataManager.CreateItemDataFromTable(this.mPrecBeadData.preciousBeadId, 100, 0);
			if (this.mCurrentBeadCardItem != null)
			{
				this.mCurrentBeadCardItem.BeadAdditiveAttributeBuffID = this.mPrecBeadData.randomBuffId;
				this.mCurrentBeadCardItem.BeadPickNumber = this.mPrecBeadData.pickNumber;
				this.mCurrentBeadCardItem.BeadReplaceNumber = this.mPrecBeadData.beadReplaceNumber;
			}
			if (this.mCurrentBeadCardItem == null)
			{
				this.SetBeadCardState(BeadCardState.CanBeSet, null);
			}
			else
			{
				this.SetBeadCardState(BeadCardState.HasBeenSet, null);
			}
		}

		// Token: 0x06010CE0 RID: 68832 RVA: 0x004CA294 File Offset: 0x004C8694
		public void SetBeadCardState(BeadCardState state, ItemData toBeInlaidBead = null)
		{
			this.mBeadCardState = state;
			this.mToBeInlaidBeadItemData = toBeInlaidBead;
			this.mBGRoot.CustomActive(true);
			this.mBGArrowRoot.CustomActive(false);
			this.mReplaceNewCardRoot.CustomActive(false);
			switch (this.mBeadCardState)
			{
			case BeadCardState.CanBeSet:
				this.mStateControl.Key = "CanBeSet";
				this.UpdateCanBeSetBeadCardInfo();
				break;
			case BeadCardState.HasBeenSet:
				this.mStateControl.Key = "HasBeenSet";
				this.UpdateHasBeenSetBeadCardInfo();
				break;
			case BeadCardState.Replace:
				this.mStateControl.Key = "Replace";
				this.UpdateReplaceBeadCardInfo();
				break;
			}
		}

		// Token: 0x06010CE1 RID: 68833 RVA: 0x004CA34C File Offset: 0x004C874C
		private void UpdateCanBeSetBeadCardInfo()
		{
			this.mCanBeSetBeadCardRoot.CustomActive(false);
			if (this.mToBeInlaidBeadItemData != null)
			{
				if (this.mCanBeSetBeadComItem == null)
				{
					this.mCanBeSetBeadComItem = ComItemManager.Create(this.mCanBeSetBeadCardParent);
				}
				this.mCanBeSetBeadComItem.Setup(this.mToBeInlaidBeadItemData, new ComItem.OnItemClicked(this.OnOpenBeadFrameClick));
				this.mCanBeSetBeadCardName.text = this.mToBeInlaidBeadItemData.GetColorName(string.Empty, false);
				string attributesDesc = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mToBeInlaidBeadItemData.TableID, false);
				int count = Regex.Matches(attributesDesc, "\n").Count;
				if (count > 2)
				{
					this.mCanBeSetBeadCardAttr.alignment = 1;
				}
				else
				{
					this.mCanBeSetBeadCardAttr.alignment = 4;
				}
				if (this.mToBeInlaidBeadItemData.BeadAdditiveAttributeBuffID > 0)
				{
					this.mCanBeSetBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mToBeInlaidBeadItemData.TableID, false) + "\n" + string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(this.mToBeInlaidBeadItemData.BeadAdditiveAttributeBuffID));
				}
				else
				{
					this.mCanBeSetBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mToBeInlaidBeadItemData.TableID, false);
				}
				this.mCanBeSetBeadCardRoot.CustomActive(true);
			}
		}

		// Token: 0x06010CE2 RID: 68834 RVA: 0x004CA4A4 File Offset: 0x004C88A4
		private void UpdateHasBeenSetBeadCardInfo()
		{
			this.mBGArrowRoot.CustomActive(true);
			if (this.mHasBeenSetBeadComItem == null)
			{
				this.mHasBeenSetBeadComItem = ComItemManager.Create(this.mHasBeenSetBeadCardParent);
			}
			this.mHasBeenSetBeadComItem.Setup(this.mCurrentBeadCardItem, new ComItem.OnItemClicked(this.OnOpenBeadFrameClick));
			this.mHasBeenSetBeadCardName.text = this.mCurrentBeadCardItem.GetColorName(string.Empty, false);
			string attributesDesc = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mCurrentBeadCardItem.TableID, false);
			int count = Regex.Matches(attributesDesc, "\n").Count;
			if (count > 2)
			{
				this.mHasBeenSetBeadCardAttr.alignment = 1;
			}
			else
			{
				this.mHasBeenSetBeadCardAttr.alignment = 4;
			}
			if (this.mCurrentBeadCardItem.BeadAdditiveAttributeBuffID > 0)
			{
				this.mHasBeenSetBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mCurrentBeadCardItem.TableID, false) + "\n" + string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(this.mCurrentBeadCardItem.BeadAdditiveAttributeBuffID));
			}
			else
			{
				this.mHasBeenSetBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mCurrentBeadCardItem.TableID, false);
			}
		}

		// Token: 0x06010CE3 RID: 68835 RVA: 0x004CA5E8 File Offset: 0x004C89E8
		private void UpdateReplaceBeadCardInfo()
		{
			this.mBGRoot.CustomActive(false);
			this.mReplaceNewCardRoot.CustomActive(true);
			if (this.mReplaceOldBeadComItem == null)
			{
				this.mReplaceOldBeadComItem = ComItemManager.Create(this.mReplaceOldBeadCardParent);
			}
			this.mReplaceOldBeadComItem.Setup(this.mCurrentBeadCardItem, new ComItem.OnItemClicked(this.OnOpenBeadFrameClick));
			this.mReplaceOldBeadCardName.text = this.mCurrentBeadCardItem.GetColorName(string.Empty, false);
			string attributesDesc = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mCurrentBeadCardItem.TableID, false);
			int count = Regex.Matches(attributesDesc, "\n").Count;
			if (count > 2)
			{
				this.mReplaceOldBeadCardAttr.alignment = 1;
			}
			else
			{
				this.mReplaceOldBeadCardAttr.alignment = 4;
			}
			if (this.mCurrentBeadCardItem.BeadAdditiveAttributeBuffID > 0)
			{
				this.mReplaceOldBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mCurrentBeadCardItem.TableID, false) + "\n" + string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(this.mCurrentBeadCardItem.BeadAdditiveAttributeBuffID));
			}
			else
			{
				this.mReplaceOldBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mCurrentBeadCardItem.TableID, false);
			}
			if (this.mReplaceNewBeadComItem == null)
			{
				this.mReplaceNewBeadComItem = ComItemManager.Create(this.mReplaceNewBeadCardParent);
			}
			this.mReplaceNewBeadComItem.Setup(this.mToBeInlaidBeadItemData, new ComItem.OnItemClicked(this.OnOpenBeadFrameClick));
			this.mReplaceNewBeadCardName.text = this.mToBeInlaidBeadItemData.GetColorName(string.Empty, false);
			string attributesDesc2 = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mToBeInlaidBeadItemData.TableID, false);
			int count2 = Regex.Matches(attributesDesc2, "\n").Count;
			if (count2 > 2)
			{
				this.mReplaceNewBeadCardAttr.alignment = 1;
			}
			else
			{
				this.mReplaceNewBeadCardAttr.alignment = 4;
			}
			if (this.mToBeInlaidBeadItemData.BeadAdditiveAttributeBuffID > 0)
			{
				this.mReplaceNewBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mToBeInlaidBeadItemData.TableID, false) + "\n" + string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(this.mToBeInlaidBeadItemData.BeadAdditiveAttributeBuffID));
			}
			else
			{
				this.mReplaceNewBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mToBeInlaidBeadItemData.TableID, false);
			}
		}

		// Token: 0x06010CE4 RID: 68836 RVA: 0x004CA85D File Offset: 0x004C8C5D
		private void OnOpenBeadFrameClick()
		{
			if (this.mOnBeadItemClick != null)
			{
				this.mOnBeadItemClick(this.mPrecBeadData);
			}
		}

		// Token: 0x06010CE5 RID: 68837 RVA: 0x004CA87B File Offset: 0x004C8C7B
		private void OnOpenBeadFrameClick(GameObject obj, ItemData item)
		{
			this.OnOpenBeadFrameClick();
		}

		// Token: 0x06010CE6 RID: 68838 RVA: 0x004CA883 File Offset: 0x004C8C83
		public bool BeadStateIsHasBeenSet()
		{
			return this.mBeadCardState == BeadCardState.HasBeenSet || this.mBeadCardState == BeadCardState.Replace;
		}

		// Token: 0x06010CE7 RID: 68839 RVA: 0x004CA89D File Offset: 0x004C8C9D
		public void OnCancelSelectedBeadClick()
		{
			if (this.mCloseCallBack != null)
			{
				this.mCloseCallBack();
			}
		}

		// Token: 0x0400AC4B RID: 44107
		[SerializeField]
		private StateController mStateControl;

		// Token: 0x0400AC4C RID: 44108
		[SerializeField]
		private GameObject mBGRoot;

		// Token: 0x0400AC4D RID: 44109
		[SerializeField]
		private GameObject mBGArrowRoot;

		// Token: 0x0400AC4E RID: 44110
		[SerializeField]
		private GameObject mCanBeSetBeadCardRoot;

		// Token: 0x0400AC4F RID: 44111
		[SerializeField]
		private GameObject mCanBeSetBeadCardParent;

		// Token: 0x0400AC50 RID: 44112
		[SerializeField]
		private GameObject mHasBeenSetBeadCardParent;

		// Token: 0x0400AC51 RID: 44113
		[SerializeField]
		private GameObject mReplaceOldBeadCardParent;

		// Token: 0x0400AC52 RID: 44114
		[SerializeField]
		private GameObject mReplaceNewBeadCardParent;

		// Token: 0x0400AC53 RID: 44115
		[SerializeField]
		private GameObject mReplaceNewCardRoot;

		// Token: 0x0400AC54 RID: 44116
		[SerializeField]
		private Text mCanBeSetBeadCardName;

		// Token: 0x0400AC55 RID: 44117
		[SerializeField]
		private Text mHasBeenSetBeadCardName;

		// Token: 0x0400AC56 RID: 44118
		[SerializeField]
		private Text mReplaceOldBeadCardName;

		// Token: 0x0400AC57 RID: 44119
		[SerializeField]
		private Text mReplaceNewBeadCardName;

		// Token: 0x0400AC58 RID: 44120
		[SerializeField]
		private Text mCanBeSetBeadCardAttr;

		// Token: 0x0400AC59 RID: 44121
		[SerializeField]
		private Text mHasBeenSetBeadCardAttr;

		// Token: 0x0400AC5A RID: 44122
		[SerializeField]
		private Text mReplaceOldBeadCardAttr;

		// Token: 0x0400AC5B RID: 44123
		[SerializeField]
		private Text mReplaceNewBeadCardAttr;

		// Token: 0x0400AC5C RID: 44124
		[SerializeField]
		private Button mOpenBeadFrameBtn;

		// Token: 0x0400AC5D RID: 44125
		[SerializeField]
		private Button mReplaceNewBeadCardOpenBeadFrameBtn;

		// Token: 0x0400AC5E RID: 44126
		private PrecBead mPrecBeadData;

		// Token: 0x0400AC5F RID: 44127
		private OnBeadItemClick mOnBeadItemClick;

		// Token: 0x0400AC60 RID: 44128
		private BeadCardState mBeadCardState;

		// Token: 0x0400AC61 RID: 44129
		private ItemData mToBeInlaidBeadItemData;

		// Token: 0x0400AC62 RID: 44130
		private ItemData mCurrentBeadCardItem;

		// Token: 0x0400AC63 RID: 44131
		private ComItem mCanBeSetBeadComItem;

		// Token: 0x0400AC64 RID: 44132
		private ComItem mHasBeenSetBeadComItem;

		// Token: 0x0400AC65 RID: 44133
		private ComItem mReplaceOldBeadComItem;

		// Token: 0x0400AC66 RID: 44134
		private ComItem mReplaceNewBeadComItem;

		// Token: 0x0400AC67 RID: 44135
		private Action mCloseCallBack;
	}
}
