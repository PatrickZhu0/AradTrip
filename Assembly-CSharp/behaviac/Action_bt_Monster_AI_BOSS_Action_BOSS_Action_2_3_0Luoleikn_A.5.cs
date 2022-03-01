using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F65 RID: 12133
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node27 : Action
	{
		// Token: 0x06014799 RID: 83865 RVA: 0x006290F4 File Offset: 0x006274F4
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node27()
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
			item.skillID = 5313;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601479A RID: 83866 RVA: 0x00629184 File Offset: 0x00627584
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E107 RID: 57607
		private List<Input> method_p0;

		// Token: 0x0400E108 RID: 57608
		private bool method_p1;
	}
}
