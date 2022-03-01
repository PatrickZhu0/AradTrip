using System;

namespace behaviac
{
	// Token: 0x020024DD RID: 9437
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node27 : Condition
	{
		// Token: 0x06013304 RID: 78596 RVA: 0x005B27E3 File Offset: 0x005B0BE3
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node27()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013305 RID: 78597 RVA: 0x005B2818 File Offset: 0x005B0C18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD20 RID: 52512
		private int opl_p0;

		// Token: 0x0400CD21 RID: 52513
		private int opl_p1;

		// Token: 0x0400CD22 RID: 52514
		private int opl_p2;

		// Token: 0x0400CD23 RID: 52515
		private int opl_p3;
	}
}
