using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002AA5 RID: 10917
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_wei_node7 : Action
	{
		// Token: 0x06013E6A RID: 81514 RVA: 0x005F8138 File Offset: 0x005F6538
		public Action_bt_Guanka_apc_Mofashi_wei_node7()
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

		// Token: 0x06013E6B RID: 81515 RVA: 0x005F81C8 File Offset: 0x005F65C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8DE RID: 55518
		private List<Input> method_p0;

		// Token: 0x0400D8DF RID: 55519
		private bool method_p1;
	}
}
