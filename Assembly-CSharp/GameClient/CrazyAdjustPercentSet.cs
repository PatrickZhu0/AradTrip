using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AF5 RID: 6901
	public class CrazyAdjustPercentSet : MonoBehaviour
	{
		// Token: 0x06010F01 RID: 69377 RVA: 0x004D6408 File Offset: 0x004D4808
		private void Start()
		{
			float fill1Width = 0f;
			float fill2Width = 0f;
			if (this.fill1 != null && this.fill2 != null)
			{
				fill1Width = this.fill1.rectTransform.sizeDelta.x;
				fill2Width = this.fill2.rectTransform.sizeDelta.x;
			}
			if (this.slider != null)
			{
				this.slider.SafeSetValueChangeListener(delegate(float val)
				{
					float num = (float)((int)val / 10 * 10);
					this.txtPercent.SafeSetText(string.Format("{0}%", (int)num));
					this.slider.value = num;
					CrazyAdjustPercentSet.curTargetQuality = (int)this.slider.value;
					this.sliderValue.SafeSetText(string.Format("{0}%", (int)num));
					this.UpdateSubAndAddBtn();
					if (this.fill1 != null && this.fill2 != null)
					{
						float num2 = (num - 80f) / 10f;
						float num3 = (num - 90f) / 10f;
						num2 = Mathf.Clamp(num2, 0f, 1f);
						num3 = Mathf.Clamp(num3, 0f, 1f);
						this.fill1.rectTransform.sizeDelta = new Vector2(num2 * fill1Width, this.fill1.rectTransform.sizeDelta.y);
						this.fill2.rectTransform.sizeDelta = new Vector2(num3 * fill2Width, this.fill2.rectTransform.sizeDelta.y);
					}
				});
				this.btnSub.SafeSetOnClickListener(delegate
				{
					float num = this.slider.value;
					num -= 10f;
					if (num <= 60f)
					{
						num = 60f;
					}
					this.slider.value = num;
				});
				this.btnAdd.SafeSetOnClickListener(delegate
				{
					float num = this.slider.value;
					num += 10f;
					if (num >= 100f)
					{
						num = 100f;
					}
					this.slider.value = num;
				});
			}
			this.SetPercent(100);
			this.SetPercent(CrazyAdjustPercentSet.initTargetQuality);
		}

		// Token: 0x06010F02 RID: 69378 RVA: 0x004D64FF File Offset: 0x004D48FF
		private void Update()
		{
		}

		// Token: 0x06010F03 RID: 69379 RVA: 0x004D6504 File Offset: 0x004D4904
		private void SetPercent(int percent)
		{
			if (this.slider == null)
			{
				return;
			}
			int num = percent / 10 * 10;
			num = Math.Min(100, num);
			num = Math.Max(60, num);
			this.slider.value = (float)num;
		}

		// Token: 0x06010F04 RID: 69380 RVA: 0x004D654A File Offset: 0x004D494A
		public int GetPercent()
		{
			if (this.slider == null)
			{
				return 0;
			}
			return (int)this.slider.value;
		}

		// Token: 0x06010F05 RID: 69381 RVA: 0x004D656C File Offset: 0x004D496C
		private void UpdateSubAndAddBtn()
		{
			if (this.slider == null)
			{
				return;
			}
			this.btnSub.SafeSetGray(false, true);
			this.btnAdd.SafeSetGray(false, true);
			int num = (int)this.slider.value;
			if (num <= 60)
			{
				this.btnSub.SafeSetGray(true, true);
				this.btnAdd.SafeSetGray(false, true);
			}
			else if (num >= 100)
			{
				this.btnSub.SafeSetGray(false, true);
				this.btnAdd.SafeSetGray(true, true);
			}
			else
			{
				this.btnSub.SafeSetGray(false, true);
				this.btnAdd.SafeSetGray(false, true);
			}
		}

		// Token: 0x0400AE16 RID: 44566
		[SerializeField]
		private Slider slider;

		// Token: 0x0400AE17 RID: 44567
		[SerializeField]
		private Text txtPercent;

		// Token: 0x0400AE18 RID: 44568
		[SerializeField]
		private Button btnSub;

		// Token: 0x0400AE19 RID: 44569
		[SerializeField]
		private Button btnAdd;

		// Token: 0x0400AE1A RID: 44570
		[SerializeField]
		private Text sliderValue;

		// Token: 0x0400AE1B RID: 44571
		[SerializeField]
		private Image fill1;

		// Token: 0x0400AE1C RID: 44572
		[SerializeField]
		private Image fill2;

		// Token: 0x0400AE1D RID: 44573
		private const int nMin = 60;

		// Token: 0x0400AE1E RID: 44574
		private const int nMax = 100;

		// Token: 0x0400AE1F RID: 44575
		private const int step = 10;

		// Token: 0x0400AE20 RID: 44576
		[HideInInspector]
		public static int curTargetQuality;

		// Token: 0x0400AE21 RID: 44577
		[HideInInspector]
		public static int initTargetQuality;
	}
}
