using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200196E RID: 6510
	public class HeadPortraitTabItem : MonoBehaviour
	{
		// Token: 0x0600FD19 RID: 64793 RVA: 0x0045AB34 File Offset: 0x00458F34
		private void Awake()
		{
			if (this.mToggle != null)
			{
				this.mToggle.onValueChanged.RemoveAllListeners();
				this.mToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabItemClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HeadPortraitItemStateChanged, new ClientEventSystem.UIEventHandler(this.OnHeadPortraitItemStateChanged));
		}

		// Token: 0x0600FD1A RID: 64794 RVA: 0x0045AB9C File Offset: 0x00458F9C
		public void InitTabItem(HeadPortraitTabDataModel data, OnHeadPortraitTabItemClick onHeadPortraitTabItemClick, bool isSelect)
		{
			this.mTabData = data;
			this.mOnHeadPortraitTabItemClick = onHeadPortraitTabItemClick;
			this.mName.text = this.mTabData.tabName;
			this.UpdateRedPoint();
			if (isSelect && this.mToggle != null)
			{
				this.mToggle.isOn = true;
			}
		}

		// Token: 0x0600FD1B RID: 64795 RVA: 0x0045ABF6 File Offset: 0x00458FF6
		private void UpdateRedPoint()
		{
			if (this.mTabData != null && this.mRedPoint != null)
			{
				this.mRedPoint.CustomActive(HeadPortraitFrameDataManager.IsHeadPortraitItemHasNew(this.mTabData.tabType));
			}
		}

		// Token: 0x0600FD1C RID: 64796 RVA: 0x0045AC30 File Offset: 0x00459030
		private void OnTabItemClick(bool value)
		{
			if (this.mTabData == null)
			{
				return;
			}
			if (this.bIsSelect == value)
			{
				return;
			}
			this.bIsSelect = value;
			if (value)
			{
				if (this.mOnHeadPortraitTabItemClick != null)
				{
					this.mOnHeadPortraitTabItemClick(this.mTabData);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HeadPortraitItemStateChanged, null, null, null, null);
			}
		}

		// Token: 0x0600FD1D RID: 64797 RVA: 0x0045AC92 File Offset: 0x00459092
		private void OnHeadPortraitItemStateChanged(UIEvent uiEvent)
		{
			this.UpdateRedPoint();
		}

		// Token: 0x0600FD1E RID: 64798 RVA: 0x0045AC9C File Offset: 0x0045909C
		private void OnDestroy()
		{
			if (this.mToggle != null)
			{
				this.mToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnTabItemClick));
			}
			this.mTabData = null;
			this.mOnHeadPortraitTabItemClick = null;
			this.bIsSelect = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HeadPortraitItemStateChanged, new ClientEventSystem.UIEventHandler(this.OnHeadPortraitItemStateChanged));
		}

		// Token: 0x04009EFE RID: 40702
		[SerializeField]
		private Toggle mToggle;

		// Token: 0x04009EFF RID: 40703
		[SerializeField]
		private Text mName;

		// Token: 0x04009F00 RID: 40704
		[SerializeField]
		private GameObject mRedPoint;

		// Token: 0x04009F01 RID: 40705
		private HeadPortraitTabDataModel mTabData;

		// Token: 0x04009F02 RID: 40706
		private OnHeadPortraitTabItemClick mOnHeadPortraitTabItemClick;

		// Token: 0x04009F03 RID: 40707
		private bool bIsSelect;
	}
}
