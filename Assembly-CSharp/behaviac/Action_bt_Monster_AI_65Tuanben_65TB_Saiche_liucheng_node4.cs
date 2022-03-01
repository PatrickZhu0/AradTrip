using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BCD RID: 11213
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4 : Action
	{
		// Token: 0x0601409B RID: 82075 RVA: 0x00604BA0 File Offset: 0x00602FA0
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81990011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 2000;
			this.method_p1.Add(item);
			int item2 = -4000;
			this.method_p1.Add(item2);
			int item3 = 0;
			this.method_p1.Add(item3);
			this.method_p2 = false;
			this.method_p3 = 99;
		}

		// Token: 0x0601409C RID: 82076 RVA: 0x00604C1D File Offset: 0x0060301D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA8E RID: 55950
		private int method_p0;

		// Token: 0x0400DA8F RID: 55951
		private List<int> method_p1;

		// Token: 0x0400DA90 RID: 55952
		private bool method_p2;

		// Token: 0x0400DA91 RID: 55953
		private int method_p3;
	}
}
