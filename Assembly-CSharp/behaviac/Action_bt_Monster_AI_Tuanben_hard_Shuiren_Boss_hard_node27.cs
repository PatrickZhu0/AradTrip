using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D8A RID: 15754
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node27 : Action
	{
		// Token: 0x060162A9 RID: 90793 RVA: 0x006B3214 File Offset: 0x006B1614
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
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

		// Token: 0x060162AA RID: 90794 RVA: 0x006B3295 File Offset: 0x006B1695
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAFC RID: 64252
		private int method_p0;

		// Token: 0x0400FAFD RID: 64253
		private List<int> method_p1;

		// Token: 0x0400FAFE RID: 64254
		private bool method_p2;

		// Token: 0x0400FAFF RID: 64255
		private int method_p3;
	}
}
