using System;

namespace behaviac
{
	// Token: 0x02002C40 RID: 11328
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node2 : Action
	{
		// Token: 0x0601417C RID: 82300 RVA: 0x00608BEC File Offset: 0x00606FEC
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521985;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601417D RID: 82301 RVA: 0x00608C23 File Offset: 0x00607023
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB3B RID: 56123
		private BE_Target method_p0;

		// Token: 0x0400DB3C RID: 56124
		private int method_p1;

		// Token: 0x0400DB3D RID: 56125
		private int method_p2;

		// Token: 0x0400DB3E RID: 56126
		private int method_p3;

		// Token: 0x0400DB3F RID: 56127
		private int method_p4;
	}
}
