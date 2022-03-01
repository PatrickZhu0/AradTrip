using System;

namespace behaviac
{
	// Token: 0x02003139 RID: 12601
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node7 : Condition
	{
		// Token: 0x06014B15 RID: 84757 RVA: 0x0063B457 File Offset: 0x00639857
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522053;
		}

		// Token: 0x06014B16 RID: 84758 RVA: 0x0063B478 File Offset: 0x00639878
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E489 RID: 58505
		private BE_Target opl_p0;

		// Token: 0x0400E48A RID: 58506
		private BE_Equal opl_p1;

		// Token: 0x0400E48B RID: 58507
		private int opl_p2;
	}
}
