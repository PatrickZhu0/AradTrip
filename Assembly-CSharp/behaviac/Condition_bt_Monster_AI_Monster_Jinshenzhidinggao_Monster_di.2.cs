using System;

namespace behaviac
{
	// Token: 0x02003689 RID: 13961
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2 : Condition
	{
		// Token: 0x06015530 RID: 87344 RVA: 0x0066EA3E File Offset: 0x0066CE3E
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015531 RID: 87345 RVA: 0x0066EA74 File Offset: 0x0066CE74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEF2 RID: 61170
		private int opl_p0;

		// Token: 0x0400EEF3 RID: 61171
		private int opl_p1;

		// Token: 0x0400EEF4 RID: 61172
		private int opl_p2;

		// Token: 0x0400EEF5 RID: 61173
		private int opl_p3;
	}
}
