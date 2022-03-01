using System;

namespace behaviac
{
	// Token: 0x0200247A RID: 9338
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node8 : Condition
	{
		// Token: 0x06013242 RID: 78402 RVA: 0x005AE493 File Offset: 0x005AC893
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node8()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013243 RID: 78403 RVA: 0x005AE4C8 File Offset: 0x005AC8C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC5E RID: 52318
		private int opl_p0;

		// Token: 0x0400CC5F RID: 52319
		private int opl_p1;

		// Token: 0x0400CC60 RID: 52320
		private int opl_p2;

		// Token: 0x0400CC61 RID: 52321
		private int opl_p3;
	}
}
