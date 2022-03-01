using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AE8 RID: 15080
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node9 : Action
	{
		// Token: 0x06015D8E RID: 89486 RVA: 0x00699F50 File Offset: 0x00698350
		public Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node9()
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
			item.skillID = 21302;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D8F RID: 89487 RVA: 0x00699FE0 File Offset: 0x006983E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F695 RID: 63125
		private List<Input> method_p0;

		// Token: 0x0400F696 RID: 63126
		private bool method_p1;
	}
}
