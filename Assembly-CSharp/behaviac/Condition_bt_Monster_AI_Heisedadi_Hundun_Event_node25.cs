using System;

namespace behaviac
{
	// Token: 0x02003452 RID: 13394
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node25 : Condition
	{
		// Token: 0x060150F0 RID: 86256 RVA: 0x0065845A File Offset: 0x0065685A
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node25()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521857;
		}

		// Token: 0x060150F1 RID: 86257 RVA: 0x0065847C File Offset: 0x0065687C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9D4 RID: 59860
		private BE_Target opl_p0;

		// Token: 0x0400E9D5 RID: 59861
		private BE_Equal opl_p1;

		// Token: 0x0400E9D6 RID: 59862
		private int opl_p2;
	}
}
