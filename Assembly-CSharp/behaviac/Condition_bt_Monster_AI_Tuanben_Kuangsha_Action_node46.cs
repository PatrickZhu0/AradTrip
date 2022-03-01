using System;

namespace behaviac
{
	// Token: 0x02003ADE RID: 15070
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node46 : Condition
	{
		// Token: 0x06015D7B RID: 89467 RVA: 0x0069906B File Offset: 0x0069746B
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node46()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015D7C RID: 89468 RVA: 0x006990A0 File Offset: 0x006974A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F68A RID: 63114
		private int opl_p0;

		// Token: 0x0400F68B RID: 63115
		private int opl_p1;

		// Token: 0x0400F68C RID: 63116
		private int opl_p2;

		// Token: 0x0400F68D RID: 63117
		private int opl_p3;
	}
}
