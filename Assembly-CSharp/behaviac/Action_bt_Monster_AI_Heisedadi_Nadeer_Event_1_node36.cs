using System;

namespace behaviac
{
	// Token: 0x020034FE RID: 13566
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node36 : Action
	{
		// Token: 0x0601523F RID: 86591 RVA: 0x0065EC4B File Offset: 0x0065D04B
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node36()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521792;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015240 RID: 86592 RVA: 0x0065EC82 File Offset: 0x0065D082
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB71 RID: 60273
		private BE_Target method_p0;

		// Token: 0x0400EB72 RID: 60274
		private int method_p1;

		// Token: 0x0400EB73 RID: 60275
		private int method_p2;

		// Token: 0x0400EB74 RID: 60276
		private int method_p3;

		// Token: 0x0400EB75 RID: 60277
		private int method_p4;
	}
}
