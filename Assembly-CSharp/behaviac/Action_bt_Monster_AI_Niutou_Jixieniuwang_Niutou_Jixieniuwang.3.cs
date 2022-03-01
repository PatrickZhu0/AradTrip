using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003700 RID: 14080
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node14 : Action
	{
		// Token: 0x0601560F RID: 87567 RVA: 0x006731B4 File Offset: 0x006715B4
		public Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 90000;
			this.method_p1 = 90000;
			this.method_p2 = 90000;
			this.method_p3 = 90000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 1;
			int item = 2010011;
			this.method_p4.Add(item);
		}

		// Token: 0x06015610 RID: 87568 RVA: 0x00673223 File Offset: 0x00671623
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFD6 RID: 61398
		private int method_p0;

		// Token: 0x0400EFD7 RID: 61399
		private int method_p1;

		// Token: 0x0400EFD8 RID: 61400
		private int method_p2;

		// Token: 0x0400EFD9 RID: 61401
		private int method_p3;

		// Token: 0x0400EFDA RID: 61402
		private List<int> method_p4;
	}
}
