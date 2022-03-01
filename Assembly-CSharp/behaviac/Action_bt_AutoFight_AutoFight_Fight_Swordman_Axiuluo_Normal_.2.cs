using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200224B RID: 8779
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18 : Action
	{
		// Token: 0x06012E1E RID: 77342 RVA: 0x00590C38 File Offset: 0x0058F038
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18()
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
			item.skillID = 1709;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012E1F RID: 77343 RVA: 0x00590CC8 File Offset: 0x0058F0C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C821 RID: 51233
		private List<Input> method_p0;

		// Token: 0x0400C822 RID: 51234
		private bool method_p1;
	}
}
