using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E05 RID: 7685
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Swordman_test_Action_node21 : Action
	{
		// Token: 0x060125BD RID: 75197 RVA: 0x0055C9A4 File Offset: 0x0055ADA4
		public Action_bt_APC_APC_Swordman_test_Action_node21()
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
			item.skillID = 1503;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060125BE RID: 75198 RVA: 0x0055CA34 File Offset: 0x0055AE34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFA9 RID: 49065
		private List<Input> method_p0;

		// Token: 0x0400BFAA RID: 49066
		private bool method_p1;
	}
}
