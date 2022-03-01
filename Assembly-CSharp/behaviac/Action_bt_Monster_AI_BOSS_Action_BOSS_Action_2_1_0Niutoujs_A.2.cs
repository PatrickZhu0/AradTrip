using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F48 RID: 12104
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node12 : Action
	{
		// Token: 0x06014760 RID: 83808 RVA: 0x00627FBC File Offset: 0x006263BC
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node12()
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
			item.skillID = 5005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014761 RID: 83809 RVA: 0x0062804C File Offset: 0x0062644C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0CF RID: 57551
		private List<Input> method_p0;

		// Token: 0x0400E0D0 RID: 57552
		private bool method_p1;
	}
}
