using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A7F RID: 10879
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Huofenghuangjingyue_node12 : Action
	{
		// Token: 0x06013E24 RID: 81444 RVA: 0x005F641C File Offset: 0x005F481C
		public Action_bt_Guanka_apc_Huofenghuangjingyue_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 3;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2513;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1000;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 2509;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 2500;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 2512;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			this.method_p1 = false;
		}

		// Token: 0x06013E25 RID: 81445 RVA: 0x005F6564 File Offset: 0x005F4964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D898 RID: 55448
		private List<Input> method_p0;

		// Token: 0x0400D899 RID: 55449
		private bool method_p1;
	}
}
