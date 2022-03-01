using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200343B RID: 13371
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node43 : Action
	{
		// Token: 0x060150C4 RID: 86212 RVA: 0x00657318 File Offset: 0x00655718
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node43()
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

		// Token: 0x060150C5 RID: 86213 RVA: 0x006573A8 File Offset: 0x006557A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E994 RID: 59796
		private List<Input> method_p0;

		// Token: 0x0400E995 RID: 59797
		private bool method_p1;
	}
}
