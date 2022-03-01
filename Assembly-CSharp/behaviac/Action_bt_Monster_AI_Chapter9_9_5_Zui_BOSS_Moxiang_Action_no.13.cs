using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031C4 RID: 12740
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node54 : Action
	{
		// Token: 0x06014C1B RID: 85019 RVA: 0x0063FE54 File Offset: 0x0063E254
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node54()
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
			item.skillID = 21572;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C1C RID: 85020 RVA: 0x0063FEE4 File Offset: 0x0063E2E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E575 RID: 58741
		private List<Input> method_p0;

		// Token: 0x0400E576 RID: 58742
		private bool method_p1;
	}
}
