using System;

namespace behaviac
{
	// Token: 0x020034EE RID: 13550
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node9 : Condition
	{
		// Token: 0x0601521F RID: 86559 RVA: 0x0065E711 File Offset: 0x0065CB11
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521747;
		}

		// Token: 0x06015220 RID: 86560 RVA: 0x0065E734 File Offset: 0x0065CB34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB3F RID: 60223
		private BE_Target opl_p0;

		// Token: 0x0400EB40 RID: 60224
		private BE_Equal opl_p1;

		// Token: 0x0400EB41 RID: 60225
		private int opl_p2;
	}
}
