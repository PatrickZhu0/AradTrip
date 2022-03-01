using System;

namespace GameClient
{
	// Token: 0x020016C8 RID: 5832
	public class PropAttribute : Attribute
	{
		// Token: 0x0600E458 RID: 58456 RVA: 0x003B1636 File Offset: 0x003AFA36
		public PropAttribute(string desc, string fieldName, bool bInverse = false)
		{
			this.desc = desc;
			this.fieldName = fieldName;
			this.bInverse = bInverse;
		}

		// Token: 0x040089D6 RID: 35286
		public string desc;

		// Token: 0x040089D7 RID: 35287
		public string fieldName;

		// Token: 0x040089D8 RID: 35288
		public bool bInverse;
	}
}
