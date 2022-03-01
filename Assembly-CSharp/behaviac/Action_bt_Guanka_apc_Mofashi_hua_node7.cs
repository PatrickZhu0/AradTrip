using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A85 RID: 10885
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_hua_node7 : Action
	{
		// Token: 0x06013E2E RID: 81454 RVA: 0x005F69EC File Offset: 0x005F4DEC
		public Action_bt_Guanka_apc_Mofashi_hua_node7()
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
			item.skillID = 2011;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013E2F RID: 81455 RVA: 0x005F6A7C File Offset: 0x005F4E7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8A2 RID: 55458
		private List<Input> method_p0;

		// Token: 0x0400D8A3 RID: 55459
		private bool method_p1;
	}
}
