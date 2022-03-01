using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022AD RID: 8877
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node34 : Action
	{
		// Token: 0x06012ED6 RID: 77526 RVA: 0x005956F8 File Offset: 0x00593AF8
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node34()
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
			item.skillID = 3;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06012ED7 RID: 77527 RVA: 0x005957DC File Offset: 0x00593BDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8E1 RID: 51425
		private List<Input> method_p0;

		// Token: 0x0400C8E2 RID: 51426
		private bool method_p1;
	}
}
