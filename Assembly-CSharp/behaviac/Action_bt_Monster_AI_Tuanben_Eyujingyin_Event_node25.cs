using System;

namespace behaviac
{
	// Token: 0x0200399B RID: 14747
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node25 : Action
	{
		// Token: 0x06015B0B RID: 88843 RVA: 0x0068CFEF File Offset: 0x0068B3EF
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "现在的我充满了力量";
			this.method_p1 = 2f;
			this.method_p2 = 0;
		}

		// Token: 0x06015B0C RID: 88844 RVA: 0x0068D01B File Offset: 0x0068B41B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4A1 RID: 62625
		private string method_p0;

		// Token: 0x0400F4A2 RID: 62626
		private float method_p1;

		// Token: 0x0400F4A3 RID: 62627
		private int method_p2;
	}
}
