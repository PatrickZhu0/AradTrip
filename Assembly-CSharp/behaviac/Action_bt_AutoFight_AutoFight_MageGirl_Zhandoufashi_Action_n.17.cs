using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002746 RID: 10054
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node77 : Action
	{
		// Token: 0x060137CE RID: 79822 RVA: 0x005CDD20 File Offset: 0x005CC120
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node77()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 3;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2315;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 380;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 2317;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 300;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 2318;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			this.method_p1 = false;
		}

		// Token: 0x060137CF RID: 79823 RVA: 0x005CDE68 File Offset: 0x005CC268
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D228 RID: 53800
		private List<Input> method_p0;

		// Token: 0x0400D229 RID: 53801
		private bool method_p1;
	}
}
