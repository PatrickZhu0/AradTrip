using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200268B RID: 9867
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node14 : Action
	{
		// Token: 0x0601365A RID: 79450 RVA: 0x005C68B4 File Offset: 0x005C4CB4
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node14()
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
			item.skillID = 2009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601365B RID: 79451 RVA: 0x005C6944 File Offset: 0x005C4D44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0AD RID: 53421
		private List<Input> method_p0;

		// Token: 0x0400D0AE RID: 53422
		private bool method_p1;
	}
}
