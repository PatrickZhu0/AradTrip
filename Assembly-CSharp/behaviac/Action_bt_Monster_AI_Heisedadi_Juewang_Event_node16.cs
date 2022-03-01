using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200347A RID: 13434
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node16 : Action
	{
		// Token: 0x0601513D RID: 86333 RVA: 0x00659FCC File Offset: 0x006583CC
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node16()
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
			item.skillID = 6215;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601513E RID: 86334 RVA: 0x0065A05C File Offset: 0x0065845C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA3F RID: 59967
		private List<Input> method_p0;

		// Token: 0x0400EA40 RID: 59968
		private bool method_p1;
	}
}
