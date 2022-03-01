using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032B2 RID: 12978
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dalishi2_node5 : Action
	{
		// Token: 0x06014DD9 RID: 85465 RVA: 0x00649078 File Offset: 0x00647478
		public Action_bt_Monster_AI_GHFB_dalishi2_node5()
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

		// Token: 0x06014DDA RID: 85466 RVA: 0x006490EE File Offset: 0x006474EE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInAreaByCamp(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4, this.method_p5);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6C5 RID: 59077
		private int method_p0;

		// Token: 0x0400E6C6 RID: 59078
		private int method_p1;

		// Token: 0x0400E6C7 RID: 59079
		private int method_p2;

		// Token: 0x0400E6C8 RID: 59080
		private int method_p3;

		// Token: 0x0400E6C9 RID: 59081
		private List<int> method_p4;

		// Token: 0x0400E6CA RID: 59082
		private bool method_p5;
	}
}
