using System;

namespace GameClient
{
	// Token: 0x020016CD RID: 5837
	public class EquipPropAttribute : Attribute
	{
		// Token: 0x0600E45A RID: 58458 RVA: 0x003B1662 File Offset: 0x003AFA62
		public EquipPropAttribute(EEquipProp prop)
		{
			this.Prop = prop;
		}

		// Token: 0x04008A05 RID: 35333
		public EEquipProp Prop;
	}
}
