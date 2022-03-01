using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D86 RID: 15750
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node21 : Action
	{
		// Token: 0x060162A1 RID: 90785 RVA: 0x006B30AC File Offset: 0x006B14AC
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = -7300;
			this.method_p1.Add(item);
			int item2 = 2000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x060162A2 RID: 90786 RVA: 0x006B312D File Offset: 0x006B152D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAF5 RID: 64245
		private int method_p0;

		// Token: 0x0400FAF6 RID: 64246
		private List<int> method_p1;

		// Token: 0x0400FAF7 RID: 64247
		private bool method_p2;

		// Token: 0x0400FAF8 RID: 64248
		private int method_p3;
	}
}
