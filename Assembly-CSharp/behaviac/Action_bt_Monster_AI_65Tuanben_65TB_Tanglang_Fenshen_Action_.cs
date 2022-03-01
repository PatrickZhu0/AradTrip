using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CBE RID: 11454
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node0 : Action
	{
		// Token: 0x06014270 RID: 82544 RVA: 0x0060D8A4 File Offset: 0x0060BCA4
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node0()
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
			item.skillID = 20750;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014271 RID: 82545 RVA: 0x0060D934 File Offset: 0x0060BD34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC25 RID: 56357
		private List<Input> method_p0;

		// Token: 0x0400DC26 RID: 56358
		private bool method_p1;
	}
}
