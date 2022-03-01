using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032BA RID: 12986
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dapao1_node5 : Action
	{
		// Token: 0x06014DE8 RID: 85480 RVA: 0x006495A0 File Offset: 0x006479A0
		public Action_bt_Monster_AI_GHFB_dapao1_node5()
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

		// Token: 0x06014DE9 RID: 85481 RVA: 0x00649616 File Offset: 0x00647A16
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInAreaByCamp(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4, this.method_p5);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6D5 RID: 59093
		private int method_p0;

		// Token: 0x0400E6D6 RID: 59094
		private int method_p1;

		// Token: 0x0400E6D7 RID: 59095
		private int method_p2;

		// Token: 0x0400E6D8 RID: 59096
		private int method_p3;

		// Token: 0x0400E6D9 RID: 59097
		private List<int> method_p4;

		// Token: 0x0400E6DA RID: 59098
		private bool method_p5;
	}
}
