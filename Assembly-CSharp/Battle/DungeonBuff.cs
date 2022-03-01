using System;

namespace Battle
{
	// Token: 0x0200107F RID: 4223
	public class DungeonBuff : IComparable<DungeonBuff>
	{
		// Token: 0x06009F97 RID: 40855 RVA: 0x001FF798 File Offset: 0x001FDB98
		public int CompareTo(DungeonBuff buff)
		{
			if (this.id != buff.id)
			{
				return this.id - buff.id;
			}
			if (this.uid > buff.uid)
			{
				return 1;
			}
			if (this.uid < buff.uid)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x04005821 RID: 22561
		public ulong uid;

		// Token: 0x04005822 RID: 22562
		public int id = -1;

		// Token: 0x04005823 RID: 22563
		public int overlay = -1;

		// Token: 0x04005824 RID: 22564
		public float duration = -1f;

		// Token: 0x04005825 RID: 22565
		public float lefttime = -1f;

		// Token: 0x04005826 RID: 22566
		public DungeonBuff.eBuffDurationType type;

		// Token: 0x04005827 RID: 22567
		public bool readymove;

		// Token: 0x02001080 RID: 4224
		public enum eBuffDurationType
		{
			// Token: 0x04005829 RID: 22569
			Town,
			// Token: 0x0400582A RID: 22570
			Battle,
			// Token: 0x0400582B RID: 22571
			OnlyUseInBattle,
			// Token: 0x0400582C RID: 22572
			SpecialTown
		}
	}
}
