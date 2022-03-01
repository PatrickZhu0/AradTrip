using System;

namespace behaviac
{
	// Token: 0x02003549 RID: 13641
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node9 : Action
	{
		// Token: 0x060152D3 RID: 86739 RVA: 0x00661DEF File Offset: 0x006601EF
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521738;
		}

		// Token: 0x060152D4 RID: 86740 RVA: 0x00661E10 File Offset: 0x00660210
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC89 RID: 60553
		private BE_Target method_p0;

		// Token: 0x0400EC8A RID: 60554
		private int method_p1;
	}
}
