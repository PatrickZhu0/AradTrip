using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200196C RID: 6508
	public class HeadPortraitItem : MonoBehaviour
	{
		// Token: 0x17001D13 RID: 7443
		// (get) Token: 0x0600FD0F RID: 64783 RVA: 0x0045AA3D File Offset: 0x00458E3D
		// (set) Token: 0x0600FD10 RID: 64784 RVA: 0x0045AA45 File Offset: 0x00458E45
		public HeadPortraitItemData HeadPortraitItemData
		{
			get
			{
				return this.mHeadPortraitItem;
			}
			set
			{
				this.mHeadPortraitItem = value;
			}
		}

		// Token: 0x0600FD11 RID: 64785 RVA: 0x0045AA50 File Offset: 0x00458E50
		public void OnItemVisiable(HeadPortraitItemData itemdata)
		{
			this.mHeadPortraitItem = itemdata;
			ETCImageLoader.LoadSprite(ref this.mHeadPortrait, this.mHeadPortraitItem.iconPath, true);
			this.mNotGet.CustomActive(!this.mHeadPortraitItem.isObtain);
			if (HeadPortraitFrameDataManager.WearHeadPortraitFrameID == 0)
			{
				this.mWear.CustomActive(this.mHeadPortraitItem.itemID == HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
			}
			else
			{
				this.mWear.CustomActive(this.mHeadPortraitItem.itemID == HeadPortraitFrameDataManager.WearHeadPortraitFrameID);
			}
			this.mNewMark.CustomActive(this.mHeadPortraitItem.isNew);
			if (this.mHeadPortraitItem.isNew)
			{
				DataManager<HeadPortraitFrameDataManager>.GetInstance().NotifyItemBeOld(this.mHeadPortraitItem);
			}
		}

		// Token: 0x0600FD12 RID: 64786 RVA: 0x0045AB14 File Offset: 0x00458F14
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.mGoSelectBack.CustomActive(bSelected);
		}

		// Token: 0x0600FD13 RID: 64787 RVA: 0x0045AB22 File Offset: 0x00458F22
		private void OnDestroy()
		{
			this.mHeadPortraitItem = null;
		}

		// Token: 0x04009EF8 RID: 40696
		[SerializeField]
		private Image mHeadPortrait;

		// Token: 0x04009EF9 RID: 40697
		[SerializeField]
		private GameObject mGoSelectBack;

		// Token: 0x04009EFA RID: 40698
		[SerializeField]
		private GameObject mNotGet;

		// Token: 0x04009EFB RID: 40699
		[SerializeField]
		private GameObject mWear;

		// Token: 0x04009EFC RID: 40700
		[SerializeField]
		private GameObject mNewMark;

		// Token: 0x04009EFD RID: 40701
		private HeadPortraitItemData mHeadPortraitItem;
	}
}
