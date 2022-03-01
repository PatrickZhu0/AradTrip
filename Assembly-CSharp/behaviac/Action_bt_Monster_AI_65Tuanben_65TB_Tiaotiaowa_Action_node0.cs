using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CD8 RID: 11480
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node0 : Action
	{
		// Token: 0x060142A0 RID: 82592 RVA: 0x0060E784 File Offset: 0x0060CB84
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node0()
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
			item.skillID = 20742;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060142A1 RID: 82593 RVA: 0x0060E814 File Offset: 0x0060CC14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC52 RID: 56402
		private List<Input> method_p0;

		// Token: 0x0400DC53 RID: 56403
		private bool method_p1;
	}
}
