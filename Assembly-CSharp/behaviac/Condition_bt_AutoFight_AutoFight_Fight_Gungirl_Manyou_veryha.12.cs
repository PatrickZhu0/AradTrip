using System;

namespace behaviac
{
	// Token: 0x02002077 RID: 8311
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node28 : Condition
	{
		// Token: 0x06012A87 RID: 76423 RVA: 0x005796BF File Offset: 0x00577ABF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06012A88 RID: 76424 RVA: 0x005796F4 File Offset: 0x00577AF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C479 RID: 50297
		private int opl_p0;

		// Token: 0x0400C47A RID: 50298
		private int opl_p1;

		// Token: 0x0400C47B RID: 50299
		private int opl_p2;

		// Token: 0x0400C47C RID: 50300
		private int opl_p3;
	}
}
