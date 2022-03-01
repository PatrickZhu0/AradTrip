using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B05 RID: 11013
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node16 : Action
	{
		// Token: 0x06013F1E RID: 81694 RVA: 0x005FC680 File Offset: 0x005FAA80
		public Action_bt_Level_Tuanben_TuanBen_Wind_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80480011;
			this.method_p1 = new List<float>();
			this.method_p1.Capacity = 3;
			float item = 10.6f;
			this.method_p1.Add(item);
			float item2 = 3.9f;
			this.method_p1.Add(item2);
			float item3 = 0f;
			this.method_p1.Add(item3);
			this.method_p2 = 60;
		}

		// Token: 0x06013F1F RID: 81695 RVA: 0x005FC6FA File Offset: 0x005FAAFA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SummonMonster(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D969 RID: 55657
		private int method_p0;

		// Token: 0x0400D96A RID: 55658
		private List<float> method_p1;

		// Token: 0x0400D96B RID: 55659
		private int method_p2;
	}
}
