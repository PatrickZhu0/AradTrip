using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D76 RID: 15734
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node9 : Action
	{
		// Token: 0x06016281 RID: 90753 RVA: 0x006B2B0C File Offset: 0x006B0F0C
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = -5000;
			this.method_p1.Add(item);
			int item2 = 7000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x06016282 RID: 90754 RVA: 0x006B2B8D File Offset: 0x006B0F8D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAD9 RID: 64217
		private int method_p0;

		// Token: 0x0400FADA RID: 64218
		private List<int> method_p1;

		// Token: 0x0400FADB RID: 64219
		private bool method_p2;

		// Token: 0x0400FADC RID: 64220
		private int method_p3;
	}
}
