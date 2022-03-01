using System;

namespace behaviac
{
	// Token: 0x02003136 RID: 12598
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node1 : Condition
	{
		// Token: 0x06014B0F RID: 84751 RVA: 0x0063B33A File Offset: 0x0063973A
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522054;
		}

		// Token: 0x06014B10 RID: 84752 RVA: 0x0063B35C File Offset: 0x0063975C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E47F RID: 58495
		private BE_Target opl_p0;

		// Token: 0x0400E480 RID: 58496
		private BE_Equal opl_p1;

		// Token: 0x0400E481 RID: 58497
		private int opl_p2;
	}
}
