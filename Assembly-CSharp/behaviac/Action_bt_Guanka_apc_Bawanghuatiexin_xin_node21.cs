using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A1E RID: 10782
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Bawanghuatiexin_xin_node21 : Action
	{
		// Token: 0x06013D6B RID: 81259 RVA: 0x005F0C00 File Offset: 0x005EF000
		public Action_bt_Guanka_apc_Bawanghuatiexin_xin_node21()
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

		// Token: 0x06013D6C RID: 81260 RVA: 0x005F0C90 File Offset: 0x005EF090
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7D8 RID: 55256
		private List<Input> method_p0;

		// Token: 0x0400D7D9 RID: 55257
		private bool method_p1;
	}
}
