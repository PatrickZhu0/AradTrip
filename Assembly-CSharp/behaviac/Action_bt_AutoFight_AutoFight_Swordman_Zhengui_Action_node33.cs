using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200298B RID: 10635
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node33 : Action
	{
		// Token: 0x06013C4A RID: 80970 RVA: 0x005E9CF4 File Offset: 0x005E80F4
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node33()
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
			item.skillID = 1804;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C4B RID: 80971 RVA: 0x005E9D84 File Offset: 0x005E8184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6B3 RID: 54963
		private List<Input> method_p0;

		// Token: 0x0400D6B4 RID: 54964
		private bool method_p1;
	}
}
