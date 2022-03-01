using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A15 RID: 10773
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Bawanghuatiexin_node21 : Action
	{
		// Token: 0x06013D5A RID: 81242 RVA: 0x005F0258 File Offset: 0x005EE658
		public Action_bt_Guanka_apc_Bawanghuatiexin_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013D5B RID: 81243 RVA: 0x005F02E8 File Offset: 0x005EE6E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7C6 RID: 55238
		private List<Input> method_p0;

		// Token: 0x0400D7C7 RID: 55239
		private bool method_p1;
	}
}
