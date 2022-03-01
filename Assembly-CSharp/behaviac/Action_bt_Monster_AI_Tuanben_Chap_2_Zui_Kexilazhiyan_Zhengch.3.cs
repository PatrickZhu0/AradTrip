using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020037E5 RID: 14309
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_Hard_node2 : Action
	{
		// Token: 0x060157C2 RID: 88002 RVA: 0x0067C1F4 File Offset: 0x0067A5F4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_Hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81860011;
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

		// Token: 0x060157C3 RID: 88003 RVA: 0x0067C269 File Offset: 0x0067A669
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F18D RID: 61837
		private int method_p0;

		// Token: 0x0400F18E RID: 61838
		private List<int> method_p1;

		// Token: 0x0400F18F RID: 61839
		private bool method_p2;

		// Token: 0x0400F190 RID: 61840
		private int method_p3;
	}
}
