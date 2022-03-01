using System;

namespace behaviac
{
	// Token: 0x02002CB6 RID: 11446
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node15 : Condition
	{
		// Token: 0x06014261 RID: 82529 RVA: 0x0060D06E File Offset: 0x0060B46E
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node15()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522109;
		}

		// Token: 0x06014262 RID: 82530 RVA: 0x0060D090 File Offset: 0x0060B490
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC19 RID: 56345
		private BE_Target opl_p0;

		// Token: 0x0400DC1A RID: 56346
		private BE_Equal opl_p1;

		// Token: 0x0400DC1B RID: 56347
		private int opl_p2;
	}
}
