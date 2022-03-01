using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C63 RID: 11363
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node21 : Action
	{
		// Token: 0x060141C1 RID: 82369 RVA: 0x00609E10 File Offset: 0x00608210
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node21()
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
			item.skillID = 20779;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060141C2 RID: 82370 RVA: 0x00609EA0 File Offset: 0x006082A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB7C RID: 56188
		private List<Input> method_p0;

		// Token: 0x0400DB7D RID: 56189
		private bool method_p1;
	}
}
