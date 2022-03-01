using System;

namespace behaviac
{
	// Token: 0x020034C2 RID: 13506
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node28 : Condition
	{
		// Token: 0x060151CA RID: 86474 RVA: 0x0065C52F File Offset: 0x0065A92F
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node28()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521752;
		}

		// Token: 0x060151CB RID: 86475 RVA: 0x0065C550 File Offset: 0x0065A950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAD2 RID: 60114
		private BE_Target opl_p0;

		// Token: 0x0400EAD3 RID: 60115
		private BE_Equal opl_p1;

		// Token: 0x0400EAD4 RID: 60116
		private int opl_p2;
	}
}
