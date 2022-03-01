using System;

namespace GameClient
{
	// Token: 0x02001183 RID: 4483
	public class ActionPlayData
	{
		// Token: 0x17001A40 RID: 6720
		// (get) Token: 0x0600AB95 RID: 43925 RVA: 0x0024CFB4 File Offset: 0x0024B3B4
		// (set) Token: 0x0600AB96 RID: 43926 RVA: 0x0024CFBC File Offset: 0x0024B3BC
		public string ActionName
		{
			get
			{
				return this.actionName;
			}
			set
			{
				if (this.actionName != value)
				{
					this.actionName = value;
					this.m_bDirty = true;
				}
			}
		}

		// Token: 0x17001A41 RID: 6721
		// (get) Token: 0x0600AB97 RID: 43927 RVA: 0x0024CFDD File Offset: 0x0024B3DD
		// (set) Token: 0x0600AB98 RID: 43928 RVA: 0x0024CFE5 File Offset: 0x0024B3E5
		public float ActionSpeed
		{
			get
			{
				return this.actionSpeed;
			}
			set
			{
				if (this.actionSpeed != value)
				{
					this.actionSpeed = value;
					this.m_bDirty = true;
				}
			}
		}

		// Token: 0x17001A42 RID: 6722
		// (get) Token: 0x0600AB99 RID: 43929 RVA: 0x0024D001 File Offset: 0x0024B401
		// (set) Token: 0x0600AB9A RID: 43930 RVA: 0x0024D009 File Offset: 0x0024B409
		public bool ActionLoop
		{
			get
			{
				return this.actionLoop;
			}
			set
			{
				if (this.actionLoop != value)
				{
					this.actionLoop = value;
					this.m_bDirty = true;
				}
			}
		}

		// Token: 0x17001A43 RID: 6723
		// (get) Token: 0x0600AB9B RID: 43931 RVA: 0x0024D025 File Offset: 0x0024B425
		// (set) Token: 0x0600AB9C RID: 43932 RVA: 0x0024D02D File Offset: 0x0024B42D
		public bool isDirty
		{
			get
			{
				return this.m_bDirty;
			}
			set
			{
				this.m_bDirty = value;
			}
		}

		// Token: 0x04006035 RID: 24629
		protected string actionName = "Anim_Idle01";

		// Token: 0x04006036 RID: 24630
		protected bool actionLoop = true;

		// Token: 0x04006037 RID: 24631
		protected float actionSpeed = 1f;

		// Token: 0x04006038 RID: 24632
		protected bool m_bDirty = true;
	}
}
