using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002916 RID: 10518
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node21 : Action
	{
		// Token: 0x06013B62 RID: 80738 RVA: 0x005E3FFC File Offset: 0x005E23FC
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node21()
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
			item.skillID = 1907;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B63 RID: 80739 RVA: 0x005E408C File Offset: 0x005E248C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5C6 RID: 54726
		private List<Input> method_p0;

		// Token: 0x0400D5C7 RID: 54727
		private bool method_p1;
	}
}
