using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200241E RID: 9246
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node28 : Action
	{
		// Token: 0x06013196 RID: 78230 RVA: 0x005A9EE4 File Offset: 0x005A82E4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1604;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1200;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1606;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013197 RID: 78231 RVA: 0x005A9FD0 File Offset: 0x005A83D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBBF RID: 52159
		private List<Input> method_p0;

		// Token: 0x0400CBC0 RID: 52160
		private bool method_p1;
	}
}
