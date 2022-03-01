using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032C2 RID: 12994
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dapao2_node5 : Action
	{
		// Token: 0x06014DF7 RID: 85495 RVA: 0x00649AD8 File Offset: 0x00647ED8
		public Action_bt_Monster_AI_GHFB_dapao2_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 100000;
			this.method_p1 = 100000;
			this.method_p2 = 100000;
			this.method_p3 = 100000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 1;
			int item = 70220011;
			this.method_p4.Add(item);
			this.method_p5 = false;
		}

		// Token: 0x06014DF8 RID: 85496 RVA: 0x00649B4E File Offset: 0x00647F4E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInAreaByCamp(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4, this.method_p5);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6E3 RID: 59107
		private int method_p0;

		// Token: 0x0400E6E4 RID: 59108
		private int method_p1;

		// Token: 0x0400E6E5 RID: 59109
		private int method_p2;

		// Token: 0x0400E6E6 RID: 59110
		private int method_p3;

		// Token: 0x0400E6E7 RID: 59111
		private List<int> method_p4;

		// Token: 0x0400E6E8 RID: 59112
		private bool method_p5;
	}
}
