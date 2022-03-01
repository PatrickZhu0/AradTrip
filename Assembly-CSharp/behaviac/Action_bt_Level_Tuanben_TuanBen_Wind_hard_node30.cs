using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B26 RID: 11046
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node30 : Action
	{
		// Token: 0x06013F5E RID: 81758 RVA: 0x005FDA58 File Offset: 0x005FBE58
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81470011;
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

		// Token: 0x06013F5F RID: 81759 RVA: 0x005FDAD2 File Offset: 0x005FBED2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_SummonMonster(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D999 RID: 55705
		private int method_p0;

		// Token: 0x0400D99A RID: 55706
		private List<float> method_p1;

		// Token: 0x0400D99B RID: 55707
		private int method_p2;
	}
}
