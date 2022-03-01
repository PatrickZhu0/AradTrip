using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031AA RID: 12714
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node19 : Action
	{
		// Token: 0x06014BE7 RID: 84967 RVA: 0x0063F3B4 File Offset: 0x0063D7B4
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node19()
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
			item.skillID = 21547;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014BE8 RID: 84968 RVA: 0x0063F444 File Offset: 0x0063D844
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E54F RID: 58703
		private List<Input> method_p0;

		// Token: 0x0400E550 RID: 58704
		private bool method_p1;
	}
}
