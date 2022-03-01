using System;

namespace behaviac
{
	// Token: 0x020034BF RID: 13503
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node24 : Condition
	{
		// Token: 0x060151C4 RID: 86468 RVA: 0x0065C44A File Offset: 0x0065A84A
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node24()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521752;
		}

		// Token: 0x060151C5 RID: 86469 RVA: 0x0065C46C File Offset: 0x0065A86C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EACC RID: 60108
		private BE_Target opl_p0;

		// Token: 0x0400EACD RID: 60109
		private BE_Equal opl_p1;

		// Token: 0x0400EACE RID: 60110
		private int opl_p2;
	}
}
