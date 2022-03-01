using System;

namespace behaviac
{
	// Token: 0x02002C66 RID: 11366
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node25 : Action
	{
		// Token: 0x060141C5 RID: 82373 RVA: 0x0060A444 File Offset: 0x00608844
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node25()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x060141C6 RID: 82374 RVA: 0x0060A468 File Offset: 0x00608868
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DB7E RID: 56190
		private int method_p0;

		// Token: 0x0400DB7F RID: 56191
		private int method_p1;
	}
}
