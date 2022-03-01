using System;

namespace behaviac
{
	// Token: 0x02002296 RID: 8854
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node2 : Condition
	{
		// Token: 0x06012EAB RID: 77483 RVA: 0x00594D29 File Offset: 0x00593129
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012EAC RID: 77484 RVA: 0x00594D60 File Offset: 0x00593160
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8B6 RID: 51382
		private int opl_p0;

		// Token: 0x0400C8B7 RID: 51383
		private int opl_p1;

		// Token: 0x0400C8B8 RID: 51384
		private int opl_p2;

		// Token: 0x0400C8B9 RID: 51385
		private int opl_p3;
	}
}
