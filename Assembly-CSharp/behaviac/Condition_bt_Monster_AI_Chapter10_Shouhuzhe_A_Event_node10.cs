using System;

namespace behaviac
{
	// Token: 0x02003126 RID: 12582
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node10 : Condition
	{
		// Token: 0x06014AF1 RID: 84721 RVA: 0x0063A836 File Offset: 0x00638C36
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522051;
		}

		// Token: 0x06014AF2 RID: 84722 RVA: 0x0063A858 File Offset: 0x00638C58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E463 RID: 58467
		private BE_Target opl_p0;

		// Token: 0x0400E464 RID: 58468
		private BE_Equal opl_p1;

		// Token: 0x0400E465 RID: 58469
		private int opl_p2;
	}
}
