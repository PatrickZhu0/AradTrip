using System;

namespace behaviac
{
	// Token: 0x02003B0E RID: 15118
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node4 : Condition
	{
		// Token: 0x06015DD6 RID: 89558 RVA: 0x0069B45B File Offset: 0x0069985B
		public Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node4()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015DD7 RID: 89559 RVA: 0x0069B490 File Offset: 0x00699890
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6C2 RID: 63170
		private int opl_p0;

		// Token: 0x0400F6C3 RID: 63171
		private int opl_p1;

		// Token: 0x0400F6C4 RID: 63172
		private int opl_p2;

		// Token: 0x0400F6C5 RID: 63173
		private int opl_p3;
	}
}
