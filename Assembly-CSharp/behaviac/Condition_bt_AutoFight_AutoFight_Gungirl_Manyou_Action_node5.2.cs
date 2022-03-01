using System;

namespace behaviac
{
	// Token: 0x020024E9 RID: 9449
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node57 : Condition
	{
		// Token: 0x0601331C RID: 78620 RVA: 0x005B2DB3 File Offset: 0x005B11B3
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node57()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601331D RID: 78621 RVA: 0x005B2DE8 File Offset: 0x005B11E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD38 RID: 52536
		private int opl_p0;

		// Token: 0x0400CD39 RID: 52537
		private int opl_p1;

		// Token: 0x0400CD3A RID: 52538
		private int opl_p2;

		// Token: 0x0400CD3B RID: 52539
		private int opl_p3;
	}
}
