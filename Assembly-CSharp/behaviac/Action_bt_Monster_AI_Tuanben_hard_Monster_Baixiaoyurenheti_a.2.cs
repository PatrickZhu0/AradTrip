using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D0A RID: 15626
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node10 : Action
	{
		// Token: 0x060161B2 RID: 90546 RVA: 0x006AEBE0 File Offset: 0x006ACFE0
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node10()
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

		// Token: 0x060161B3 RID: 90547 RVA: 0x006AEC70 File Offset: 0x006AD070
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA44 RID: 64068
		private List<Input> method_p0;

		// Token: 0x0400FA45 RID: 64069
		private bool method_p1;
	}
}
