using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200273F RID: 10047
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node21 : Action
	{
		// Token: 0x060137C0 RID: 79808 RVA: 0x005CD9FC File Offset: 0x005CBDFC
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node21()
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
			item.skillID = 2008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137C1 RID: 79809 RVA: 0x005CDA8C File Offset: 0x005CBE8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D219 RID: 53785
		private List<Input> method_p0;

		// Token: 0x0400D21A RID: 53786
		private bool method_p1;
	}
}
