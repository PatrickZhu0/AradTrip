using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E1C RID: 11804
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node131 : Action
	{
		// Token: 0x06014515 RID: 83221 RVA: 0x00619FF0 File Offset: 0x006183F0
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node131()
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
			item.skillID = 21623;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014516 RID: 83222 RVA: 0x0061A080 File Offset: 0x00618480
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEBB RID: 57019
		private List<Input> method_p0;

		// Token: 0x0400DEBC RID: 57020
		private bool method_p1;
	}
}
