using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B3A RID: 15162
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node3 : Action
	{
		// Token: 0x06015E2C RID: 89644 RVA: 0x0069C7D4 File Offset: 0x0069ABD4
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80170011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 8000;
			this.method_p1.Add(item);
			int item2 = -3000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x06015E2D RID: 89645 RVA: 0x0069C855 File Offset: 0x0069AC55
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F70B RID: 63243
		private int method_p0;

		// Token: 0x0400F70C RID: 63244
		private List<int> method_p1;

		// Token: 0x0400F70D RID: 63245
		private bool method_p2;

		// Token: 0x0400F70E RID: 63246
		private int method_p3;
	}
}
