using System;

namespace behaviac
{
	// Token: 0x020035EC RID: 13804
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node3 : Condition
	{
		// Token: 0x060153FF RID: 87039 RVA: 0x00667E43 File Offset: 0x00666243
		public Condition_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node3()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015400 RID: 87040 RVA: 0x00667E78 File Offset: 0x00666278
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDB8 RID: 60856
		private int opl_p0;

		// Token: 0x0400EDB9 RID: 60857
		private int opl_p1;

		// Token: 0x0400EDBA RID: 60858
		private int opl_p2;

		// Token: 0x0400EDBB RID: 60859
		private int opl_p3;
	}
}
