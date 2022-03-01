using System;

namespace behaviac
{
	// Token: 0x02003121 RID: 12577
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node1 : Condition
	{
		// Token: 0x06014AE7 RID: 84711 RVA: 0x0063A656 File Offset: 0x00638A56
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522054;
		}

		// Token: 0x06014AE8 RID: 84712 RVA: 0x0063A678 File Offset: 0x00638A78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E451 RID: 58449
		private BE_Target opl_p0;

		// Token: 0x0400E452 RID: 58450
		private BE_Equal opl_p1;

		// Token: 0x0400E453 RID: 58451
		private int opl_p2;
	}
}
