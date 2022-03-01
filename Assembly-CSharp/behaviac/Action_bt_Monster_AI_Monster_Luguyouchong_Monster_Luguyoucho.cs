using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036C4 RID: 14020
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node26 : Action
	{
		// Token: 0x060155A0 RID: 87456 RVA: 0x00671014 File Offset: 0x0066F414
		public Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3000;
			this.method_p1 = 1000;
			this.method_p2 = 1000;
			this.method_p3 = 1000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 1;
			int item = 2050011;
			this.method_p4.Add(item);
		}

		// Token: 0x060155A1 RID: 87457 RVA: 0x00671083 File Offset: 0x0066F483
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF71 RID: 61297
		private int method_p0;

		// Token: 0x0400EF72 RID: 61298
		private int method_p1;

		// Token: 0x0400EF73 RID: 61299
		private int method_p2;

		// Token: 0x0400EF74 RID: 61300
		private int method_p3;

		// Token: 0x0400EF75 RID: 61301
		private List<int> method_p4;
	}
}
