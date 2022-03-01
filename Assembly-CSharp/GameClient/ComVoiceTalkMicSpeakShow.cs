using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001570 RID: 5488
	public class ComVoiceTalkMicSpeakShow : MonoBehaviour
	{
		// Token: 0x0600D66C RID: 54892 RVA: 0x003593CC File Offset: 0x003577CC
		private void Start()
		{
			this._ResetShow();
		}

		// Token: 0x0600D66D RID: 54893 RVA: 0x003593D4 File Offset: 0x003577D4
		private void Update()
		{
			if (!this.bShow)
			{
				return;
			}
			if (this.timer <= this.voiceAnimDuration)
			{
				this.timer += Time.deltaTime;
			}
			if (this.timer > this.voiceAnimDuration)
			{
				this._ChangeVoiceShow();
				this.timer = 0f;
			}
		}

		// Token: 0x0600D66E RID: 54894 RVA: 0x00359432 File Offset: 0x00357832
		private void _ResetShow()
		{
			this.timer = 0f;
			this.Hide();
		}

		// Token: 0x0600D66F RID: 54895 RVA: 0x00359448 File Offset: 0x00357848
		private void _ChangeVoiceShow()
		{
			if (this.leftVoiceImg)
			{
				this.leftVoiceImg.enabled = !this.leftVoiceImg.enabled;
			}
			if (this.rightVoiceImg)
			{
				this.rightVoiceImg.enabled = !this.rightVoiceImg.enabled;
			}
		}

		// Token: 0x0600D670 RID: 54896 RVA: 0x003594A8 File Offset: 0x003578A8
		private void _SetShow(bool bShow)
		{
			if (this.micImg)
			{
				this.micImg.enabled = bShow;
			}
			if (this.leftVoiceImg)
			{
				this.leftVoiceImg.enabled = bShow;
			}
			if (this.rightVoiceImg)
			{
				this.rightVoiceImg.enabled = bShow;
			}
		}

		// Token: 0x0600D671 RID: 54897 RVA: 0x00359509 File Offset: 0x00357909
		public void Show()
		{
			this._SetShow(true);
			this.bShow = true;
		}

		// Token: 0x0600D672 RID: 54898 RVA: 0x00359519 File Offset: 0x00357919
		public void Hide()
		{
			this._SetShow(false);
			this.bShow = false;
		}

		// Token: 0x04007DE3 RID: 32227
		public const string RES_PATH = "UIFlatten/Prefabs/Common/ComVoice/VoiceTalkMicSpeakShow";

		// Token: 0x04007DE4 RID: 32228
		[SerializeField]
		private Image micImg;

		// Token: 0x04007DE5 RID: 32229
		[SerializeField]
		private Image leftVoiceImg;

		// Token: 0x04007DE6 RID: 32230
		[SerializeField]
		private Image rightVoiceImg;

		// Token: 0x04007DE7 RID: 32231
		public float voiceAnimDuration = 0.5f;

		// Token: 0x04007DE8 RID: 32232
		private float timer;

		// Token: 0x04007DE9 RID: 32233
		private bool bShow;
	}
}
