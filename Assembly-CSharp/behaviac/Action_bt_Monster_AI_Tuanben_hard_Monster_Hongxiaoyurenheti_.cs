using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D19 RID: 15641
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node9 : Action
	{
		// Token: 0x060161CE RID: 90574 RVA: 0x006AF47C File Offset: 0x006AD87C
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node9()
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

		// Token: 0x060161CF RID: 90575 RVA: 0x006AF50C File Offset: 0x006AD90C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA52 RID: 64082
		private List<Input> method_p0;

		// Token: 0x0400FA53 RID: 64083
		private bool method_p1;
	}
}
