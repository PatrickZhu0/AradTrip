using System;

namespace behaviac
{
	// Token: 0x02002223 RID: 8739
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node43 : Condition
	{
		// Token: 0x06012DD0 RID: 77264 RVA: 0x0058E6AB File Offset: 0x0058CAAB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node43()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06012DD1 RID: 77265 RVA: 0x0058E6E0 File Offset: 0x0058CAE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7C6 RID: 51142
		private int opl_p0;

		// Token: 0x0400C7C7 RID: 51143
		private int opl_p1;

		// Token: 0x0400C7C8 RID: 51144
		private int opl_p2;

		// Token: 0x0400C7C9 RID: 51145
		private int opl_p3;
	}
}
