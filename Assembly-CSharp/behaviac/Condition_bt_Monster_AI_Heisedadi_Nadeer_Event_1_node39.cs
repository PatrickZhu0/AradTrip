using System;

namespace behaviac
{
	// Token: 0x02003500 RID: 13568
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node39 : Condition
	{
		// Token: 0x06015243 RID: 86595 RVA: 0x0065ED11 File Offset: 0x0065D111
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node39()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521740;
		}

		// Token: 0x06015244 RID: 86596 RVA: 0x0065ED34 File Offset: 0x0065D134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB7B RID: 60283
		private BE_Target opl_p0;

		// Token: 0x0400EB7C RID: 60284
		private BE_Equal opl_p1;

		// Token: 0x0400EB7D RID: 60285
		private int opl_p2;
	}
}
