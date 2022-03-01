using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027DA RID: 10202
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node119 : Action
	{
		// Token: 0x060138F3 RID: 80115 RVA: 0x005D50A4 File Offset: 0x005D34A4
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node119()
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
			item.skillID = 3608;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138F4 RID: 80116 RVA: 0x005D5134 File Offset: 0x005D3534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D351 RID: 54097
		private List<Input> method_p0;

		// Token: 0x0400D352 RID: 54098
		private bool method_p1;
	}
}
