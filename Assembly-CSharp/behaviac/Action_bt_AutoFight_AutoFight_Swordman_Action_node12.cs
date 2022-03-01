using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002883 RID: 10371
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Action_node12 : Action
	{
		// Token: 0x06013A43 RID: 80451 RVA: 0x005DCF70 File Offset: 0x005DB370
		public Action_bt_AutoFight_AutoFight_Swordman_Action_node12()
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
			item.skillID = 1521;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013A44 RID: 80452 RVA: 0x005DD000 File Offset: 0x005DB400
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D49C RID: 54428
		private List<Input> method_p0;

		// Token: 0x0400D49D RID: 54429
		private bool method_p1;
	}
}
