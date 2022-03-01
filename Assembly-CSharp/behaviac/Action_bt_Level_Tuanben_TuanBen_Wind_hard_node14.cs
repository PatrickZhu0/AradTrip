using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B20 RID: 11040
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node14 : Action
	{
		// Token: 0x06013F52 RID: 81746 RVA: 0x005FD7F8 File Offset: 0x005FBBF8
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81570011;
			this.method_p1 = new List<float>();
			this.method_p1.Capacity = 3;
			float item = 8.9f;
			this.method_p1.Add(item);
			float item2 = 11.9f;
			this.method_p1.Add(item2);
			float item3 = 0f;
			this.method_p1.Add(item3);
			this.method_p2 = 60;
		}

		// Token: 0x06013F53 RID: 81747 RVA: 0x005FD872 File Offset: 0x005FBC72
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SummonMonster(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D98D RID: 55693
		private int method_p0;

		// Token: 0x0400D98E RID: 55694
		private List<float> method_p1;

		// Token: 0x0400D98F RID: 55695
		private int method_p2;
	}
}
