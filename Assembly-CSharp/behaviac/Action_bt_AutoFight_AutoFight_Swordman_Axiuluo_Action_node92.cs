using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200289E RID: 10398
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node92 : Action
	{
		// Token: 0x06013A76 RID: 80502 RVA: 0x005DE8C4 File Offset: 0x005DCCC4
		public Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node92()
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
			item.skillID = 1709;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013A77 RID: 80503 RVA: 0x005DE954 File Offset: 0x005DCD54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4D0 RID: 54480
		private List<Input> method_p0;

		// Token: 0x0400D4D1 RID: 54481
		private bool method_p1;
	}
}
