using System;

namespace behaviac
{
	// Token: 0x02003696 RID: 13974
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node1 : Condition
	{
		// Token: 0x06015549 RID: 87369 RVA: 0x0066F24D File Offset: 0x0066D64D
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node1()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601554A RID: 87370 RVA: 0x0066F284 File Offset: 0x0066D684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF0C RID: 61196
		private int opl_p0;

		// Token: 0x0400EF0D RID: 61197
		private int opl_p1;

		// Token: 0x0400EF0E RID: 61198
		private int opl_p2;

		// Token: 0x0400EF0F RID: 61199
		private int opl_p3;
	}
}
