using System;

namespace behaviac
{
	// Token: 0x02003AEA RID: 15082
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node4 : Condition
	{
		// Token: 0x06015D92 RID: 89490 RVA: 0x0069A043 File Offset: 0x00698443
		public Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node4()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015D93 RID: 89491 RVA: 0x0069A078 File Offset: 0x00698478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F698 RID: 63128
		private int opl_p0;

		// Token: 0x0400F699 RID: 63129
		private int opl_p1;

		// Token: 0x0400F69A RID: 63130
		private int opl_p2;

		// Token: 0x0400F69B RID: 63131
		private int opl_p3;
	}
}
