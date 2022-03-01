using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032AC RID: 12972
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dalishi1_node3 : Action
	{
		// Token: 0x06014DCE RID: 85454 RVA: 0x00648C24 File Offset: 0x00647024
		public Action_bt_Monster_AI_GHFB_dalishi1_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<int>();
			this.method_p0.Capacity = 1;
			int item = 70220011;
			this.method_p0.Add(item);
		}

		// Token: 0x06014DCF RID: 85455 RVA: 0x00648C67 File Offset: 0x00647067
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AttackTargetByID(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6BD RID: 59069
		private List<int> method_p0;
	}
}
