using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020037DD RID: 14301
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_Hard_node2 : Action
	{
		// Token: 0x060157B4 RID: 87988 RVA: 0x0067BD8C File Offset: 0x0067A18C
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_Hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81850011;
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

		// Token: 0x060157B5 RID: 87989 RVA: 0x0067BE01 File Offset: 0x0067A201
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F17B RID: 61819
		private int method_p0;

		// Token: 0x0400F17C RID: 61820
		private List<int> method_p1;

		// Token: 0x0400F17D RID: 61821
		private bool method_p2;

		// Token: 0x0400F17E RID: 61822
		private int method_p3;
	}
}
