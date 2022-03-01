using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B36 RID: 15158
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node24 : Action
	{
		// Token: 0x06015E24 RID: 89636 RVA: 0x0069C66C File Offset: 0x0069AA6C
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80170011;
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

		// Token: 0x06015E25 RID: 89637 RVA: 0x0069C6ED File Offset: 0x0069AAED
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F704 RID: 63236
		private int method_p0;

		// Token: 0x0400F705 RID: 63237
		private List<int> method_p1;

		// Token: 0x0400F706 RID: 63238
		private bool method_p2;

		// Token: 0x0400F707 RID: 63239
		private int method_p3;
	}
}
