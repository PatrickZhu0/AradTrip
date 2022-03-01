using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E00 RID: 3584
	[RequireComponent(typeof(Button))]
	public class CommonHelpNewAssistant : MonoBehaviour
	{
		// Token: 0x06008FBC RID: 36796 RVA: 0x001A918E File Offset: 0x001A758E
		private void Awake()
		{
			this.button = base.GetComponent<Button>();
			if (this.button != null)
			{
				this.button.onClick.AddListener(new UnityAction(this.OnHelpButtonClick));
			}
		}

		// Token: 0x06008FBD RID: 36797 RVA: 0x001A91C9 File Offset: 0x001A75C9
		private void OnDestroy()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06008FBE RID: 36798 RVA: 0x001A91EC File Offset: 0x001A75EC
		private void OnHelpButtonClick()
		{
			if (this.HelpId <= 0)
			{
				Logger.LogError("HelpId is not more than zero");
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonHelpNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonHelpNewFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonHelpNewFrame>(FrameLayer.Middle, this.HelpId, string.Empty);
		}

		// Token: 0x04004751 RID: 18257
		private Button button;

		// Token: 0x04004752 RID: 18258
		public int HelpId;
	}
}
