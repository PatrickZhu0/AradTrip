using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002862 RID: 10338
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node99 : Action
	{
		// Token: 0x06013A02 RID: 80386 RVA: 0x005DA630 File Offset: 0x005D8A30
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node99()
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

		// Token: 0x06013A03 RID: 80387 RVA: 0x005DA6C0 File Offset: 0x005D8AC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D45A RID: 54362
		private List<Input> method_p0;

		// Token: 0x0400D45B RID: 54363
		private bool method_p1;
	}
}
