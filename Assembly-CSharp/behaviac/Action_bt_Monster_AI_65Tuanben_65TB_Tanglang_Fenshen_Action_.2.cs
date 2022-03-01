using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CC2 RID: 11458
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7 : Action
	{
		// Token: 0x06014278 RID: 82552 RVA: 0x0060DA24 File Offset: 0x0060BE24
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7()
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
			item.skillID = 20752;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014279 RID: 82553 RVA: 0x0060DAB4 File Offset: 0x0060BEB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC2C RID: 56364
		private List<Input> method_p0;

		// Token: 0x0400DC2D RID: 56365
		private bool method_p1;
	}
}
