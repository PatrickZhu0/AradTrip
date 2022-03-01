using System;

namespace behaviac
{
	// Token: 0x02002C3D RID: 11325
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node25 : Action
	{
		// Token: 0x06014176 RID: 82294 RVA: 0x00608AE8 File Offset: 0x00606EE8
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node25()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x06014177 RID: 82295 RVA: 0x00608B0C File Offset: 0x00606F0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DB34 RID: 56116
		private int method_p0;

		// Token: 0x0400DB35 RID: 56117
		private int method_p1;
	}
}
