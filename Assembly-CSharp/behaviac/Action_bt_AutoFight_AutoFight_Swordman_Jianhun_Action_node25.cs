using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002909 RID: 10505
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node25 : Action
	{
		// Token: 0x06013B48 RID: 80712 RVA: 0x005E3A88 File Offset: 0x005E1E88
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node25()
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

		// Token: 0x06013B49 RID: 80713 RVA: 0x005E3B18 File Offset: 0x005E1F18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5AB RID: 54699
		private List<Input> method_p0;

		// Token: 0x0400D5AC RID: 54700
		private bool method_p1;
	}
}
