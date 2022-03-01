using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CCA RID: 11466
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node25 : Action
	{
		// Token: 0x06014288 RID: 82568 RVA: 0x0060DD24 File Offset: 0x0060C124
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node25()
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
			item.skillID = 20754;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014289 RID: 82569 RVA: 0x0060DDB4 File Offset: 0x0060C1B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC3A RID: 56378
		private List<Input> method_p0;

		// Token: 0x0400DC3B RID: 56379
		private bool method_p1;
	}
}
