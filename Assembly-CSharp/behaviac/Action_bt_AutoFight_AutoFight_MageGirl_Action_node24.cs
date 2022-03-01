using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200269B RID: 9883
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node24 : Action
	{
		// Token: 0x0601367A RID: 79482 RVA: 0x005C6F84 File Offset: 0x005C5384
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node24()
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
			item.skillID = 2011;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601367B RID: 79483 RVA: 0x005C7014 File Offset: 0x005C5414
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0CD RID: 53453
		private List<Input> method_p0;

		// Token: 0x0400D0CE RID: 53454
		private bool method_p1;
	}
}
