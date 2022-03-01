using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003371 RID: 13169
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node6 : Action
	{
		// Token: 0x06014F40 RID: 85824 RVA: 0x006501F4 File Offset: 0x0064E5F4
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node6()
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
			item.skillID = 5697;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014F41 RID: 85825 RVA: 0x00650284 File Offset: 0x0064E684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E807 RID: 59399
		private List<Input> method_p0;

		// Token: 0x0400E808 RID: 59400
		private bool method_p1;
	}
}
