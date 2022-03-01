using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002811 RID: 10257
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node45 : Action
	{
		// Token: 0x06013961 RID: 80225 RVA: 0x005D6890 File Offset: 0x005D4C90
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node45()
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
			item.skillID = 3500;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 400;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 3501;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 400;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 3502;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			this.method_p1 = false;
		}

		// Token: 0x06013962 RID: 80226 RVA: 0x005D69D8 File Offset: 0x005D4DD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3C0 RID: 54208
		private List<Input> method_p0;

		// Token: 0x0400D3C1 RID: 54209
		private bool method_p1;
	}
}
