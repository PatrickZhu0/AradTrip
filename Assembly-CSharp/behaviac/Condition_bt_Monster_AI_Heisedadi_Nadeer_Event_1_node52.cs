using System;

namespace behaviac
{
	// Token: 0x0200351B RID: 13595
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node52 : Condition
	{
		// Token: 0x06015279 RID: 86649 RVA: 0x0065F590 File Offset: 0x0065D990
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node52()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521774;
		}

		// Token: 0x0601527A RID: 86650 RVA: 0x0065F5B4 File Offset: 0x0065D9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBD4 RID: 60372
		private BE_Target opl_p0;

		// Token: 0x0400EBD5 RID: 60373
		private BE_Equal opl_p1;

		// Token: 0x0400EBD6 RID: 60374
		private int opl_p2;
	}
}
