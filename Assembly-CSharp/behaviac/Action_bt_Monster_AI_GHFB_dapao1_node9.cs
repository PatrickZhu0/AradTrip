using System;

namespace behaviac
{
	// Token: 0x020032B9 RID: 12985
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dapao1_node9 : Action
	{
		// Token: 0x06014DE6 RID: 85478 RVA: 0x00649554 File Offset: 0x00647954
		public Action_bt_Monster_AI_GHFB_dapao1_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "2222";
			this.method_p1 = 1f;
			this.method_p2 = 0;
		}

		// Token: 0x06014DE7 RID: 85479 RVA: 0x00649580 File Offset: 0x00647980
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6D2 RID: 59090
		private string method_p0;

		// Token: 0x0400E6D3 RID: 59091
		private float method_p1;

		// Token: 0x0400E6D4 RID: 59092
		private int method_p2;
	}
}
