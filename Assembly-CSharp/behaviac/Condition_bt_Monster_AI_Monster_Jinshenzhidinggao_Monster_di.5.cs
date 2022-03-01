using System;

namespace behaviac
{
	// Token: 0x0200368D RID: 13965
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7 : Condition
	{
		// Token: 0x06015538 RID: 87352 RVA: 0x0066EBF2 File Offset: 0x0066CFF2
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015539 RID: 87353 RVA: 0x0066EC28 File Offset: 0x0066D028
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEFA RID: 61178
		private int opl_p0;

		// Token: 0x0400EEFB RID: 61179
		private int opl_p1;

		// Token: 0x0400EEFC RID: 61180
		private int opl_p2;

		// Token: 0x0400EEFD RID: 61181
		private int opl_p3;
	}
}
