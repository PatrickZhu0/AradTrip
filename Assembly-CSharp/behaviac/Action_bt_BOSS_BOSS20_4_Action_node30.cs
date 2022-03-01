using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029EA RID: 10730
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_4_Action_node30 : Action
	{
		// Token: 0x06013D07 RID: 81159 RVA: 0x005EE2D8 File Offset: 0x005EC6D8
		public Action_bt_BOSS_BOSS20_4_Action_node30()
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
			item.skillID = 5519;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013D08 RID: 81160 RVA: 0x005EE368 File Offset: 0x005EC768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D77A RID: 55162
		private List<Input> method_p0;

		// Token: 0x0400D77B RID: 55163
		private bool method_p1;
	}
}
