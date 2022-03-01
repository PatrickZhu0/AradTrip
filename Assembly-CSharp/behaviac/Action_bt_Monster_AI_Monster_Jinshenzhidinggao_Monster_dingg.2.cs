using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200368C RID: 13964
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5 : Action
	{
		// Token: 0x06015536 RID: 87350 RVA: 0x0066EB48 File Offset: 0x0066CF48
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5()
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
			item.skillID = 5629;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015537 RID: 87351 RVA: 0x0066EBD8 File Offset: 0x0066CFD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEF8 RID: 61176
		private List<Input> method_p0;

		// Token: 0x0400EEF9 RID: 61177
		private bool method_p1;
	}
}
