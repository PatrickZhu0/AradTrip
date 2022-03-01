using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B32 RID: 15154
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node27 : Action
	{
		// Token: 0x06015E1C RID: 89628 RVA: 0x0069C504 File Offset: 0x0069A904
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80170011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 8000;
			this.method_p1.Add(item);
			int item2 = 2500;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x06015E1D RID: 89629 RVA: 0x0069C585 File Offset: 0x0069A985
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6FD RID: 63229
		private int method_p0;

		// Token: 0x0400F6FE RID: 63230
		private List<int> method_p1;

		// Token: 0x0400F6FF RID: 63231
		private bool method_p2;

		// Token: 0x0400F700 RID: 63232
		private int method_p3;
	}
}
