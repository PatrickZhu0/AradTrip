using System;

namespace behaviac
{
	// Token: 0x02002467 RID: 9319
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node38 : Condition
	{
		// Token: 0x0601321E RID: 78366 RVA: 0x005AD4C7 File Offset: 0x005AB8C7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601321F RID: 78367 RVA: 0x005AD4FC File Offset: 0x005AB8FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC40 RID: 52288
		private int opl_p0;

		// Token: 0x0400CC41 RID: 52289
		private int opl_p1;

		// Token: 0x0400CC42 RID: 52290
		private int opl_p2;

		// Token: 0x0400CC43 RID: 52291
		private int opl_p3;
	}
}
