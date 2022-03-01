using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029E6 RID: 10726
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_4_Action_node5 : Action
	{
		// Token: 0x06013CFF RID: 81151 RVA: 0x005EE124 File Offset: 0x005EC524
		public Action_bt_BOSS_BOSS20_4_Action_node5()
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
			item.skillID = 5520;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013D00 RID: 81152 RVA: 0x005EE1B4 File Offset: 0x005EC5B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D772 RID: 55154
		private List<Input> method_p0;

		// Token: 0x0400D773 RID: 55155
		private bool method_p1;
	}
}
