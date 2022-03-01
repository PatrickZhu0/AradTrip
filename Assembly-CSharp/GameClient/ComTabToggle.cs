using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace GameClient
{
	// Token: 0x02000F1D RID: 3869
	[RequireComponent(typeof(Toggle))]
	public class ComTabToggle : MonoBehaviour, IComTabToggle, IRedPointToggle, IOutLineToggle, ISetNameToggle, IDisposable
	{
		// Token: 0x060096D0 RID: 38608 RVA: 0x001CBEC2 File Offset: 0x001CA2C2
		public void SetName(string normal, string selected)
		{
			this.mTextNormal.SafeSetText(normal);
			if (string.IsNullOrEmpty(selected))
			{
				selected = normal;
			}
			this.mTextSelected.SafeSetText(selected);
		}

		// Token: 0x060096D1 RID: 38609 RVA: 0x001CBEEA File Offset: 0x001CA2EA
		public void SetRedPointActive(bool value)
		{
			this.mRedPoint.CustomActive(value);
		}

		// Token: 0x060096D2 RID: 38610 RVA: 0x001CBEF8 File Offset: 0x001CA2F8
		public void SetSelectOutLineColor(Color color)
		{
			this.mOutlineSelectColor = color;
			if (this.mToggle.isOn)
			{
				this.mTextOutline.effectColor = color;
			}
		}

		// Token: 0x060096D3 RID: 38611 RVA: 0x001CBF1D File Offset: 0x001CA31D
		public void Dispose()
		{
			this.mToggle.SafeRemoveOnValueChangedListener(new UnityAction<bool>(this.OnValueChanged));
		}

		// Token: 0x060096D4 RID: 38612 RVA: 0x001CBF36 File Offset: 0x001CA336
		public void Init()
		{
			this.BindEvent();
			if (this.mTextOutline != null)
			{
				this.mOutlineNormalColor = this.mTextOutline.effectColor;
				this.mOutlineSelectColor = this.mOutlineNormalColor;
			}
		}

		// Token: 0x060096D5 RID: 38613 RVA: 0x001CBF6C File Offset: 0x001CA36C
		public void BindEvent()
		{
			this.mToggle.SafeRemoveOnValueChangedListener(new UnityAction<bool>(this.OnValueChanged));
			this.mToggle.SafeAddOnValueChangedListener(new UnityAction<bool>(this.OnValueChanged));
		}

		// Token: 0x060096D6 RID: 38614 RVA: 0x001CBF9C File Offset: 0x001CA39C
		private void OnValueChanged(bool value)
		{
			if (this.mTextOutline != null)
			{
				this.mTextOutline.effectColor = ((!value) ? this.mOutlineNormalColor : this.mOutlineSelectColor);
			}
			if (this.mTextSelected != null)
			{
				this.mTextNormal.CustomActive(!value);
				this.mTextSelected.CustomActive(value);
			}
		}

		// Token: 0x060096D7 RID: 38615 RVA: 0x001CC008 File Offset: 0x001CA408
		private void Awake()
		{
			this.mToggle = base.GetComponent<Toggle>();
		}

		// Token: 0x04004D8A RID: 19850
		[SerializeField]
		private GameObject mRedPoint;

		// Token: 0x04004D8B RID: 19851
		[SerializeField]
		private NicerOutline mTextOutline;

		// Token: 0x04004D8C RID: 19852
		[SerializeField]
		private Text mTextNormal;

		// Token: 0x04004D8D RID: 19853
		[SerializeField]
		private Text mTextSelected;

		// Token: 0x04004D8E RID: 19854
		private Color mOutlineNormalColor;

		// Token: 0x04004D8F RID: 19855
		private Color mOutlineSelectColor;

		// Token: 0x04004D90 RID: 19856
		private Toggle mToggle;
	}
}
