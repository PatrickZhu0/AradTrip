using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003723 RID: 14115
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node1 : Action
	{
		// Token: 0x06015652 RID: 87634 RVA: 0x0067496C File Offset: 0x00672D6C
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 90000;
			this.method_p1 = 90000;
			this.method_p2 = 90000;
			this.method_p3 = 90000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 1;
			int item = 1950011;
			this.method_p4.Add(item);
		}

		// Token: 0x06015653 RID: 87635 RVA: 0x006749DB File Offset: 0x00672DDB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F021 RID: 61473
		private int method_p0;

		// Token: 0x0400F022 RID: 61474
		private int method_p1;

		// Token: 0x0400F023 RID: 61475
		private int method_p2;

		// Token: 0x0400F024 RID: 61476
		private int method_p3;

		// Token: 0x0400F025 RID: 61477
		private List<int> method_p4;
	}
}
