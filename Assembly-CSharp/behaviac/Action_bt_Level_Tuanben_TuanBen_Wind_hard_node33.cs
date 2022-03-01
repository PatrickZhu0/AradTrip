using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B29 RID: 11049
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node33 : Action
	{
		// Token: 0x06013F64 RID: 81764 RVA: 0x005FDB88 File Offset: 0x005FBF88
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81480011;
			this.method_p1 = new List<float>();
			this.method_p1.Capacity = 3;
			float item = 4.8f;
			this.method_p1.Add(item);
			float item2 = 2.3f;
			this.method_p1.Add(item2);
			float item3 = 0f;
			this.method_p1.Add(item3);
			this.method_p2 = 60;
		}

		// Token: 0x06013F65 RID: 81765 RVA: 0x005FDC02 File Offset: 0x005FC002
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SummonMonster(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D99F RID: 55711
		private int method_p0;

		// Token: 0x0400D9A0 RID: 55712
		private List<float> method_p1;

		// Token: 0x0400D9A1 RID: 55713
		private int method_p2;
	}
}
