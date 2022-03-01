using System;

namespace UnityEngine.UI
{
	// Token: 0x02000202 RID: 514
	[AddComponentMenu("UI/TextNoMask", 10)]
	public class TextProNoMask : Text
	{
		// Token: 0x06001075 RID: 4213 RVA: 0x00055389 File Offset: 0x00053789
		protected override void Awake()
		{
			base.Awake();
			base.maskable = false;
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x00055398 File Offset: 0x00053798
		public override void SetVerticesDirty()
		{
			base.SetVerticesDirty();
			this.m_textVersion += 1U;
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06001077 RID: 4215 RVA: 0x000553AE File Offset: 0x000537AE
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

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06001078 RID: 4216 RVA: 0x000553DF File Offset: 0x000537DF
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

		// Token: 0x04000B3A RID: 2874
		private uint m_textVersion;

		// Token: 0x04000B3B RID: 2875
		private uint m_preferredWidthVersion;

		// Token: 0x04000B3C RID: 2876
		private float m_preferredWidth;

		// Token: 0x04000B3D RID: 2877
		private uint m_preferredHeightVersion;

		// Token: 0x04000B3E RID: 2878
		private float m_preferredHeight;
	}
}
