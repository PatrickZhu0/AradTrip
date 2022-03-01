using System;

namespace behaviac
{
	// Token: 0x020024FA RID: 9466
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node46 : Condition
	{
		// Token: 0x0601333E RID: 78654 RVA: 0x005B3717 File Offset: 0x005B1B17
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node46()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601333F RID: 78655 RVA: 0x005B374C File Offset: 0x005B1B4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD5D RID: 52573
		private int opl_p0;

		// Token: 0x0400CD5E RID: 52574
		private int opl_p1;

		// Token: 0x0400CD5F RID: 52575
		private int opl_p2;

		// Token: 0x0400CD60 RID: 52576
		private int opl_p3;
	}
}
