using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B08 RID: 11016
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node30 : Action
	{
		// Token: 0x06013F24 RID: 81700 RVA: 0x005FC7B0 File Offset: 0x005FABB0
		public Action_bt_Level_Tuanben_TuanBen_Wind_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80210011;
			this.method_p1 = new List<float>();
			this.method_p1.Capacity = 3;
			float item = 4.2f;
			this.method_p1.Add(item);
			float item2 = 11.4f;
			this.method_p1.Add(item2);
			float item3 = 0f;
			this.method_p1.Add(item3);
			this.method_p2 = 60;
		}

		// Token: 0x06013F25 RID: 81701 RVA: 0x005FC82A File Offset: 0x005FAC2A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SummonMonster(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D96F RID: 55663
		private int method_p0;

		// Token: 0x0400D970 RID: 55664
		private List<float> method_p1;

		// Token: 0x0400D971 RID: 55665
		private int method_p2;
	}
}
