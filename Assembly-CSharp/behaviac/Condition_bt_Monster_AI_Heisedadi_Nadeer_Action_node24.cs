using System;

namespace behaviac
{
	// Token: 0x020034E2 RID: 13538
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node24 : Condition
	{
		// Token: 0x06015209 RID: 86537 RVA: 0x0065DC7A File Offset: 0x0065C07A
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node24()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521773;
		}

		// Token: 0x0601520A RID: 86538 RVA: 0x0065DC9C File Offset: 0x0065C09C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB21 RID: 60193
		private BE_Target opl_p0;

		// Token: 0x0400EB22 RID: 60194
		private BE_Equal opl_p1;

		// Token: 0x0400EB23 RID: 60195
		private int opl_p2;
	}
}
