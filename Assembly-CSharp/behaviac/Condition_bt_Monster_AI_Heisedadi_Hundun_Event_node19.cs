using System;

namespace behaviac
{
	// Token: 0x02003459 RID: 13401
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node19 : Condition
	{
		// Token: 0x060150FE RID: 86270 RVA: 0x006586CC File Offset: 0x00656ACC
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node19()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521855;
		}

		// Token: 0x060150FF RID: 86271 RVA: 0x006586F0 File Offset: 0x00656AF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9ED RID: 59885
		private BE_Target opl_p0;

		// Token: 0x0400E9EE RID: 59886
		private BE_Equal opl_p1;

		// Token: 0x0400E9EF RID: 59887
		private int opl_p2;
	}
}
