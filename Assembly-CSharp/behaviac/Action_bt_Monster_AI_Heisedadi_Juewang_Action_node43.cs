using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200346E RID: 13422
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Action_node43 : Action
	{
		// Token: 0x06015127 RID: 86311 RVA: 0x0065977C File Offset: 0x00657B7C
		public Action_bt_Monster_AI_Heisedadi_Juewang_Action_node43()
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
			item.skillID = 6211;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015128 RID: 86312 RVA: 0x0065980C File Offset: 0x00657C0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA29 RID: 59945
		private List<Input> method_p0;

		// Token: 0x0400EA2A RID: 59946
		private bool method_p1;
	}
}
