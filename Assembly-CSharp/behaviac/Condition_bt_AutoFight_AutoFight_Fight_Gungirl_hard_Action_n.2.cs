using System;

namespace behaviac
{
	// Token: 0x02001FA8 RID: 8104
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node3 : Condition
	{
		// Token: 0x060128EE RID: 76014 RVA: 0x0056FF73 File Offset: 0x0056E373
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128EF RID: 76015 RVA: 0x0056FFA8 File Offset: 0x0056E3A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2DF RID: 49887
		private int opl_p0;

		// Token: 0x0400C2E0 RID: 49888
		private int opl_p1;

		// Token: 0x0400C2E1 RID: 49889
		private int opl_p2;

		// Token: 0x0400C2E2 RID: 49890
		private int opl_p3;
	}
}
