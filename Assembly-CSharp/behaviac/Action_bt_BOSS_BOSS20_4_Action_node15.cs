using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029EE RID: 10734
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_4_Action_node15 : Action
	{
		// Token: 0x06013D0F RID: 81167 RVA: 0x005EE48C File Offset: 0x005EC88C
		public Action_bt_BOSS_BOSS20_4_Action_node15()
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

		// Token: 0x06013D10 RID: 81168 RVA: 0x005EE51C File Offset: 0x005EC91C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D782 RID: 55170
		private List<Input> method_p0;

		// Token: 0x0400D783 RID: 55171
		private bool method_p1;
	}
}
