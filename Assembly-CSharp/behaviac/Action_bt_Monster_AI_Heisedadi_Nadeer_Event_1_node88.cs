using System;

namespace behaviac
{
	// Token: 0x02003524 RID: 13604
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node88 : Action
	{
		// Token: 0x0601528B RID: 86667 RVA: 0x0065F8F0 File Offset: 0x0065DCF0
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node88()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521742;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601528C RID: 86668 RVA: 0x0065F927 File Offset: 0x0065DD27
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBFB RID: 60411
		private BE_Target method_p0;

		// Token: 0x0400EBFC RID: 60412
		private int method_p1;

		// Token: 0x0400EBFD RID: 60413
		private int method_p2;

		// Token: 0x0400EBFE RID: 60414
		private int method_p3;

		// Token: 0x0400EBFF RID: 60415
		private int method_p4;
	}
}
