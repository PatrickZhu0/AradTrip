using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D7A RID: 15738
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node12 : Action
	{
		// Token: 0x06016289 RID: 90761 RVA: 0x006B2C74 File Offset: 0x006B1074
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 6000;
			this.method_p1.Add(item);
			int item2 = 3000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x0601628A RID: 90762 RVA: 0x006B2CF5 File Offset: 0x006B10F5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAE0 RID: 64224
		private int method_p0;

		// Token: 0x0400FAE1 RID: 64225
		private List<int> method_p1;

		// Token: 0x0400FAE2 RID: 64226
		private bool method_p2;

		// Token: 0x0400FAE3 RID: 64227
		private int method_p3;
	}
}
