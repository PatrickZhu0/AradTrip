using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E78 RID: 11896
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node294 : Action
	{
		// Token: 0x060145CD RID: 83405 RVA: 0x0061C4D4 File Offset: 0x0061A8D4
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node294()
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
			item.skillID = 21626;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145CE RID: 83406 RVA: 0x0061C564 File Offset: 0x0061A964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF56 RID: 57174
		private List<Input> method_p0;

		// Token: 0x0400DF57 RID: 57175
		private bool method_p1;
	}
}
