using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003192 RID: 12690
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2 : Action
	{
		// Token: 0x06014BBA RID: 84922 RVA: 0x0063E920 File Offset: 0x0063CD20
		public Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 41130011;
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

		// Token: 0x06014BBB RID: 84923 RVA: 0x0063E995 File Offset: 0x0063CD95
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E525 RID: 58661
		private int method_p0;

		// Token: 0x0400E526 RID: 58662
		private List<int> method_p1;

		// Token: 0x0400E527 RID: 58663
		private bool method_p2;

		// Token: 0x0400E528 RID: 58664
		private int method_p3;
	}
}
