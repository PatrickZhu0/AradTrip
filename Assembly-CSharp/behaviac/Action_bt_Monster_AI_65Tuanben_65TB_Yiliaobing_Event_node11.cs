using System;

namespace behaviac
{
	// Token: 0x02002D21 RID: 11553
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node11 : Action
	{
		// Token: 0x0601432D RID: 82733 RVA: 0x0061165F File Offset: 0x0060FA5F
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521983;
		}

		// Token: 0x0601432E RID: 82734 RVA: 0x00611680 File Offset: 0x0060FA80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCE5 RID: 56549
		private BE_Target method_p0;

		// Token: 0x0400DCE6 RID: 56550
		private int method_p1;
	}
}
