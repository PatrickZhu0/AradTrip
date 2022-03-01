using System;

namespace behaviac
{
	// Token: 0x0200345A RID: 13402
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node21 : Condition
	{
		// Token: 0x06015100 RID: 86272 RVA: 0x00658732 File Offset: 0x00656B32
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node21()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521858;
		}

		// Token: 0x06015101 RID: 86273 RVA: 0x00658754 File Offset: 0x00656B54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9F0 RID: 59888
		private BE_Target opl_p0;

		// Token: 0x0400E9F1 RID: 59889
		private BE_Equal opl_p1;

		// Token: 0x0400E9F2 RID: 59890
		private int opl_p2;
	}
}
