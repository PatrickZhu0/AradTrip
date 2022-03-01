using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002873 RID: 10355
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Action_node23 : Action
	{
		// Token: 0x06013A23 RID: 80419 RVA: 0x005DC848 File Offset: 0x005DAC48
		public Action_bt_AutoFight_AutoFight_Swordman_Action_node23()
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
			item.skillID = 1604;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013A24 RID: 80420 RVA: 0x005DC8D8 File Offset: 0x005DACD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D47C RID: 54396
		private List<Input> method_p0;

		// Token: 0x0400D47D RID: 54397
		private bool method_p1;
	}
}
