using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000EE8 RID: 3816
	internal class ComFadeEffect : MonoBehaviour
	{
		// Token: 0x0600958D RID: 38285 RVA: 0x001C3B5F File Offset: 0x001C1F5F
		public void FadeIn()
		{
			this.m_fadeIn = true;
			this.m_fadeOut = false;
			this.m_time = 0f;
			this._UpdateFade(0f);
		}

		// Token: 0x0600958E RID: 38286 RVA: 0x001C3B85 File Offset: 0x001C1F85
		public void FadeOut()
		{
			this.m_fadeIn = false;
			this.m_fadeOut = true;
			this.m_time = 0f;
			this._UpdateFade(0f);
		}

		// Token: 0x0600958F RID: 38287 RVA: 0x001C3BAB File Offset: 0x001C1FAB
		private void Awake()
		{
			this.canvasRenders = base.gameObject.GetComponentsInChildren<CanvasRenderer>();
		}

		// Token: 0x06009590 RID: 38288 RVA: 0x001C3BBE File Offset: 0x001C1FBE
		private void Update()
		{
			this._UpdateFade(Time.deltaTime);
		}

		// Token: 0x06009591 RID: 38289 RVA: 0x001C3BCC File Offset: 0x001C1FCC
		private void _UpdateFade(float time)
		{
			if (this.m_fadeIn && this.FadeInAlphaCurve != null)
			{
				this.m_time += time;
				float num = Mathf.Clamp(this.m_time / this.FadeInTime, 0f, 1f);
				float alpha = Mathf.Clamp(this.FadeInAlphaCurve.Evaluate(num), 0f, 1f);
				this._SetUpAlpha(alpha);
				if (this.m_time > this.FadeInTime)
				{
					this.m_fadeIn = false;
					this.OnFadeIn.Invoke();
				}
			}
			else if (this.m_fadeOut && this.FadeOutAlphaCurve != null)
			{
				this.m_time += time;
				float num2 = Mathf.Clamp(this.m_time / this.FadeOutTime, 0f, 1f);
				float alpha2 = Mathf.Clamp(this.FadeOutAlphaCurve.Evaluate(num2), 0f, 1f);
				this._SetUpAlpha(alpha2);
				if (this.m_time > this.FadeOutTime)
				{
					this.m_fadeOut = false;
					this.OnFadeOut.Invoke();
				}
			}
		}

		// Token: 0x06009592 RID: 38290 RVA: 0x001C3CEC File Offset: 0x001C20EC
		private void _SetUpAlpha(float alpha)
		{
			for (int i = 0; i < this.canvasRenders.Length; i++)
			{
				this.canvasRenders[i].SetAlpha(alpha);
			}
		}

		// Token: 0x04004C7F RID: 19583
		public ComFadeEffect.FadeInEvent OnFadeIn = new ComFadeEffect.FadeInEvent();

		// Token: 0x04004C80 RID: 19584
		public AnimationCurve FadeInAlphaCurve;

		// Token: 0x04004C81 RID: 19585
		public float FadeInTime = 1f;

		// Token: 0x04004C82 RID: 19586
		public ComFadeEffect.FadeOutEvent OnFadeOut = new ComFadeEffect.FadeOutEvent();

		// Token: 0x04004C83 RID: 19587
		public AnimationCurve FadeOutAlphaCurve;

		// Token: 0x04004C84 RID: 19588
		public float FadeOutTime = 1f;

		// Token: 0x04004C85 RID: 19589
		private CanvasRenderer[] canvasRenders;

		// Token: 0x04004C86 RID: 19590
		private bool m_fadeIn;

		// Token: 0x04004C87 RID: 19591
		private bool m_fadeOut;

		// Token: 0x04004C88 RID: 19592
		private float m_time;

		// Token: 0x02000EE9 RID: 3817
		public class FadeInEvent : UnityEvent
		{
		}

		// Token: 0x02000EEA RID: 3818
		public class FadeOutEvent : UnityEvent
		{
		}
	}
}
