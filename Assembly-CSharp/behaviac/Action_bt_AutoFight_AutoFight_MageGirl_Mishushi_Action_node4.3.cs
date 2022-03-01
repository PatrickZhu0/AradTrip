using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002700 RID: 9984
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node47 : Action
	{
		// Token: 0x06013743 RID: 79683 RVA: 0x005CA810 File Offset: 0x005C8C10
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node47()
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
			item.skillID = 3;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013744 RID: 79684 RVA: 0x005CA8F4 File Offset: 0x005C8CF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D19A RID: 53658
		private List<Input> method_p0;

		// Token: 0x0400D19B RID: 53659
		private bool method_p1;
	}
}
