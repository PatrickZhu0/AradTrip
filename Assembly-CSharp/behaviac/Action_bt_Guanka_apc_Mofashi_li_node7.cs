using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A93 RID: 10899
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_li_node7 : Action
	{
		// Token: 0x06013E48 RID: 81480 RVA: 0x005F7408 File Offset: 0x005F5808
		public Action_bt_Guanka_apc_Mofashi_li_node7()
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

		// Token: 0x06013E49 RID: 81481 RVA: 0x005F7498 File Offset: 0x005F5898
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8BC RID: 55484
		private List<Input> method_p0;

		// Token: 0x0400D8BD RID: 55485
		private bool method_p1;
	}
}
