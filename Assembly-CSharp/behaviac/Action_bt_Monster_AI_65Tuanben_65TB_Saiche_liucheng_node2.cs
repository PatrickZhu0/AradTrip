using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BCB RID: 11211
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2 : Action
	{
		// Token: 0x06014097 RID: 82071 RVA: 0x00604AB4 File Offset: 0x00602EB4
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81980011;
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

		// Token: 0x06014098 RID: 82072 RVA: 0x00604B31 File Offset: 0x00602F31
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA88 RID: 55944
		private int method_p0;

		// Token: 0x0400DA89 RID: 55945
		private List<int> method_p1;

		// Token: 0x0400DA8A RID: 55946
		private bool method_p2;

		// Token: 0x0400DA8B RID: 55947
		private int method_p3;
	}
}
