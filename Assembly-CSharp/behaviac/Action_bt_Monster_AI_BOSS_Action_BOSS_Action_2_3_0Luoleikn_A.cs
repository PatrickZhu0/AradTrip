using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F55 RID: 12117
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node6 : Action
	{
		// Token: 0x06014779 RID: 83833 RVA: 0x00628A24 File Offset: 0x00626E24
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node6()
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
			item.skillID = 5049;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601477A RID: 83834 RVA: 0x00628AB4 File Offset: 0x00626EB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0E7 RID: 57575
		private List<Input> method_p0;

		// Token: 0x0400E0E8 RID: 57576
		private bool method_p1;
	}
}
