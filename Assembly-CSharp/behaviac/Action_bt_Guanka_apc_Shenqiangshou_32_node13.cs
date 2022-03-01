using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002ABC RID: 10940
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Shenqiangshou_32_node13 : Action
	{
		// Token: 0x06013E96 RID: 81558 RVA: 0x005F90D0 File Offset: 0x005F74D0
		public Action_bt_Guanka_apc_Shenqiangshou_32_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1012;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013E97 RID: 81559 RVA: 0x005F9161 File Offset: 0x005F7561
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D909 RID: 55561
		private List<Input> method_p0;

		// Token: 0x0400D90A RID: 55562
		private bool method_p1;
	}
}
