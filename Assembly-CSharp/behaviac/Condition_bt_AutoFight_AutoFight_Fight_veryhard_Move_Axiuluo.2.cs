using System;

namespace behaviac
{
	// Token: 0x02002476 RID: 9334
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node21 : Condition
	{
		// Token: 0x0601323A RID: 78394 RVA: 0x005AE31F File Offset: 0x005AC71F
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node21()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x0601323B RID: 78395 RVA: 0x005AE354 File Offset: 0x005AC754
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC57 RID: 52311
		private int opl_p0;

		// Token: 0x0400CC58 RID: 52312
		private int opl_p1;

		// Token: 0x0400CC59 RID: 52313
		private int opl_p2;

		// Token: 0x0400CC5A RID: 52314
		private int opl_p3;
	}
}
