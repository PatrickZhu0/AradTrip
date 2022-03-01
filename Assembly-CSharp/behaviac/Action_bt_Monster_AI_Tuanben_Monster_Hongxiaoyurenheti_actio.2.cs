using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AFD RID: 15101
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node10 : Action
	{
		// Token: 0x06015DB6 RID: 89526 RVA: 0x0069AACC File Offset: 0x00698ECC
		public Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node10()
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

		// Token: 0x06015DB7 RID: 89527 RVA: 0x0069AB5C File Offset: 0x00698F5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6B1 RID: 63153
		private List<Input> method_p0;

		// Token: 0x0400F6B2 RID: 63154
		private bool method_p1;
	}
}
