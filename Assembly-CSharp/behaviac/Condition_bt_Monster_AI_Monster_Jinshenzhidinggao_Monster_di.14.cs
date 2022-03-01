using System;

namespace behaviac
{
	// Token: 0x0200369B RID: 13979
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node19 : Condition
	{
		// Token: 0x06015552 RID: 87378 RVA: 0x0066F605 File Offset: 0x0066DA05
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node19()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06015553 RID: 87379 RVA: 0x0066F63C File Offset: 0x0066DA3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF16 RID: 61206
		private int opl_p0;

		// Token: 0x0400EF17 RID: 61207
		private int opl_p1;

		// Token: 0x0400EF18 RID: 61208
		private int opl_p2;

		// Token: 0x0400EF19 RID: 61209
		private int opl_p3;
	}
}
