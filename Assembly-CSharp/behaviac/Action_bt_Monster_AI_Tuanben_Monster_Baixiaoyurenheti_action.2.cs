using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AEB RID: 15083
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node10 : Action
	{
		// Token: 0x06015D94 RID: 89492 RVA: 0x0069A0C0 File Offset: 0x006984C0
		public Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node10()
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

		// Token: 0x06015D95 RID: 89493 RVA: 0x0069A150 File Offset: 0x00698550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F69C RID: 63132
		private List<Input> method_p0;

		// Token: 0x0400F69D RID: 63133
		private bool method_p1;
	}
}
