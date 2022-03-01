using System;

namespace behaviac
{
	// Token: 0x02002D22 RID: 11554
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node0 : Action
	{
		// Token: 0x0601432F RID: 82735 RVA: 0x0061169A File Offset: 0x0060FA9A
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 96;
		}

		// Token: 0x06014330 RID: 82736 RVA: 0x006116B8 File Offset: 0x0060FAB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCE7 RID: 56551
		private BE_Target method_p0;

		// Token: 0x0400DCE8 RID: 56552
		private int method_p1;
	}
}
