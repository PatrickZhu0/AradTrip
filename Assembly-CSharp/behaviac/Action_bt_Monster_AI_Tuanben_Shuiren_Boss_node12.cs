using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B22 RID: 15138
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node12 : Action
	{
		// Token: 0x06015DFC RID: 89596 RVA: 0x0069BF64 File Offset: 0x0069A364
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80170011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 6000;
			this.method_p1.Add(item);
			int item2 = 3000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x06015DFD RID: 89597 RVA: 0x0069BFE5 File Offset: 0x0069A3E5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6E1 RID: 63201
		private int method_p0;

		// Token: 0x0400F6E2 RID: 63202
		private List<int> method_p1;

		// Token: 0x0400F6E3 RID: 63203
		private bool method_p2;

		// Token: 0x0400F6E4 RID: 63204
		private int method_p3;
	}
}
