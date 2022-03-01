using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032B0 RID: 12976
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dalishi2_node1 : Action
	{
		// Token: 0x06014DD5 RID: 85461 RVA: 0x00648FE8 File Offset: 0x006473E8
		public Action_bt_Monster_AI_GHFB_dalishi2_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<int>();
			this.method_p0.Capacity = 1;
			int item = 70190011;
			this.method_p0.Add(item);
		}

		// Token: 0x06014DD6 RID: 85462 RVA: 0x0064902B File Offset: 0x0064742B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AttackTargetByID(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6C4 RID: 59076
		private List<int> method_p0;
	}
}
