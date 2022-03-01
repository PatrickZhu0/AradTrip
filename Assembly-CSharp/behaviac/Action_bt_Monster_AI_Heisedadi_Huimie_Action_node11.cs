using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003415 RID: 13333
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Action_node11 : Action
	{
		// Token: 0x0601507B RID: 86139 RVA: 0x00655DB8 File Offset: 0x006541B8
		public Action_bt_Monster_AI_Heisedadi_Huimie_Action_node11()
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
			item.skillID = 6222;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601507C RID: 86140 RVA: 0x00655E48 File Offset: 0x00654248
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E951 RID: 59729
		private List<Input> method_p0;

		// Token: 0x0400E952 RID: 59730
		private bool method_p1;
	}
}
