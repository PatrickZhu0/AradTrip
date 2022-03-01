using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E03 RID: 7683
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Swordman_test_Action_node18 : Action
	{
		// Token: 0x060125B9 RID: 75193 RVA: 0x0055C8B0 File Offset: 0x0055ACB0
		public Action_bt_APC_APC_Swordman_test_Action_node18()
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

		// Token: 0x060125BA RID: 75194 RVA: 0x0055C940 File Offset: 0x0055AD40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFA6 RID: 49062
		private List<Input> method_p0;

		// Token: 0x0400BFA7 RID: 49063
		private bool method_p1;
	}
}
