using System;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	// Token: 0x020001FF RID: 511
	[AddComponentMenu("Layout/Text Layout Element", 140)]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Text))]
	[ExecuteInEditMode]
	public class TextLayoutElement : UIBehaviour, ILayoutElement, ILayoutIgnorer
	{
		// Token: 0x06001052 RID: 4178 RVA: 0x00054F98 File Offset: 0x00053398
		protected TextLayoutElement()
		{
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06001053 RID: 4179 RVA: 0x00054FED File Offset: 0x000533ED
		// (set) Token: 0x06001054 RID: 4180 RVA: 0x00054FF5 File Offset: 0x000533F5
		public TextLayoutElement.TextLayoutMode verticalMode
		{
			get
			{
				return this.m_verticalMode;
			}
			set
			{
				if (TextLayoutElement.SetStruct<TextLayoutElement.TextLayoutMode>(ref this.m_verticalMode, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06001055 RID: 4181 RVA: 0x0005500E File Offset: 0x0005340E
		// (set) Token: 0x06001056 RID: 4182 RVA: 0x00055016 File Offset: 0x00053416
		public TextLayoutElement.TextLayoutMode horizontalMode
		{
			get
			{
				return this.m_horizontalMode;
			}
			set
			{
				if (TextLayoutElement.SetStruct<TextLayoutElement.TextLayoutMode>(ref this.m_horizontalMode, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x0005502F File Offset: 0x0005342F
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			if (currentValue.Equals(newValue))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06001058 RID: 4184 RVA: 0x00055052 File Offset: 0x00053452
		// (set) Token: 0x06001059 RID: 4185 RVA: 0x0005505A File Offset: 0x0005345A
		public virtual bool ignoreLayout
		{
			get
			{
				return this.m_IgnoreLayout;
			}
			set
			{
				if (TextLayoutElement.SetStruct<bool>(ref this.m_IgnoreLayout, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x00055073 File Offset: 0x00053473
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x00055075 File Offset: 0x00053475
		public virtual void CalculateLayoutInputVertical()
		{
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600105C RID: 4188 RVA: 0x00055078 File Offset: 0x00053478
		// (set) Token: 0x0600105D RID: 4189 RVA: 0x000550D5 File Offset: 0x000534D5
		public virtual float minWidth
		{
			get
			{
				if (this.m_Text == null)
				{
					this.m_Text = base.gameObject.GetComponent<Text>();
				}
				if (this.m_Text && this.horizontalMode == TextLayoutElement.TextLayoutMode.AutoFitSize)
				{
					return this.m_Text.preferredWidth;
				}
				return this.m_MinWidth;
			}
			set
			{
				if (TextLayoutElement.SetStruct<float>(ref this.m_MinWidth, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600105E RID: 4190 RVA: 0x000550F0 File Offset: 0x000534F0
		// (set) Token: 0x0600105F RID: 4191 RVA: 0x0005514D File Offset: 0x0005354D
		public virtual float minHeight
		{
			get
			{
				if (this.m_Text == null)
				{
					this.m_Text = base.gameObject.GetComponent<Text>();
				}
				if (this.m_Text && this.verticalMode == TextLayoutElement.TextLayoutMode.AutoFitSize)
				{
					return this.m_Text.preferredHeight;
				}
				return this.m_MinHeight;
			}
			set
			{
				if (TextLayoutElement.SetStruct<float>(ref this.m_MinHeight, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06001060 RID: 4192 RVA: 0x00055168 File Offset: 0x00053568
		// (set) Token: 0x06001061 RID: 4193 RVA: 0x000551CF File Offset: 0x000535CF
		public virtual float preferredWidth
		{
			get
			{
				if (this.m_Text == null)
				{
					this.m_Text = base.gameObject.GetComponent<Text>();
				}
				if (this.m_Text && this.horizontalMode == TextLayoutElement.TextLayoutMode.LimitMaxSize)
				{
					return Mathf.Min(this.m_Text.preferredWidth, this.m_PreferredWidth);
				}
				return this.m_PreferredWidth;
			}
			set
			{
				if (TextLayoutElement.SetStruct<float>(ref this.m_PreferredWidth, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06001062 RID: 4194 RVA: 0x000551E8 File Offset: 0x000535E8
		// (set) Token: 0x06001063 RID: 4195 RVA: 0x0005524F File Offset: 0x0005364F
		public virtual float preferredHeight
		{
			get
			{
				if (this.m_Text == null)
				{
					this.m_Text = base.gameObject.GetComponent<Text>();
				}
				if (this.m_Text && this.horizontalMode == TextLayoutElement.TextLayoutMode.LimitMaxSize)
				{
					return Mathf.Min(this.m_Text.preferredHeight, this.m_PreferredHeight);
				}
				return this.m_PreferredHeight;
			}
			set
			{
				if (TextLayoutElement.SetStruct<float>(ref this.m_PreferredHeight, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06001064 RID: 4196 RVA: 0x00055268 File Offset: 0x00053668
		// (set) Token: 0x06001065 RID: 4197 RVA: 0x00055270 File Offset: 0x00053670
		public virtual float flexibleWidth
		{
			get
			{
				return this.m_FlexibleWidth;
			}
			set
			{
				if (TextLayoutElement.SetStruct<float>(ref this.m_FlexibleWidth, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06001066 RID: 4198 RVA: 0x00055289 File Offset: 0x00053689
		// (set) Token: 0x06001067 RID: 4199 RVA: 0x00055291 File Offset: 0x00053691
		public virtual float flexibleHeight
		{
			get
			{
				return this.m_FlexibleHeight;
			}
			set
			{
				if (TextLayoutElement.SetStruct<float>(ref this.m_FlexibleHeight, value))
				{
					this.SetDirty();
				}
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06001068 RID: 4200 RVA: 0x000552AA File Offset: 0x000536AA
		public virtual int layoutPriority
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x000552AD File Offset: 0x000536AD
		protected override void Awake()
		{
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x000552AF File Offset: 0x000536AF
		protected override void OnEnable()
		{
			base.OnEnable();
			this.SetDirty();
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x000552BD File Offset: 0x000536BD
		protected override void OnTransformParentChanged()
		{
			this.SetDirty();
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x000552C5 File Offset: 0x000536C5
		protected override void OnDisable()
		{
			this.SetDirty();
			base.OnDisable();
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x000552D3 File Offset: 0x000536D3
		protected override void OnDidApplyAnimationProperties()
		{
			this.SetDirty();
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x000552DB File Offset: 0x000536DB
		protected override void OnBeforeTransformParentChanged()
		{
			this.SetDirty();
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x000552E3 File Offset: 0x000536E3
		protected void SetDirty()
		{
			if (!this.IsActive())
			{
				return;
			}
			LayoutRebuilder.MarkLayoutForRebuild(base.transform as RectTransform);
		}

		// Token: 0x04000B27 RID: 2855
		[SerializeField]
		private bool m_IgnoreLayout;

		// Token: 0x04000B28 RID: 2856
		[SerializeField]
		private float m_MinWidth = -1f;

		// Token: 0x04000B29 RID: 2857
		[SerializeField]
		private float m_MinHeight = -1f;

		// Token: 0x04000B2A RID: 2858
		[SerializeField]
		private float m_PreferredWidth = -1f;

		// Token: 0x04000B2B RID: 2859
		[SerializeField]
		private float m_PreferredHeight = -1f;

		// Token: 0x04000B2C RID: 2860
		[SerializeField]
		private float m_FlexibleWidth = -1f;

		// Token: 0x04000B2D RID: 2861
		[SerializeField]
		private float m_FlexibleHeight = -1f;

		// Token: 0x04000B2E RID: 2862
		[SerializeField]
		private Text m_Text;

		// Token: 0x04000B2F RID: 2863
		[SerializeField]
		private TextLayoutElement.TextLayoutMode m_verticalMode;

		// Token: 0x04000B30 RID: 2864
		[SerializeField]
		private TextLayoutElement.TextLayoutMode m_horizontalMode;

		// Token: 0x02000200 RID: 512
		public enum TextLayoutMode
		{
			// Token: 0x04000B32 RID: 2866
			LimitMaxSize,
			// Token: 0x04000B33 RID: 2867
			AutoFitSize,
			// Token: 0x04000B34 RID: 2868
			Normal
		}
	}
}
