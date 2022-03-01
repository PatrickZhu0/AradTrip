using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D82 RID: 15746
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node18 : Action
	{
		// Token: 0x06016299 RID: 90777 RVA: 0x006B2F44 File Offset: 0x006B1344
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
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

		// Token: 0x0601629A RID: 90778 RVA: 0x006B2FC5 File Offset: 0x006B13C5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAEE RID: 64238
		private int method_p0;

		// Token: 0x0400FAEF RID: 64239
		private List<int> method_p1;

		// Token: 0x0400FAF0 RID: 64240
		private bool method_p2;

		// Token: 0x0400FAF1 RID: 64241
		private int method_p3;
	}
}
