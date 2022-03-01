using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013DC RID: 5084
	[RequireComponent(typeof(CanvasGroup))]
	public class ComDoFade : MonoBehaviour
	{
		// Token: 0x0600C518 RID: 50456 RVA: 0x002F6CBB File Offset: 0x002F50BB
		private void Awake()
		{
			this.eFadeStatus = ComDoFade.FadeStatus.FS_CLOSED;
			this.start = -1f;
			this.canvasGroup = base.GetComponent<CanvasGroup>();
		}

		// Token: 0x0600C519 RID: 50457 RVA: 0x002F6CDB File Offset: 0x002F50DB
		public void SetAlpha(float value)
		{
			if (null != this.canvasGroup)
			{
				this.canvasGroup.alpha = value;
			}
		}

		// Token: 0x0600C51A RID: 50458 RVA: 0x002F6CFC File Offset: 0x002F50FC
		public void Play()
		{
			if (null != this.canvasGroup)
			{
				this.eFadeStatus = ComDoFade.FadeStatus.FS_START;
				this.canvasGroup.alpha = this.curve.Evaluate(this.startTime);
				this.start = Time.time;
			}
		}

		// Token: 0x0600C51B RID: 50459 RVA: 0x002F6D48 File Offset: 0x002F5148
		public void Update()
		{
			if (this.eFadeStatus == ComDoFade.FadeStatus.FS_START && null != this.canvasGroup)
			{
				float num = Time.time - this.start + this.startTime;
				float num2 = Mathf.Clamp(num, this.startTime, this.startTime + this.duration);
				this.canvasGroup.alpha = this.curve.Evaluate(num2);
				if (num >= this.duration)
				{
					this.eFadeStatus = ComDoFade.FadeStatus.FS_CLOSED;
					this.start = -1f;
				}
			}
		}

		// Token: 0x0400706D RID: 28781
		private CanvasGroup canvasGroup;

		// Token: 0x0400706E RID: 28782
		public float startTime;

		// Token: 0x0400706F RID: 28783
		public float duration = 1f;

		// Token: 0x04007070 RID: 28784
		public AnimationCurve curve = new AnimationCurve();

		// Token: 0x04007071 RID: 28785
		private float start = -1f;

		// Token: 0x04007072 RID: 28786
		private ComDoFade.FadeStatus eFadeStatus = ComDoFade.FadeStatus.FS_CLOSED;

		// Token: 0x020013DD RID: 5085
		private enum FadeStatus
		{
			// Token: 0x04007074 RID: 28788
			FS_START,
			// Token: 0x04007075 RID: 28789
			FS_CLOSED
		}
	}
}
