using System;

namespace UnityEngine.UI
{
	// Token: 0x02000201 RID: 513
	[AddComponentMenu("UI/Text", 10)]
	public class TextPro : Text
	{
		// Token: 0x06001071 RID: 4209 RVA: 0x00055309 File Offset: 0x00053709
		public override void SetVerticesDirty()
		{
			base.SetVerticesDirty();
			this.m_textVersion += 1U;
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06001072 RID: 4210 RVA: 0x0005531F File Offset: 0x0005371F
		public override float preferredWidth
		{
			get
			{
				if (this.m_preferredWidthVersion != this.m_textVersion)
				{
					this.m_preferredWidth = base.preferredWidth;
					this.m_preferredWidthVersion = this.m_textVersion;
				}
				return this.m_preferredWidth;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06001073 RID: 4211 RVA: 0x00055350 File Offset: 0x00053750
		public override float preferredHeight
		{
			get
			{
				if (this.m_preferredHeightVersion != this.m_textVersion)
				{
					this.m_preferredHeight = base.preferredHeight;
					this.m_preferredHeightVersion = this.m_textVersion;
				}
				return this.m_preferredHeight;
			}
		}

		// Token: 0x04000B35 RID: 2869
		private uint m_textVersion;

		// Token: 0x04000B36 RID: 2870
		private uint m_preferredWidthVersion;

		// Token: 0x04000B37 RID: 2871
		private float m_preferredWidth;

		// Token: 0x04000B38 RID: 2872
		private uint m_preferredHeightVersion;

		// Token: 0x04000B39 RID: 2873
		private float m_preferredHeight;
	}
}
