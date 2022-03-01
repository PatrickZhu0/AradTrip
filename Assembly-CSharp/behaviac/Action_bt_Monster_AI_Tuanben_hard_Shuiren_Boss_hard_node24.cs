using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D8E RID: 15758
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node24 : Action
	{
		// Token: 0x060162B1 RID: 90801 RVA: 0x006B337C File Offset: 0x006B177C
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = -7400;
			this.method_p1.Add(item);
			int item2 = -4000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x060162B2 RID: 90802 RVA: 0x006B33FD File Offset: 0x006B17FD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB03 RID: 64259
		private int method_p0;

		// Token: 0x0400FB04 RID: 64260
		private List<int> method_p1;

		// Token: 0x0400FB05 RID: 64261
		private bool method_p2;

		// Token: 0x0400FB06 RID: 64262
		private int method_p3;
	}
}
