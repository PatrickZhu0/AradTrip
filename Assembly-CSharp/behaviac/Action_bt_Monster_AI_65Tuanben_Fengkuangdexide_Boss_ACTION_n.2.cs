using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EB4 RID: 11956
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node9 : Action
	{
		// Token: 0x06014642 RID: 83522 RVA: 0x00621FC8 File Offset: 0x006203C8
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node9()
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
			item.skillID = 21589;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014643 RID: 83523 RVA: 0x00622058 File Offset: 0x00620458
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFB7 RID: 57271
		private List<Input> method_p0;

		// Token: 0x0400DFB8 RID: 57272
		private bool method_p1;
	}
}
