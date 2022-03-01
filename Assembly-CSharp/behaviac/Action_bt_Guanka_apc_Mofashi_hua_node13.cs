using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A8D RID: 10893
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_hua_node13 : Action
	{
		// Token: 0x06013E3E RID: 81470 RVA: 0x005F6D54 File Offset: 0x005F5154
		public Action_bt_Guanka_apc_Mofashi_hua_node13()
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
			item.skillID = 2006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013E3F RID: 81471 RVA: 0x005F6DE5 File Offset: 0x005F51E5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8B2 RID: 55474
		private List<Input> method_p0;

		// Token: 0x0400D8B3 RID: 55475
		private bool method_p1;
	}
}
