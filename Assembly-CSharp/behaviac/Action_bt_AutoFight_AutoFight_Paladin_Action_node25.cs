using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027A2 RID: 10146
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node25 : Action
	{
		// Token: 0x06013884 RID: 80004 RVA: 0x005D2B84 File Offset: 0x005D0F84
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node25()
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
			item.skillID = 3506;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013885 RID: 80005 RVA: 0x005D2C14 File Offset: 0x005D1014
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2E3 RID: 53987
		private List<Input> method_p0;

		// Token: 0x0400D2E4 RID: 53988
		private bool method_p1;
	}
}
