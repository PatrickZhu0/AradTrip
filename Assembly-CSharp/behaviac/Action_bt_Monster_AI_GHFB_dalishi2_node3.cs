using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032B4 RID: 12980
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dalishi2_node3 : Action
	{
		// Token: 0x06014DDD RID: 85469 RVA: 0x00649158 File Offset: 0x00647558
		public Action_bt_Monster_AI_GHFB_dalishi2_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<int>();
			this.method_p0.Capacity = 1;
			int item = 70220011;
			this.method_p0.Add(item);
		}

		// Token: 0x06014DDE RID: 85470 RVA: 0x0064919B File Offset: 0x0064759B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AttackTargetByID(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6CB RID: 59083
		private List<int> method_p0;
	}
}
