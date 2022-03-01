using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A5E RID: 10846
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_guijian_jue_node12 : Action
	{
		// Token: 0x06013DE6 RID: 81382 RVA: 0x005F45A8 File Offset: 0x005F29A8
		public Action_bt_Guanka_apc_guijian_jue_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1607;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013DE7 RID: 81383 RVA: 0x005F4639 File Offset: 0x005F2A39
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D859 RID: 55385
		private List<Input> method_p0;

		// Token: 0x0400D85A RID: 55386
		private bool method_p1;
	}
}
