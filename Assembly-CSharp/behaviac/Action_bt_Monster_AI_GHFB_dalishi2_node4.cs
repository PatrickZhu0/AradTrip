using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032AE RID: 12974
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dalishi2_node4 : Action
	{
		// Token: 0x06014DD1 RID: 85457 RVA: 0x00648F08 File Offset: 0x00647308
		public Action_bt_Monster_AI_GHFB_dalishi2_node4()
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

		// Token: 0x06014DD2 RID: 85458 RVA: 0x00648F7E File Offset: 0x0064737E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInAreaByCamp(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4, this.method_p5);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6BE RID: 59070
		private int method_p0;

		// Token: 0x0400E6BF RID: 59071
		private int method_p1;

		// Token: 0x0400E6C0 RID: 59072
		private int method_p2;

		// Token: 0x0400E6C1 RID: 59073
		private int method_p3;

		// Token: 0x0400E6C2 RID: 59074
		private List<int> method_p4;

		// Token: 0x0400E6C3 RID: 59075
		private bool method_p5;
	}
}
