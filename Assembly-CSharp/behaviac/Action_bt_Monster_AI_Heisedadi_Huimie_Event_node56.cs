using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200342E RID: 13358
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node56 : Action
	{
		// Token: 0x060150AA RID: 86186 RVA: 0x00656C80 File Offset: 0x00655080
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node56()
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
			item.skillID = 6220;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060150AB RID: 86187 RVA: 0x00656D10 File Offset: 0x00655110
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E97A RID: 59770
		private List<Input> method_p0;

		// Token: 0x0400E97B RID: 59771
		private bool method_p1;
	}
}
