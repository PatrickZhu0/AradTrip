using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002929 RID: 10537
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node58 : Action
	{
		// Token: 0x06013B88 RID: 80776 RVA: 0x005E4A58 File Offset: 0x005E2E58
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node58()
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
			item.skillID = 1511;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B89 RID: 80777 RVA: 0x005E4AE8 File Offset: 0x005E2EE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5ED RID: 54765
		private List<Input> method_p0;

		// Token: 0x0400D5EE RID: 54766
		private bool method_p1;
	}
}
