using System;

namespace behaviac
{
	// Token: 0x0200313B RID: 12603
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node10 : Condition
	{
		// Token: 0x06014B19 RID: 84761 RVA: 0x0063B51A File Offset: 0x0063991A
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522051;
		}

		// Token: 0x06014B1A RID: 84762 RVA: 0x0063B53C File Offset: 0x0063993C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E491 RID: 58513
		private BE_Target opl_p0;

		// Token: 0x0400E492 RID: 58514
		private BE_Equal opl_p1;

		// Token: 0x0400E493 RID: 58515
		private int opl_p2;
	}
}
