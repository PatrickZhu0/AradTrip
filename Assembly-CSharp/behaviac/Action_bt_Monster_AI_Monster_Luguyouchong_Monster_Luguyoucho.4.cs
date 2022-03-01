using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036CD RID: 14029
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node26 : Action
	{
		// Token: 0x060155B1 RID: 87473 RVA: 0x0067162C File Offset: 0x0066FA2C
		public Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3000;
			this.method_p1 = 3000;
			this.method_p2 = 3000;
			this.method_p3 = 3000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 1;
			int item = 2050011;
			this.method_p4.Add(item);
		}

		// Token: 0x060155B2 RID: 87474 RVA: 0x0067169B File Offset: 0x0066FA9B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF82 RID: 61314
		private int method_p0;

		// Token: 0x0400EF83 RID: 61315
		private int method_p1;

		// Token: 0x0400EF84 RID: 61316
		private int method_p2;

		// Token: 0x0400EF85 RID: 61317
		private int method_p3;

		// Token: 0x0400EF86 RID: 61318
		private List<int> method_p4;
	}
}
