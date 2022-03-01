using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D1C RID: 15644
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node10 : Action
	{
		// Token: 0x060161D4 RID: 90580 RVA: 0x006AF5EC File Offset: 0x006AD9EC
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node10()
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

		// Token: 0x060161D5 RID: 90581 RVA: 0x006AF67C File Offset: 0x006ADA7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA59 RID: 64089
		private List<Input> method_p0;

		// Token: 0x0400FA5A RID: 64090
		private bool method_p1;
	}
}
