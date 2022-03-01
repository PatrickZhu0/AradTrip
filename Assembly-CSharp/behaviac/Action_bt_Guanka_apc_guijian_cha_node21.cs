using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A42 RID: 10818
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_guijian_cha_node21 : Action
	{
		// Token: 0x06013DB0 RID: 81328 RVA: 0x005F2BDC File Offset: 0x005F0FDC
		public Action_bt_Guanka_apc_guijian_cha_node21()
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
			item.skillID = 1509;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013DB1 RID: 81329 RVA: 0x005F2C6D File Offset: 0x005F106D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D821 RID: 55329
		private List<Input> method_p0;

		// Token: 0x0400D822 RID: 55330
		private bool method_p1;
	}
}
