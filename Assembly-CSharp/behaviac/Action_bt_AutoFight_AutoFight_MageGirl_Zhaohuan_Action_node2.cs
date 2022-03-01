using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200277A RID: 10106
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node24 : Action
	{
		// Token: 0x06013835 RID: 79925 RVA: 0x005D0840 File Offset: 0x005CEC40
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node24()
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
			item.skillID = 2111;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013836 RID: 79926 RVA: 0x005D08D0 File Offset: 0x005CECD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D295 RID: 53909
		private List<Input> method_p0;

		// Token: 0x0400D296 RID: 53910
		private bool method_p1;
	}
}
