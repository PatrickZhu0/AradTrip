using System;

namespace behaviac
{
	// Token: 0x020036B7 RID: 14007
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node2 : Condition
	{
		// Token: 0x06015588 RID: 87432 RVA: 0x006704C2 File Offset: 0x0066E8C2
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015589 RID: 87433 RVA: 0x006704F8 File Offset: 0x0066E8F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF5C RID: 61276
		private int opl_p0;

		// Token: 0x0400EF5D RID: 61277
		private int opl_p1;

		// Token: 0x0400EF5E RID: 61278
		private int opl_p2;

		// Token: 0x0400EF5F RID: 61279
		private int opl_p3;
	}
}
