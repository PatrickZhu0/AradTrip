using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A50 RID: 10832
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_guijian_feng_node21 : Action
	{
		// Token: 0x06013DCB RID: 81355 RVA: 0x005F384C File Offset: 0x005F1C4C
		public Action_bt_Guanka_apc_guijian_feng_node21()
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
			item.skillID = 1604;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013DCC RID: 81356 RVA: 0x005F38DD File Offset: 0x005F1CDD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D83E RID: 55358
		private List<Input> method_p0;

		// Token: 0x0400D83F RID: 55359
		private bool method_p1;
	}
}
