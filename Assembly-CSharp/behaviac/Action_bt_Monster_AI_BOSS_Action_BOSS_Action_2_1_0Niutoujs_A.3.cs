using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F4C RID: 12108
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node17 : Action
	{
		// Token: 0x06014768 RID: 83816 RVA: 0x00628170 File Offset: 0x00626570
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node17()
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
			item.skillID = 5004;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014769 RID: 83817 RVA: 0x00628200 File Offset: 0x00626600
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0D7 RID: 57559
		private List<Input> method_p0;

		// Token: 0x0400E0D8 RID: 57560
		private bool method_p1;
	}
}
