using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200346A RID: 13418
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Action_node48 : Action
	{
		// Token: 0x0601511F RID: 86303 RVA: 0x006595AC File Offset: 0x006579AC
		public Action_bt_Monster_AI_Heisedadi_Juewang_Action_node48()
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
			item.skillID = 6210;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015120 RID: 86304 RVA: 0x0065963C File Offset: 0x00657A3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA1F RID: 59935
		private List<Input> method_p0;

		// Token: 0x0400EA20 RID: 59936
		private bool method_p1;
	}
}
