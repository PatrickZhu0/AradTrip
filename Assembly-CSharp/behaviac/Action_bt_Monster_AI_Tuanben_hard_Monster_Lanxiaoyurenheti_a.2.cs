using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D2E RID: 15662
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node10 : Action
	{
		// Token: 0x060161F6 RID: 90614 RVA: 0x006AFFF8 File Offset: 0x006AE3F8
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node10()
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
			item.skillID = 21021;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060161F7 RID: 90615 RVA: 0x006B0088 File Offset: 0x006AE488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA6E RID: 64110
		private List<Input> method_p0;

		// Token: 0x0400FA6F RID: 64111
		private bool method_p1;
	}
}
