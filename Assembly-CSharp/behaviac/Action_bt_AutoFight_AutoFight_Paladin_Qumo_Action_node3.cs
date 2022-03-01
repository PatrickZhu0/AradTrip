using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027B6 RID: 10166
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node3 : Action
	{
		// Token: 0x060138AB RID: 80043 RVA: 0x005D4150 File Offset: 0x005D2550
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node3()
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
			item.skillID = 3607;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138AC RID: 80044 RVA: 0x005D41E0 File Offset: 0x005D25E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D309 RID: 54025
		private List<Input> method_p0;

		// Token: 0x0400D30A RID: 54026
		private bool method_p1;
	}
}
