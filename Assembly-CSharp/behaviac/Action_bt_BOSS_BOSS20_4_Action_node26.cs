using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029F6 RID: 10742
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_4_Action_node26 : Action
	{
		// Token: 0x06013D1F RID: 81183 RVA: 0x005EE7F4 File Offset: 0x005ECBF4
		public Action_bt_BOSS_BOSS20_4_Action_node26()
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

		// Token: 0x06013D20 RID: 81184 RVA: 0x005EE884 File Offset: 0x005ECC84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D792 RID: 55186
		private List<Input> method_p0;

		// Token: 0x0400D793 RID: 55187
		private bool method_p1;
	}
}
