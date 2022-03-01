using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E38 RID: 11832
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node119 : Action
	{
		// Token: 0x0601454D RID: 83277 RVA: 0x0061AA18 File Offset: 0x00618E18
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node119()
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
			item.skillID = 21631;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601454E RID: 83278 RVA: 0x0061AAA8 File Offset: 0x00618EA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEE4 RID: 57060
		private List<Input> method_p0;

		// Token: 0x0400DEE5 RID: 57061
		private bool method_p1;
	}
}
