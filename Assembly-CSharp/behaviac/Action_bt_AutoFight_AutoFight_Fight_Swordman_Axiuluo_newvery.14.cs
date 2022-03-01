using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002240 RID: 8768
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node3 : Action
	{
		// Token: 0x06012E09 RID: 77321 RVA: 0x00590420 File Offset: 0x0058E820
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node3()
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
			item2.delay = 1000;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = true;
		}

		// Token: 0x06012E0A RID: 77322 RVA: 0x00590504 File Offset: 0x0058E904
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C803 RID: 51203
		private List<Input> method_p0;

		// Token: 0x0400C804 RID: 51204
		private bool method_p1;
	}
}
