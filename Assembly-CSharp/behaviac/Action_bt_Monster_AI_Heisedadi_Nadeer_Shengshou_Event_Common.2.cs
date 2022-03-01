using System;

namespace behaviac
{
	// Token: 0x02003547 RID: 13639
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node6 : Action
	{
		// Token: 0x060152CF RID: 86735 RVA: 0x00661D53 File Offset: 0x00660153
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521737;
		}

		// Token: 0x060152D0 RID: 86736 RVA: 0x00661D74 File Offset: 0x00660174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC84 RID: 60548
		private BE_Target method_p0;

		// Token: 0x0400EC85 RID: 60549
		private int method_p1;
	}
}
