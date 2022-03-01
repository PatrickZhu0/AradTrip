using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020034A5 RID: 13477
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node43 : Action
	{
		// Token: 0x06015192 RID: 86418 RVA: 0x0065B8BC File Offset: 0x00659CBC
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node43()
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
			item.skillID = 6204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015193 RID: 86419 RVA: 0x0065B94C File Offset: 0x00659D4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA94 RID: 60052
		private List<Input> method_p0;

		// Token: 0x0400EA95 RID: 60053
		private bool method_p1;
	}
}
