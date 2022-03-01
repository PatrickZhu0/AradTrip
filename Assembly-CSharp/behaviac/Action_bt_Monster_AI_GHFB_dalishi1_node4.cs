using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032A6 RID: 12966
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dalishi1_node4 : Action
	{
		// Token: 0x06014DC2 RID: 85442 RVA: 0x006489D4 File Offset: 0x00646DD4
		public Action_bt_Monster_AI_GHFB_dalishi1_node4()
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

		// Token: 0x06014DC3 RID: 85443 RVA: 0x00648A4A File Offset: 0x00646E4A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInAreaByCamp(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4, this.method_p5);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6B0 RID: 59056
		private int method_p0;

		// Token: 0x0400E6B1 RID: 59057
		private int method_p1;

		// Token: 0x0400E6B2 RID: 59058
		private int method_p2;

		// Token: 0x0400E6B3 RID: 59059
		private int method_p3;

		// Token: 0x0400E6B4 RID: 59060
		private List<int> method_p4;

		// Token: 0x0400E6B5 RID: 59061
		private bool method_p5;
	}
}
