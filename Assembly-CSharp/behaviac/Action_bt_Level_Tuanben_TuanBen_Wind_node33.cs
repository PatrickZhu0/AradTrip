using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B0B RID: 11019
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node33 : Action
	{
		// Token: 0x06013F2A RID: 81706 RVA: 0x005FC8E0 File Offset: 0x005FACE0
		public Action_bt_Level_Tuanben_TuanBen_Wind_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80220011;
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

		// Token: 0x06013F2B RID: 81707 RVA: 0x005FC95A File Offset: 0x005FAD5A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SummonMonster(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D975 RID: 55669
		private int method_p0;

		// Token: 0x0400D976 RID: 55670
		private List<float> method_p1;

		// Token: 0x0400D977 RID: 55671
		private int method_p2;
	}
}
