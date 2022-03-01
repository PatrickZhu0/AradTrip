using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046F2 RID: 18162
	public class FileLoadCallbacks
	{
		// Token: 0x0601A0C5 RID: 106693 RVA: 0x0081E025 File Offset: 0x0081C425
		public FileLoadCallbacks(OnFileLoadSuccess onSuccess, OnFileLoadFailure onFailure) : this(onSuccess, onFailure, null)
		{
		}

		// Token: 0x0601A0C6 RID: 106694 RVA: 0x0081E030 File Offset: 0x0081C430
		public FileLoadCallbacks(OnFileLoadSuccess onSuccess, OnFileLoadFailure onFailure, OnFileLoadUpdate onUpdate)
		{
			TMDebug.Assert(null != onSuccess, "On success callback can not be null!");
			TMDebug.Assert(null != onFailure, "On failure callback can not be null!");
			this.m_OnFileLoadSuccess = onSuccess;
			this.m_OnFileLoadFailure = onFailure;
			this.m_OnFileLoadUpdate = onUpdate;
		}

		// Token: 0x170021CC RID: 8652
		// (get) Token: 0x0601A0C7 RID: 106695 RVA: 0x0081E06F File Offset: 0x0081C46F
		public OnFileLoadSuccess OnFileLoadSuccess
		{
			get
			{
				return this.m_OnFileLoadSuccess;
			}
		}

		// Token: 0x170021CD RID: 8653
		// (get) Token: 0x0601A0C8 RID: 106696 RVA: 0x0081E077 File Offset: 0x0081C477
		public OnFileLoadFailure OnFileLoadFailure
		{
			get
			{
				return this.m_OnFileLoadFailure;
			}
		}

		// Token: 0x170021CE RID: 8654
		// (get) Token: 0x0601A0C9 RID: 106697 RVA: 0x0081E07F File Offset: 0x0081C47F
		public OnFileLoadUpdate OnFileLoadUpdate
		{
			get
			{
				return this.m_OnFileLoadUpdate;
			}
		}

		// Token: 0x04012599 RID: 75161
		private readonly OnFileLoadSuccess m_OnFileLoadSuccess;

		// Token: 0x0401259A RID: 75162
		private readonly OnFileLoadFailure m_OnFileLoadFailure;

		// Token: 0x0401259B RID: 75163
		private readonly OnFileLoadUpdate m_OnFileLoadUpdate;
	}
}
