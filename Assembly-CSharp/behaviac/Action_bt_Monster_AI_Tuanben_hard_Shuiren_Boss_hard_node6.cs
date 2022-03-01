using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D72 RID: 15730
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node6 : Action
	{
		// Token: 0x06016279 RID: 90745 RVA: 0x006B29A4 File Offset: 0x006B0DA4
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 7000;
			this.method_p1.Add(item);
			int item2 = 5000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x0601627A RID: 90746 RVA: 0x006B2A25 File Offset: 0x006B0E25
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAD2 RID: 64210
		private int method_p0;

		// Token: 0x0400FAD3 RID: 64211
		private List<int> method_p1;

		// Token: 0x0400FAD4 RID: 64212
		private bool method_p2;

		// Token: 0x0400FAD5 RID: 64213
		private int method_p3;
	}
}
