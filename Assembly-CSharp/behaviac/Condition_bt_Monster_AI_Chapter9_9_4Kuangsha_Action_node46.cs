using System;

namespace behaviac
{
	// Token: 0x0200318D RID: 12685
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node46 : Condition
	{
		// Token: 0x06014BB1 RID: 84913 RVA: 0x0063DC9F File Offset: 0x0063C09F
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node46()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014BB2 RID: 84914 RVA: 0x0063DCD4 File Offset: 0x0063C0D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E51E RID: 58654
		private int opl_p0;

		// Token: 0x0400E51F RID: 58655
		private int opl_p1;

		// Token: 0x0400E520 RID: 58656
		private int opl_p2;

		// Token: 0x0400E521 RID: 58657
		private int opl_p3;
	}
}
