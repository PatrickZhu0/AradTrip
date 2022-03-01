using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032C0 RID: 12992
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dapao2_node1 : Action
	{
		// Token: 0x06014DF3 RID: 85491 RVA: 0x00649A48 File Offset: 0x00647E48
		public Action_bt_Monster_AI_GHFB_dapao2_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<int>();
			this.method_p0.Capacity = 1;
			int item = 70190011;
			this.method_p0.Add(item);
		}

		// Token: 0x06014DF4 RID: 85492 RVA: 0x00649A8B File Offset: 0x00647E8B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AttackTargetByID(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6E2 RID: 59106
		private List<int> method_p0;
	}
}
