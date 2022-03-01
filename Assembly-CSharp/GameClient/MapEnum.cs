using System;

namespace GameClient
{
	// Token: 0x020016C4 RID: 5828
	public class MapEnum : Attribute
	{
		// Token: 0x0600E455 RID: 58453 RVA: 0x003B1617 File Offset: 0x003AFA17
		public MapEnum(EEquipProp prop)
		{
			this.Prop = prop;
		}

		// Token: 0x0400898D RID: 35213
		public EEquipProp Prop;
	}
}
