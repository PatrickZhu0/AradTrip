using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D7E RID: 15742
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node15 : Action
	{
		// Token: 0x06016291 RID: 90769 RVA: 0x006B2DDC File Offset: 0x006B11DC
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = -6000;
			this.method_p1.Add(item);
			int item2 = 3000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x06016292 RID: 90770 RVA: 0x006B2E5D File Offset: 0x006B125D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAE7 RID: 64231
		private int method_p0;

		// Token: 0x0400FAE8 RID: 64232
		private List<int> method_p1;

		// Token: 0x0400FAE9 RID: 64233
		private bool method_p2;

		// Token: 0x0400FAEA RID: 64234
		private int method_p3;
	}
}
