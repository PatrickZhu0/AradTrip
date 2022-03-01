using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AF4 RID: 6900
	public class NewMessageBoxToggleUnit : MonoBehaviour
	{
		// Token: 0x06010EF9 RID: 69369 RVA: 0x004D6297 File Offset: 0x004D4697
		private void Awake()
		{
			this.ClearData();
		}

		// Token: 0x06010EFA RID: 69370 RVA: 0x004D629F File Offset: 0x004D469F
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06010EFB RID: 69371 RVA: 0x004D62A7 File Offset: 0x004D46A7
		public void InitBaseData(ToggleEvent tempEvent, Button tempBtn)
		{
			this.mToggleEvent = tempEvent;
			this.mEventBtn = tempBtn;
			this.tempToggleState = false;
		}

		// Token: 0x06010EFC RID: 69372 RVA: 0x004D62C0 File Offset: 0x004D46C0
		public void UpdateItemInfo()
		{
			if (this.mToggleEvent != null)
			{
				if (this.mToggleText != null)
				{
					this.mToggleText.text = this.mToggleEvent.toggleText;
				}
				if (this.mToggle != null)
				{
					this.mToggle.onValueChanged.AddListener(delegate(bool flag)
					{
						if (flag == this.tempToggleState)
						{
							return;
						}
						this.tempToggleState = flag;
						if (flag)
						{
							this.mEventBtn.onClick.AddListener(this.mToggleEvent.toggleEvent);
						}
						else
						{
							this.mEventBtn.onClick.RemoveListener(this.mToggleEvent.toggleEvent);
						}
					});
				}
			}
		}

		// Token: 0x06010EFD RID: 69373 RVA: 0x004D632C File Offset: 0x004D472C
		public void OnItemRecycle()
		{
			this.ClearData();
		}

		// Token: 0x06010EFE RID: 69374 RVA: 0x004D6334 File Offset: 0x004D4734
		private void ClearData()
		{
			if (this.mToggle != null)
			{
				this.mToggle.isOn = false;
			}
			if (this.mEventBtn != null && this.mToggleEvent != null)
			{
				this.mEventBtn.onClick.RemoveListener(this.mToggleEvent.toggleEvent);
			}
			this.mToggleEvent = null;
		}

		// Token: 0x0400AE11 RID: 44561
		[SerializeField]
		private Toggle mToggle;

		// Token: 0x0400AE12 RID: 44562
		[SerializeField]
		private Text mToggleText;

		// Token: 0x0400AE13 RID: 44563
		private ToggleEvent mToggleEvent;

		// Token: 0x0400AE14 RID: 44564
		private Button mEventBtn;

		// Token: 0x0400AE15 RID: 44565
		private bool tempToggleState;
	}
}
