using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002246 RID: 8774
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8 : Action
	{
		// Token: 0x06012E14 RID: 77332 RVA: 0x005909D4 File Offset: 0x0058EDD4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8()
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
			item.skillID = 1710;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012E15 RID: 77333 RVA: 0x00590A64 File Offset: 0x0058EE64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C812 RID: 51218
		private List<Input> method_p0;

		// Token: 0x0400C813 RID: 51219
		private bool method_p1;
	}
}
