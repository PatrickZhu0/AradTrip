using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032BE RID: 12990
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dapao2_node4 : Action
	{
		// Token: 0x06014DEF RID: 85487 RVA: 0x00649968 File Offset: 0x00647D68
		public Action_bt_Monster_AI_GHFB_dapao2_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 100000;
			this.method_p1 = 100000;
			this.method_p2 = 100000;
			this.method_p3 = 100000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 1;
			int item = 70190011;
			this.method_p4.Add(item);
			this.method_p5 = false;
		}

		// Token: 0x06014DF0 RID: 85488 RVA: 0x006499DE File Offset: 0x00647DDE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInAreaByCamp(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4, this.method_p5);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6DC RID: 59100
		private int method_p0;

		// Token: 0x0400E6DD RID: 59101
		private int method_p1;

		// Token: 0x0400E6DE RID: 59102
		private int method_p2;

		// Token: 0x0400E6DF RID: 59103
		private int method_p3;

		// Token: 0x0400E6E0 RID: 59104
		private List<int> method_p4;

		// Token: 0x0400E6E1 RID: 59105
		private bool method_p5;
	}
}
