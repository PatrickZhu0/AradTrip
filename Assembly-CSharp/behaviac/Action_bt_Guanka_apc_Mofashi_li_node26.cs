using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A9F RID: 10911
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_li_node26 : Action
	{
		// Token: 0x06013E60 RID: 81504 RVA: 0x005F7924 File Offset: 0x005F5D24
		public Action_bt_Guanka_apc_Mofashi_li_node26()
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
			item.skillID = 2100;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013E61 RID: 81505 RVA: 0x005F79B5 File Offset: 0x005F5DB5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8D4 RID: 55508
		private List<Input> method_p0;

		// Token: 0x0400D8D5 RID: 55509
		private bool method_p1;
	}
}
