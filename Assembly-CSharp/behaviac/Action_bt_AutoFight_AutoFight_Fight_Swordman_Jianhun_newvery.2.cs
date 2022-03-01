using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022B6 RID: 8886
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node28 : Action
	{
		// Token: 0x06012EE7 RID: 77543 RVA: 0x005962E8 File Offset: 0x005946E8
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node28()
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
			item.skillID = 1912;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012EE8 RID: 77544 RVA: 0x00596378 File Offset: 0x00594778
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8F9 RID: 51449
		private List<Input> method_p0;

		// Token: 0x0400C8FA RID: 51450
		private bool method_p1;
	}
}
