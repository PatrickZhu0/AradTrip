using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032BC RID: 12988
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dapao1_node3 : Action
	{
		// Token: 0x06014DEC RID: 85484 RVA: 0x00649680 File Offset: 0x00647A80
		public Action_bt_Monster_AI_GHFB_dapao1_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<int>();
			this.method_p0.Capacity = 1;
			int item = 70220011;
			this.method_p0.Add(item);
		}

		// Token: 0x06014DED RID: 85485 RVA: 0x006496C3 File Offset: 0x00647AC3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AttackTargetByID(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6DB RID: 59099
		private List<int> method_p0;
	}
}
