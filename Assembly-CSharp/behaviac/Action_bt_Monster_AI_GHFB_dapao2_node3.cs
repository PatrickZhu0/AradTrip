using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032C4 RID: 12996
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dapao2_node3 : Action
	{
		// Token: 0x06014DFB RID: 85499 RVA: 0x00649BB8 File Offset: 0x00647FB8
		public Action_bt_Monster_AI_GHFB_dapao2_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<int>();
			this.method_p0.Capacity = 1;
			int item = 70220011;
			this.method_p0.Add(item);
		}

		// Token: 0x06014DFC RID: 85500 RVA: 0x00649BFB File Offset: 0x00647FFB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AttackTargetByID(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6E9 RID: 59113
		private List<int> method_p0;
	}
}
