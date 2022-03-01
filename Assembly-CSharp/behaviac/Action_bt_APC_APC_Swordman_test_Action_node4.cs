using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DFA RID: 7674
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Swordman_test_Action_node4 : Action
	{
		// Token: 0x060125A8 RID: 75176 RVA: 0x0055C498 File Offset: 0x0055A898
		public Action_bt_APC_APC_Swordman_test_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1514;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1514;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x060125A9 RID: 75177 RVA: 0x0055C584 File Offset: 0x0055A984
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF97 RID: 49047
		private List<Input> method_p0;

		// Token: 0x0400BF98 RID: 49048
		private bool method_p1;
	}
}
