using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002877 RID: 10359
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Action_node49 : Action
	{
		// Token: 0x06013A2B RID: 80427 RVA: 0x005DC9FC File Offset: 0x005DADFC
		public Action_bt_AutoFight_AutoFight_Swordman_Action_node49()
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
			item.skillID = 1911;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 910;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1911;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013A2C RID: 80428 RVA: 0x005DCAE8 File Offset: 0x005DAEE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D484 RID: 54404
		private List<Input> method_p0;

		// Token: 0x0400D485 RID: 54405
		private bool method_p1;
	}
}
