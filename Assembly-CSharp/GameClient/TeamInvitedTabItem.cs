using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C0B RID: 7179
	public class TeamInvitedTabItem : MonoBehaviour
	{
		// Token: 0x06011959 RID: 72025 RVA: 0x00520CEC File Offset: 0x0051F0EC
		private void Awake()
		{
			if (this.mToggle != null)
			{
				this.mToggle.onValueChanged.RemoveAllListeners();
				this.mToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClick));
			}
		}

		// Token: 0x0601195A RID: 72026 RVA: 0x00520D2B File Offset: 0x0051F12B
		private void OnDestroy()
		{
			this.bIsSelected = false;
			this.mInvitedTabData = null;
			if (this.mToggle != null)
			{
				this.mToggle.onValueChanged.RemoveAllListeners();
			}
		}

		// Token: 0x0601195B RID: 72027 RVA: 0x00520D5C File Offset: 0x0051F15C
		public void InitTab(InvitedTabData invitedTabData, OnInvitedTabClick onInvitedTabClick, bool isSelected)
		{
			this.mInvitedTabData = invitedTabData;
			this.mOnInvitedTabClick = onInvitedTabClick;
			if (this.mInvitedTabData == null)
			{
				return;
			}
			if (this.mName != null)
			{
				this.mName.text = this.mInvitedTabData.mTabName;
			}
			if (isSelected && this.mToggle != null)
			{
				this.mToggle.isOn = true;
			}
		}

		// Token: 0x0601195C RID: 72028 RVA: 0x00520DD0 File Offset: 0x0051F1D0
		private void OnTabClick(bool value)
		{
			if (this.mInvitedTabData == null)
			{
				return;
			}
			if (value == this.bIsSelected)
			{
				return;
			}
			this.bIsSelected = value;
			if (value && this.mOnInvitedTabClick != null)
			{
				this.mOnInvitedTabClick(this.mInvitedTabData);
			}
		}

		// Token: 0x0400B712 RID: 46866
		[SerializeField]
		private Text mName;

		// Token: 0x0400B713 RID: 46867
		[SerializeField]
		private Toggle mToggle;

		// Token: 0x0400B714 RID: 46868
		private OnInvitedTabClick mOnInvitedTabClick;

		// Token: 0x0400B715 RID: 46869
		private bool bIsSelected;

		// Token: 0x0400B716 RID: 46870
		private InvitedTabData mInvitedTabData;
	}
}
