using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E42 RID: 11842
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node208 : Action
	{
		// Token: 0x06014561 RID: 83297 RVA: 0x0061ADA8 File Offset: 0x006191A8
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node208()
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
			item.skillID = 21641;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014562 RID: 83298 RVA: 0x0061AE38 File Offset: 0x00619238
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEF3 RID: 57075
		private List<Input> method_p0;

		// Token: 0x0400DEF4 RID: 57076
		private bool method_p1;
	}
}
