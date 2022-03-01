using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032A8 RID: 12968
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dalishi1_node1 : Action
	{
		// Token: 0x06014DC6 RID: 85446 RVA: 0x00648AB4 File Offset: 0x00646EB4
		public Action_bt_Monster_AI_GHFB_dalishi1_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<int>();
			this.method_p0.Capacity = 1;
			int item = 70180011;
			this.method_p0.Add(item);
		}

		// Token: 0x06014DC7 RID: 85447 RVA: 0x00648AF7 File Offset: 0x00646EF7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AttackTargetByID(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6B6 RID: 59062
		private List<int> method_p0;
	}
}
