using System;

namespace behaviac
{
	// Token: 0x02003460 RID: 13408
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node22 : Action
	{
		// Token: 0x0601510C RID: 86284 RVA: 0x00658941 File Offset: 0x00656D41
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521856;
			this.method_p2 = -1;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x0601510D RID: 86285 RVA: 0x00658978 File Offset: 0x00656D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA04 RID: 59908
		private BE_Target method_p0;

		// Token: 0x0400EA05 RID: 59909
		private int method_p1;

		// Token: 0x0400EA06 RID: 59910
		private int method_p2;

		// Token: 0x0400EA07 RID: 59911
		private int method_p3;

		// Token: 0x0400EA08 RID: 59912
		private int method_p4;
	}
}
