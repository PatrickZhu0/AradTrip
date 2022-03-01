using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CB2 RID: 7346
	internal class ComTitleItem : MonoBehaviour
	{
		// Token: 0x0601205D RID: 73821 RVA: 0x00544885 File Offset: 0x00542C85
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goSelectMark.CustomActive(bSelected);
		}

		// Token: 0x0601205E RID: 73822 RVA: 0x00544894 File Offset: 0x00542C94
		public void OnItemVisible(ComTitleItemData data)
		{
			this.mData = data;
			if (null == this.comItem)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			this.itemData = data.itemData;
			if (this.itemData == null)
			{
				this.itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mData.itemTable.ID);
			}
			this.comItem.Setup(this.itemData, null);
			if (base.gameObject != null && this.mData.itemTable != null)
			{
				base.gameObject.name = this.mData.itemTable.ID.ToString();
			}
			if (null != this.comAniRender)
			{
				this.comAniRender.SetEnable(false);
				if (this.mData.itemData != null && this.mData.itemTable != null && this.mData.itemTable.Path2.Count == 4)
				{
					int count = 0;
					float fScale = 0f;
					if (int.TryParse(this.mData.itemTable.Path2[2], out count) && float.TryParse(this.mData.itemTable.Path2[3], out fScale))
					{
						this.comAniRender.Reset(this.mData.itemTable.Path2[0], this.mData.itemTable.Path2[1], count, fScale, this.mData.itemTable.ModelPath);
						this.comAniRender.SetEnable(true);
					}
				}
			}
			if (this.mData.itemData == null && null != this.unAcquiredName && this.mData.itemTable != null)
			{
				this.unAcquiredName.text = this.mData.itemTable.Name;
			}
			this.unAcquiredName.CustomActive(null == this.mData.itemData);
			if (null != this.comGray)
			{
				this.comGray.enabled = (null == this.mData.itemData);
			}
			bool canTrade = this.CanTrade;
			bool equiped = this.Equiped;
			bool hasExtra = this.HasExtra;
			this.textMark.CustomActive(equiped || hasExtra);
			if (this.mData.itemData != null && this.mData.itemData.PackageType == EPackageType.WearEquip)
			{
				this.textMark.text = TR.Value("title_has_equiped");
			}
			else if (hasExtra)
			{
				this.textMark.text = TR.Value("title_has_owned");
			}
			this.timeLimit.CustomActive(this.mData.eType == TittleComeType.TCT_TIMELIMITED);
			InvokeMethod.RmoveInvokeIntervalCall(this);
			if (this.mData.eType == TittleComeType.TCT_TIMELIMITED)
			{
				this._UpdateTimeLimitDesc();
				InvokeMethod.InvokeInterval(this, 0.33f, 0.33f, 100000000f, null, new UnityAction(this._UpdateTimeLimitDesc), null);
			}
		}

		// Token: 0x0601205F RID: 73823 RVA: 0x00544BC9 File Offset: 0x00542FC9
		private void _UpdateTimeLimitDesc()
		{
			if (this.mData.itemData != null && null != this.timeLimit)
			{
				this.timeLimit.text = this.mData.itemData.GetTimeLeftDescByDay();
			}
		}

		// Token: 0x17001DBE RID: 7614
		// (get) Token: 0x06012060 RID: 73824 RVA: 0x00544C07 File Offset: 0x00543007
		public bool CanTrade
		{
			get
			{
				return this.mData.itemData != null && DataManager<TittleBookManager>.GetInstance().CanTrade(this.mData.itemData);
			}
		}

		// Token: 0x17001DBF RID: 7615
		// (get) Token: 0x06012061 RID: 73825 RVA: 0x00544C31 File Offset: 0x00543031
		public bool Equiped
		{
			get
			{
				return this.mData.itemData != null && this.mData.itemData.PackageType == EPackageType.WearEquip;
			}
		}

		// Token: 0x17001DC0 RID: 7616
		// (get) Token: 0x06012062 RID: 73826 RVA: 0x00544C59 File Offset: 0x00543059
		public bool HasExtra
		{
			get
			{
				return this.mData.itemData != null && DataManager<TittleBookManager>.GetInstance().HasExtraTitle(this.mData.itemData);
			}
		}

		// Token: 0x06012063 RID: 73827 RVA: 0x00544C84 File Offset: 0x00543084
		private void OnDestroy()
		{
			InvokeMethod.RmoveInvokeIntervalCall(this);
			if (null != this.comItem)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
			this.mData.itemData = null;
			this.mData.itemTable = null;
		}

		// Token: 0x0400BBE9 RID: 48105
		public GameObject goItemParent;

		// Token: 0x0400BBEA RID: 48106
		public Text textMark;

		// Token: 0x0400BBEB RID: 48107
		public GameObject goSelectMark;

		// Token: 0x0400BBEC RID: 48108
		public GameObject goAnimationParent;

		// Token: 0x0400BBED RID: 48109
		public Text unAcquiredName;

		// Token: 0x0400BBEE RID: 48110
		public SpriteAniRenderChenghao comAniRender;

		// Token: 0x0400BBEF RID: 48111
		public Text timeLimit;

		// Token: 0x0400BBF0 RID: 48112
		public UIGray comGray;

		// Token: 0x0400BBF1 RID: 48113
		private ComTitleItemData mData;

		// Token: 0x0400BBF2 RID: 48114
		private ComItem comItem;

		// Token: 0x0400BBF3 RID: 48115
		private ItemData itemData;
	}
}
