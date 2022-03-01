using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001971 RID: 6513
	public class PersonalSettingMainTabItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600FD29 RID: 64809 RVA: 0x0045ADBE File Offset: 0x004591BE
		private void Awake()
		{
			if (this.mToggle != null)
			{
				this.mToggle.onValueChanged.RemoveAllListeners();
				this.mToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabToggleClick));
			}
		}

		// Token: 0x0600FD2A RID: 64810 RVA: 0x0045AE00 File Offset: 0x00459200
		public void InitTabItem(PersonalSettingMainTabDataModle mainTabDataModle, bool isSelect)
		{
			this.mPersonalSettingMainTabDataModle = mainTabDataModle;
			this.mTabName.text = this.mPersonalSettingMainTabDataModle.mTabName;
			if (isSelect && this.mToggle != null)
			{
				this.mToggle.isOn = true;
			}
		}

		// Token: 0x0600FD2B RID: 64811 RVA: 0x0045AE50 File Offset: 0x00459250
		private void OnTabToggleClick(bool value)
		{
			if (this.mPersonalSettingMainTabDataModle == null)
			{
				return;
			}
			if (value == this.IsSelect)
			{
				return;
			}
			this.IsSelect = value;
			if (value)
			{
				this.mPersonalSettingMainTabDataModle.mContentRoot.CustomActive(true);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TitleModeUpdate, null, null, null, null);
				if (this.frame == null)
				{
					if (this.mPersonalSettingMainTabDataModle.mPersonalSettingMainTabType == PersonalSettingMainTabType.PSMTT_TITLE)
					{
						this.frame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<TitleFrame>(this.mPersonalSettingMainTabDataModle.mContentRoot, null, string.Empty);
					}
					else if (this.mPersonalSettingMainTabDataModle.mPersonalSettingMainTabType == PersonalSettingMainTabType.PSMTT_HEADPORTRAIT)
					{
						this.frame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<HeadPortraitFrame>(this.mPersonalSettingMainTabDataModle.mContentRoot, null, string.Empty);
					}
				}
			}
			else
			{
				this.mPersonalSettingMainTabDataModle.mContentRoot.CustomActive(false);
			}
		}

		// Token: 0x0600FD2C RID: 64812 RVA: 0x0045AF31 File Offset: 0x00459331
		public void Dispose()
		{
			this.mPersonalSettingMainTabDataModle = null;
			this.IsSelect = false;
			if (this.frame != null)
			{
				this.frame.Close(false);
				this.frame = null;
			}
		}

		// Token: 0x0600FD2D RID: 64813 RVA: 0x0045AF5F File Offset: 0x0045935F
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x04009F07 RID: 40711
		[SerializeField]
		private Toggle mToggle;

		// Token: 0x04009F08 RID: 40712
		[SerializeField]
		private Text mTabName;

		// Token: 0x04009F09 RID: 40713
		private PersonalSettingMainTabDataModle mPersonalSettingMainTabDataModle;

		// Token: 0x04009F0A RID: 40714
		private bool IsSelect;

		// Token: 0x04009F0B RID: 40715
		private IClientFrame frame;
	}
}
