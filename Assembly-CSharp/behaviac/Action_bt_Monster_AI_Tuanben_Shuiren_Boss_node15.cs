using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B26 RID: 15142
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node15 : Action
	{
		// Token: 0x06015E04 RID: 89604 RVA: 0x0069C0CC File Offset: 0x0069A4CC
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80170011;
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

		// Token: 0x06015E05 RID: 89605 RVA: 0x0069C14D File Offset: 0x0069A54D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6E8 RID: 63208
		private int method_p0;

		// Token: 0x0400F6E9 RID: 63209
		private List<int> method_p1;

		// Token: 0x0400F6EA RID: 63210
		private bool method_p2;

		// Token: 0x0400F6EB RID: 63211
		private int method_p3;
	}
}
