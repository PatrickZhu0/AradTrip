using System;

namespace behaviac
{
	// Token: 0x02003445 RID: 13381
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node11 : Action
	{
		// Token: 0x060150D6 RID: 86230 RVA: 0x00657FEA File Offset: 0x006563EA
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "消逝于混沌中吧！";
			this.method_p1 = 5f;
			this.method_p2 = 0;
		}

		// Token: 0x060150D7 RID: 86231 RVA: 0x00658016 File Offset: 0x00656416
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9A9 RID: 59817
		private string method_p0;

		// Token: 0x0400E9AA RID: 59818
		private float method_p1;

		// Token: 0x0400E9AB RID: 59819
		private int method_p2;
	}
}
