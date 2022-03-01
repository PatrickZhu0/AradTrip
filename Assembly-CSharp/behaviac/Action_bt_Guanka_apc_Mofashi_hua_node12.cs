using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A89 RID: 10889
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_hua_node12 : Action
	{
		// Token: 0x06013E36 RID: 81462 RVA: 0x005F6BA0 File Offset: 0x005F4FA0
		public Action_bt_Guanka_apc_Mofashi_hua_node12()
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

		// Token: 0x06013E37 RID: 81463 RVA: 0x005F6C30 File Offset: 0x005F5030
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8AA RID: 55466
		private List<Input> method_p0;

		// Token: 0x0400D8AB RID: 55467
		private bool method_p1;
	}
}
