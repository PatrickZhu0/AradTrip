using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003608 RID: 13832
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8 : Action
	{
		// Token: 0x06015436 RID: 87094 RVA: 0x00668AE8 File Offset: 0x00666EE8
		public Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2500;
			this.method_p1 = 1200;
			this.method_p2 = 2000;
			this.method_p3 = 2000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 2;
			int item = 2050011;
			this.method_p4.Add(item);
			int item2 = 2060011;
			this.method_p4.Add(item2);
		}

		// Token: 0x06015437 RID: 87095 RVA: 0x00668B69 File Offset: 0x00666F69
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDEE RID: 60910
		private int method_p0;

		// Token: 0x0400EDEF RID: 60911
		private int method_p1;

		// Token: 0x0400EDF0 RID: 60912
		private int method_p2;

		// Token: 0x0400EDF1 RID: 60913
		private int method_p3;

		// Token: 0x0400EDF2 RID: 60914
		private List<int> method_p4;
	}
}
