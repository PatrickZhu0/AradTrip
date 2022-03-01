using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000075 RID: 117
	[RequireComponent(typeof(Button))]
	internal class HelpAssistant : MonoBehaviour
	{
		// Token: 0x06000280 RID: 640 RVA: 0x0001312A File Offset: 0x0001152A
		private void Start()
		{
			this.button = base.GetComponent<Button>();
			if (this.button != null)
			{
				this.button.onClick.AddListener(new UnityAction(this._OnClickHelp));
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00013165 File Offset: 0x00011565
		private void _OnClickHelp()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HelpFrame>(FrameLayer.Middle, this.eType, string.Empty);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00013183 File Offset: 0x00011583
		private void OnDestroy()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button = null;
			}
		}

		// Token: 0x04000276 RID: 630
		private Button button;

		// Token: 0x04000277 RID: 631
		public HelpFrame.HelpType eType = HelpFrame.HelpType.HT_MISSION;
	}
}
