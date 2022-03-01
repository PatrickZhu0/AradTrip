using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B02 RID: 11010
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node14 : Action
	{
		// Token: 0x06013F18 RID: 81688 RVA: 0x005FC550 File Offset: 0x005FA950
		public Action_bt_Level_Tuanben_TuanBen_Wind_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80470011;
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

		// Token: 0x06013F19 RID: 81689 RVA: 0x005FC5CA File Offset: 0x005FA9CA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SummonMonster(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D963 RID: 55651
		private int method_p0;

		// Token: 0x0400D964 RID: 55652
		private List<float> method_p1;

		// Token: 0x0400D965 RID: 55653
		private int method_p2;
	}
}
