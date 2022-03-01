using System;

namespace behaviac
{
	// Token: 0x02003124 RID: 12580
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node7 : Condition
	{
		// Token: 0x06014AED RID: 84717 RVA: 0x0063A773 File Offset: 0x00638B73
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522053;
		}

		// Token: 0x06014AEE RID: 84718 RVA: 0x0063A794 File Offset: 0x00638B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E45B RID: 58459
		private BE_Target opl_p0;

		// Token: 0x0400E45C RID: 58460
		private BE_Equal opl_p1;

		// Token: 0x0400E45D RID: 58461
		private int opl_p2;
	}
}
