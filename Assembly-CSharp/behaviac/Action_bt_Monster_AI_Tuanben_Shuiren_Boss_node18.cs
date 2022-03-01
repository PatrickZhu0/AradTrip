using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B2A RID: 15146
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node18 : Action
	{
		// Token: 0x06015E0C RID: 89612 RVA: 0x0069C234 File Offset: 0x0069A634
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80170011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 5000;
			this.method_p1.Add(item);
			int item2 = 2000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x06015E0D RID: 89613 RVA: 0x0069C2B5 File Offset: 0x0069A6B5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6EF RID: 63215
		private int method_p0;

		// Token: 0x0400F6F0 RID: 63216
		private List<int> method_p1;

		// Token: 0x0400F6F1 RID: 63217
		private bool method_p2;

		// Token: 0x0400F6F2 RID: 63218
		private int method_p3;
	}
}
