using System;

namespace TMEngine.Runtime
{
	// Token: 0x02004718 RID: 18200
	public abstract class ReferencePoolBase
	{
		// Token: 0x0601A1E2 RID: 106978 RVA: 0x0081F949 File Offset: 0x0081DD49
		public ReferencePoolBase() : this("TMEngine Object Pool:Unnamed")
		{
		}

		// Token: 0x0601A1E3 RID: 106979 RVA: 0x0081F956 File Offset: 0x0081DD56
		public ReferencePoolBase(string name)
		{
			this.m_Name = (name ?? string.Empty);
		}

		// Token: 0x17002205 RID: 8709
		// (get) Token: 0x0601A1E4 RID: 106980 RVA: 0x0081F971 File Offset: 0x0081DD71
		public string Name
		{
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x17002206 RID: 8710
		// (get) Token: 0x0601A1E5 RID: 106981
		public abstract Type ObjectType { get; }

		// Token: 0x17002207 RID: 8711
		// (get) Token: 0x0601A1E6 RID: 106982
		public abstract int ObjectCount { get; }

		// Token: 0x17002208 RID: 8712
		// (get) Token: 0x0601A1E7 RID: 106983
		public abstract int Capacity { get; }

		// Token: 0x17002209 RID: 8713
		// (get) Token: 0x0601A1E8 RID: 106984
		public abstract float ExpireTime { get; }

		// Token: 0x1700220A RID: 8714
		// (get) Token: 0x0601A1E9 RID: 106985
		public abstract int CanReleasedCount { get; }

		// Token: 0x1700220B RID: 8715
		// (get) Token: 0x0601A1EA RID: 106986
		public abstract bool AllowMultiRef { get; }

		// Token: 0x1700220C RID: 8716
		// (get) Token: 0x0601A1EB RID: 106987
		public abstract float AutoPurgeInterval { get; }

		// Token: 0x1700220D RID: 8717
		// (get) Token: 0x0601A1EC RID: 106988
		public abstract int Priority { get; }

		// Token: 0x0601A1ED RID: 106989
		public abstract void PurgePool(ref float timeSlice);

		// Token: 0x0601A1EE RID: 106990
		public abstract void ReleaseUnusedObject(bool releaseAll);

		// Token: 0x0601A1EF RID: 106991
		internal abstract void Update(float elapseSeconds, float realElapseSeconds);

		// Token: 0x0601A1F0 RID: 106992
		internal abstract void Shutdown();

		// Token: 0x0601A1F1 RID: 106993
		public abstract ObjectDesc[] GetAllObjectInfos();

		// Token: 0x040125DF RID: 75231
		private readonly string m_Name;
	}
}
