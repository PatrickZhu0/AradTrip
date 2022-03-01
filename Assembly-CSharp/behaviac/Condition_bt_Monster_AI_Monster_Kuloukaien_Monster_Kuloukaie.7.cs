using System;

namespace behaviac
{
	// Token: 0x020036B3 RID: 14003
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node17 : Condition
	{
		// Token: 0x06015580 RID: 87424 RVA: 0x0067030E File Offset: 0x0066E70E
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06015581 RID: 87425 RVA: 0x00670344 File Offset: 0x0066E744
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF54 RID: 61268
		private int opl_p0;

		// Token: 0x0400EF55 RID: 61269
		private int opl_p1;

		// Token: 0x0400EF56 RID: 61270
		private int opl_p2;

		// Token: 0x0400EF57 RID: 61271
		private int opl_p3;
	}
}
