using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CC6 RID: 11462
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node15 : Action
	{
		// Token: 0x06014280 RID: 82560 RVA: 0x0060DBA4 File Offset: 0x0060BFA4
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node15()
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
			item.skillID = 20753;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014281 RID: 82561 RVA: 0x0060DC34 File Offset: 0x0060C034
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC33 RID: 56371
		private List<Input> method_p0;

		// Token: 0x0400DC34 RID: 56372
		private bool method_p1;
	}
}
