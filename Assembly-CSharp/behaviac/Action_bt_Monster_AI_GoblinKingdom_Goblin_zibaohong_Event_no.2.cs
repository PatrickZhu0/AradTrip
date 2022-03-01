using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003374 RID: 13172
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node8 : Action
	{
		// Token: 0x06014F46 RID: 85830 RVA: 0x00650348 File Offset: 0x0064E748
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node8()
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

		// Token: 0x06014F47 RID: 85831 RVA: 0x006503D8 File Offset: 0x0064E7D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E80D RID: 59405
		private List<Input> method_p0;

		// Token: 0x0400E80E RID: 59406
		private bool method_p1;
	}
}
