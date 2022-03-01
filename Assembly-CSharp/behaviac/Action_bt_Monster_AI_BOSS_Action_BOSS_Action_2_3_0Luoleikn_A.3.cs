using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F5D RID: 12125
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node17 : Action
	{
		// Token: 0x06014789 RID: 83849 RVA: 0x00628D8C File Offset: 0x0062718C
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node17()
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
			item.skillID = 5050;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601478A RID: 83850 RVA: 0x00628E1C File Offset: 0x0062721C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0F7 RID: 57591
		private List<Input> method_p0;

		// Token: 0x0400E0F8 RID: 57592
		private bool method_p1;
	}
}
