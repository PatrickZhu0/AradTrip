using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002900 RID: 10496
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node21 : Action
	{
		// Token: 0x06013B37 RID: 80695 RVA: 0x005E2B60 File Offset: 0x005E0F60
		public Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node21()
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
			item.skillID = 4006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B38 RID: 80696 RVA: 0x005E2BF0 File Offset: 0x005E0FF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D599 RID: 54681
		private List<Input> method_p0;

		// Token: 0x0400D59A RID: 54682
		private bool method_p1;
	}
}
