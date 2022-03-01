using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B23 RID: 11043
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node16 : Action
	{
		// Token: 0x06013F58 RID: 81752 RVA: 0x005FD928 File Offset: 0x005FBD28
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81580011;
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

		// Token: 0x06013F59 RID: 81753 RVA: 0x005FD9A2 File Offset: 0x005FBDA2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SummonMonster(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D993 RID: 55699
		private int method_p0;

		// Token: 0x0400D994 RID: 55700
		private List<float> method_p1;

		// Token: 0x0400D995 RID: 55701
		private int method_p2;
	}
}
