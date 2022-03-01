using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020037E1 RID: 14305
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2 : Action
	{
		// Token: 0x060157BB RID: 87995 RVA: 0x0067BFC0 File Offset: 0x0067A3C0
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81040011;
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

		// Token: 0x060157BC RID: 87996 RVA: 0x0067C035 File Offset: 0x0067A435
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F184 RID: 61828
		private int method_p0;

		// Token: 0x0400F185 RID: 61829
		private List<int> method_p1;

		// Token: 0x0400F186 RID: 61830
		private bool method_p2;

		// Token: 0x0400F187 RID: 61831
		private int method_p3;
	}
}
