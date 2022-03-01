using System;

namespace behaviac
{
	// Token: 0x020024E5 RID: 9445
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node37 : Condition
	{
		// Token: 0x06013314 RID: 78612 RVA: 0x005B2B4F File Offset: 0x005B0F4F
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node37()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013315 RID: 78613 RVA: 0x005B2B84 File Offset: 0x005B0F84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD30 RID: 52528
		private int opl_p0;

		// Token: 0x0400CD31 RID: 52529
		private int opl_p1;

		// Token: 0x0400CD32 RID: 52530
		private int opl_p2;

		// Token: 0x0400CD33 RID: 52531
		private int opl_p3;
	}
}
