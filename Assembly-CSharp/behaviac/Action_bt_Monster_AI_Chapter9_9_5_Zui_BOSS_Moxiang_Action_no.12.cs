using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031C0 RID: 12736
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node49 : Action
	{
		// Token: 0x06014C13 RID: 85011 RVA: 0x0063FCB8 File Offset: 0x0063E0B8
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node49()
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
			item.skillID = 21570;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C14 RID: 85012 RVA: 0x0063FD48 File Offset: 0x0063E148
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E56E RID: 58734
		private List<Input> method_p0;

		// Token: 0x0400E56F RID: 58735
		private bool method_p1;
	}
}
