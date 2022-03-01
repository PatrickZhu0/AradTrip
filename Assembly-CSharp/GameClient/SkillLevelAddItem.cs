using System;

namespace GameClient
{
	// Token: 0x020012ED RID: 4845
	public class SkillLevelAddItem
	{
		// Token: 0x0600BBC8 RID: 48072 RVA: 0x002BA1CE File Offset: 0x002B85CE
		public SkillLevelAddItem(SkillLevelAddType t, int n)
		{
			this.type = t;
			this.addLevel = n;
		}

		// Token: 0x040069A7 RID: 27047
		public SkillLevelAddType type;

		// Token: 0x040069A8 RID: 27048
		public int addLevel;
	}
}
