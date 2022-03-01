using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200269F RID: 9887
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node48 : Action
	{
		// Token: 0x06013682 RID: 79490 RVA: 0x005C7138 File Offset: 0x005C5538
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node48()
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
			item.skillID = 2207;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013683 RID: 79491 RVA: 0x005C71C8 File Offset: 0x005C55C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0D5 RID: 53461
		private List<Input> method_p0;

		// Token: 0x0400D0D6 RID: 53462
		private bool method_p1;
	}
}
