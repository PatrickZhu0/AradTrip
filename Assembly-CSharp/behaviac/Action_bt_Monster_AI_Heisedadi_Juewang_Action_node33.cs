using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003473 RID: 13427
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Action_node33 : Action
	{
		// Token: 0x06015131 RID: 86321 RVA: 0x00659994 File Offset: 0x00657D94
		public Action_bt_Monster_AI_Heisedadi_Juewang_Action_node33()
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
			item.skillID = 6214;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015132 RID: 86322 RVA: 0x00659A24 File Offset: 0x00657E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA34 RID: 59956
		private List<Input> method_p0;

		// Token: 0x0400EA35 RID: 59957
		private bool method_p1;
	}
}
