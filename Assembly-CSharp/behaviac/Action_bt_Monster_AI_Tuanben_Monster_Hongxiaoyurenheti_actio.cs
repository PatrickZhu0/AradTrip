using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AFA RID: 15098
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node9 : Action
	{
		// Token: 0x06015DB0 RID: 89520 RVA: 0x0069A95C File Offset: 0x00698D5C
		public Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node9()
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
			item.skillID = 21301;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015DB1 RID: 89521 RVA: 0x0069A9EC File Offset: 0x00698DEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6AA RID: 63146
		private List<Input> method_p0;

		// Token: 0x0400F6AB RID: 63147
		private bool method_p1;
	}
}
