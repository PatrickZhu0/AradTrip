using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200278E RID: 10126
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node10 : Action
	{
		// Token: 0x0601385C RID: 79964 RVA: 0x005D2300 File Offset: 0x005D0700
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node10()
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
			item.skillID = 3505;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601385D RID: 79965 RVA: 0x005D2390 File Offset: 0x005D0790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2BB RID: 53947
		private List<Input> method_p0;

		// Token: 0x0400D2BC RID: 53948
		private bool method_p1;
	}
}
