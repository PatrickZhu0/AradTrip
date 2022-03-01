using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020037D9 RID: 14297
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_node2 : Action
	{
		// Token: 0x060157AD RID: 87981 RVA: 0x0067BB58 File Offset: 0x00679F58
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81010011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 0;
			this.method_p1.Add(item);
			int item2 = 0;
			this.method_p1.Add(item2);
			int item3 = 0;
			this.method_p1.Add(item3);
			this.method_p2 = false;
			this.method_p3 = 60;
		}

		// Token: 0x060157AE RID: 87982 RVA: 0x0067BBCD File Offset: 0x00679FCD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F172 RID: 61810
		private int method_p0;

		// Token: 0x0400F173 RID: 61811
		private List<int> method_p1;

		// Token: 0x0400F174 RID: 61812
		private bool method_p2;

		// Token: 0x0400F175 RID: 61813
		private int method_p3;
	}
}
