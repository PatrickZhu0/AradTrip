using System;

namespace behaviac
{
	// Token: 0x0200349D RID: 13469
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node49 : Condition
	{
		// Token: 0x06015183 RID: 86403 RVA: 0x0065AA83 File Offset: 0x00658E83
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node49()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x06015184 RID: 86404 RVA: 0x0065AAA4 File Offset: 0x00658EA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA83 RID: 60035
		private BE_Target opl_p0;

		// Token: 0x0400EA84 RID: 60036
		private BE_Equal opl_p1;

		// Token: 0x0400EA85 RID: 60037
		private int opl_p2;
	}
}
