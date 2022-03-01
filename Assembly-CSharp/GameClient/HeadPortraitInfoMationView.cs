using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200196B RID: 6507
	public class HeadPortraitInfoMationView : MonoBehaviour
	{
		// Token: 0x0600FD09 RID: 64777 RVA: 0x0045A843 File Offset: 0x00458C43
		private void Awake()
		{
			if (this.mWearBtn != null)
			{
				this.mWearBtn.onClick.RemoveAllListeners();
				this.mWearBtn.onClick.AddListener(new UnityAction(this.OnWearBtnClick));
			}
		}

		// Token: 0x0600FD0A RID: 64778 RVA: 0x0045A882 File Offset: 0x00458C82
		public void SetGameobjectRoot(bool isFlag)
		{
			if (this.mGameObjectRoot != null)
			{
				this.mGameObjectRoot.CustomActive(isFlag);
			}
		}

		// Token: 0x0600FD0B RID: 64779 RVA: 0x0045A8A4 File Offset: 0x00458CA4
		public void RefreshHeadPortraitInfoMation(HeadPortraitItemData data)
		{
			if (data == null)
			{
				return;
			}
			this.mCurrentData = data;
			ETCImageLoader.LoadSprite(ref this.mHeadPortrait, this.mCurrentData.iconPath, true);
			this.mName.text = this.mCurrentData.Name;
			this.mGetConditions.text = this.mCurrentData.conditions;
			if (this.mCurrentData.isObtain)
			{
				if (this.mCurrentData.expireTime > 0)
				{
					this.mUsePeriod.text = Function.SetShowTimeDay(this.mCurrentData.expireTime);
				}
				else
				{
					this.mUsePeriod.text = this.mPermanent;
				}
			}
			else
			{
				this.mUsePeriod.text = this.mDesc;
			}
			this.mWearBtn.CustomActive(this.mCurrentData.isObtain && this.mCurrentData.itemID != HeadPortraitFrameDataManager.WearHeadPortraitFrameID);
			this.mDressedInGo.CustomActive(this.mCurrentData.itemID == HeadPortraitFrameDataManager.WearHeadPortraitFrameID);
		}

		// Token: 0x0600FD0C RID: 64780 RVA: 0x0045A9BC File Offset: 0x00458DBC
		private void OnWearBtnClick()
		{
			if (this.mCurrentData == null)
			{
				return;
			}
			if (this.mCurrentData.itemID == HeadPortraitFrameDataManager.iDefaultHeadPortraitID)
			{
				DataManager<HeadPortraitFrameDataManager>.GetInstance().OnSendSceneHeadFrameUseReq(0U);
				return;
			}
			DataManager<HeadPortraitFrameDataManager>.GetInstance().OnSendSceneHeadFrameUseReq((uint)this.mCurrentData.itemID);
		}

		// Token: 0x0600FD0D RID: 64781 RVA: 0x0045AA0B File Offset: 0x00458E0B
		private void OnDestroy()
		{
			this.mCurrentData = null;
			if (this.mWearBtn != null)
			{
				this.mWearBtn.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x04009EEE RID: 40686
		[SerializeField]
		private Image mHeadPortrait;

		// Token: 0x04009EEF RID: 40687
		[SerializeField]
		private Text mName;

		// Token: 0x04009EF0 RID: 40688
		[SerializeField]
		private Text mGetConditions;

		// Token: 0x04009EF1 RID: 40689
		[SerializeField]
		private Text mUsePeriod;

		// Token: 0x04009EF2 RID: 40690
		[SerializeField]
		private Button mWearBtn;

		// Token: 0x04009EF3 RID: 40691
		[SerializeField]
		private GameObject mDressedInGo;

		// Token: 0x04009EF4 RID: 40692
		[SerializeField]
		private GameObject mGameObjectRoot;

		// Token: 0x04009EF5 RID: 40693
		[SerializeField]
		private string mDesc = "未获得";

		// Token: 0x04009EF6 RID: 40694
		[SerializeField]
		private string mPermanent = "永久";

		// Token: 0x04009EF7 RID: 40695
		private HeadPortraitItemData mCurrentData;
	}
}
