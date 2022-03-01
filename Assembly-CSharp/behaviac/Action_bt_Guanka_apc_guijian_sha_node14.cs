using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A72 RID: 10866
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_guijian_sha_node14 : Action
	{
		// Token: 0x06013E0B RID: 81419 RVA: 0x005F5710 File Offset: 0x005F3B10
		public Action_bt_Guanka_apc_guijian_sha_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 5;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1503;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 600;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1500;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 450;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 1501;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			Input item4 = default(Input);
			item4.delay = 400;
			item4.moveInSkillState = false;
			item4.moveKeepDistance = 0;
			item4.PKRobotComboCheck = false;
			item4.pressTime = 0;
			item4.randomChangeDirection = false;
			item4.skillID = 1502;
			item4.specialChoice = 0;
			this.method_p0.Add(item4);
			Input item5 = default(Input);
			item5.delay = 600;
			item5.moveInSkillState = false;
			item5.moveKeepDistance = 0;
			item5.PKRobotComboCheck = false;
			item5.pressTime = 0;
			item5.randomChangeDirection = false;
			item5.skillID = 1509;
			item5.specialChoice = 0;
			this.method_p0.Add(item5);
			this.method_p1 = false;
		}

		// Token: 0x06013E0C RID: 81420 RVA: 0x005F5911 File Offset: 0x005F3D11
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D87E RID: 55422
		private List<Input> method_p0;

		// Token: 0x0400D87F RID: 55423
		private bool method_p1;
	}
}
