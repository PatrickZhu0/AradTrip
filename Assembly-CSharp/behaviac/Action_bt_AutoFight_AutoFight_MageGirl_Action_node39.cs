using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026AB RID: 9899
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node39 : Action
	{
		// Token: 0x0601369A RID: 79514 RVA: 0x005C7654 File Offset: 0x005C5A54
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node39()
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
			item.skillID = 2010;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601369B RID: 79515 RVA: 0x005C76E4 File Offset: 0x005C5AE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0ED RID: 53485
		private List<Input> method_p0;

		// Token: 0x0400D0EE RID: 53486
		private bool method_p1;
	}
}
