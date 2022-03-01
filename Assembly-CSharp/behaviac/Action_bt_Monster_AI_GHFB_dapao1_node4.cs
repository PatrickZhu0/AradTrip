using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032B6 RID: 12982
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dapao1_node4 : Action
	{
		// Token: 0x06014DE0 RID: 85472 RVA: 0x0064943C File Offset: 0x0064783C
		public Action_bt_Monster_AI_GHFB_dapao1_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 100000;
			this.method_p1 = 100000;
			this.method_p2 = 100000;
			this.method_p3 = 100000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 1;
			int item = 70180011;
			this.method_p4.Add(item);
			this.method_p5 = false;
		}

		// Token: 0x06014DE1 RID: 85473 RVA: 0x006494B2 File Offset: 0x006478B2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInAreaByCamp(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4, this.method_p5);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6CC RID: 59084
		private int method_p0;

		// Token: 0x0400E6CD RID: 59085
		private int method_p1;

		// Token: 0x0400E6CE RID: 59086
		private int method_p2;

		// Token: 0x0400E6CF RID: 59087
		private int method_p3;

		// Token: 0x0400E6D0 RID: 59088
		private List<int> method_p4;

		// Token: 0x0400E6D1 RID: 59089
		private bool method_p5;
	}
}
