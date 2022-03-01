using System;

namespace behaviac
{
	// Token: 0x020034D6 RID: 13526
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node19 : Condition
	{
		// Token: 0x060151F1 RID: 86513 RVA: 0x0065D712 File Offset: 0x0065BB12
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node19()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521773;
		}

		// Token: 0x060151F2 RID: 86514 RVA: 0x0065D734 File Offset: 0x0065BB34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB03 RID: 60163
		private BE_Target opl_p0;

		// Token: 0x0400EB04 RID: 60164
		private BE_Equal opl_p1;

		// Token: 0x0400EB05 RID: 60165
		private int opl_p2;
	}
}
