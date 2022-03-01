using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046D2 RID: 18130
	public class AssetLoadCallbacks
	{
		// Token: 0x06019F5D RID: 106333 RVA: 0x0081A816 File Offset: 0x00818C16
		public AssetLoadCallbacks(OnAssetLoadSuccess onSuccess, OnAssetLoadFailure onFailure) : this(onSuccess, onFailure, null)
		{
		}

		// Token: 0x06019F5E RID: 106334 RVA: 0x0081A821 File Offset: 0x00818C21
		public AssetLoadCallbacks(OnAssetLoadSuccess onSuccess, OnAssetLoadFailure onFailure, OnAssetLoadUpdate onUpdate)
		{
			TMDebug.Assert(null != onSuccess, "On success callback can not be null!");
			TMDebug.Assert(null != onFailure, "On failure callback can not be null!");
			this.m_OnAssetLoadSuccess = onSuccess;
			this.m_OnAssetLoadFailure = onFailure;
			this.m_OnAssetLoadUpdate = onUpdate;
		}

		// Token: 0x17002159 RID: 8537
		// (get) Token: 0x06019F5F RID: 106335 RVA: 0x0081A860 File Offset: 0x00818C60
		public OnAssetLoadSuccess OnAssetLoadSuccess
		{
			get
			{
				return this.m_OnAssetLoadSuccess;
			}
		}

		// Token: 0x1700215A RID: 8538
		// (get) Token: 0x06019F60 RID: 106336 RVA: 0x0081A868 File Offset: 0x00818C68
		public OnAssetLoadFailure OnAssetLoadFailure
		{
			get
			{
				return this.m_OnAssetLoadFailure;
			}
		}

		// Token: 0x1700215B RID: 8539
		// (get) Token: 0x06019F61 RID: 106337 RVA: 0x0081A870 File Offset: 0x00818C70
		public OnAssetLoadUpdate OnAssetLoadUpdate
		{
			get
			{
				return this.m_OnAssetLoadUpdate;
			}
		}

		// Token: 0x040124F6 RID: 74998
		private readonly OnAssetLoadSuccess m_OnAssetLoadSuccess;

		// Token: 0x040124F7 RID: 74999
		private readonly OnAssetLoadFailure m_OnAssetLoadFailure;

		// Token: 0x040124F8 RID: 75000
		private readonly OnAssetLoadUpdate m_OnAssetLoadUpdate;
	}
}
