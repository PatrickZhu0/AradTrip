using System;

namespace HeroInput
{
	// Token: 0x0200016C RID: 364
	public class DirectionTree
	{
		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x000367F2 File Offset: 0x00034BF2
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x000367FA File Offset: 0x00034BFA
		public int slot
		{
			get
			{
				return this.mSlot;
			}
			set
			{
				this.mSlot = value;
			}
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00036804 File Offset: 0x00034C04
		public DirectionTree AddChild(InputDirection dir, int slot)
		{
			if (dir >= (InputDirection)this.mDirection.Length)
			{
				Logger.LogError("out of range");
				return null;
			}
			if (this.mDirection[(int)dir] == null)
			{
				this.mDirection[(int)dir] = new DirectionTree
				{
					mParent = this,
					mSlot = slot
				};
			}
			return this.mDirection[(int)dir];
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00036860 File Offset: 0x00034C60
		public DirectionTree GetChild(InputDirection dir)
		{
			if (dir >= (InputDirection)this.mDirection.Length)
			{
				Logger.LogError("out of range");
				return null;
			}
			return this.mDirection[(int)dir];
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00036894 File Offset: 0x00034C94
		public void Clear()
		{
			this.mParent = null;
			for (int i = 0; i < 4; i++)
			{
				this.mDirection[i] = null;
			}
		}

		// Token: 0x040007AC RID: 1964
		private const int kDirectionCount = 4;

		// Token: 0x040007AD RID: 1965
		private DirectionTree[] mDirection = new DirectionTree[4];

		// Token: 0x040007AE RID: 1966
		private DirectionTree mParent;

		// Token: 0x040007AF RID: 1967
		private int mSlot;
	}
}
