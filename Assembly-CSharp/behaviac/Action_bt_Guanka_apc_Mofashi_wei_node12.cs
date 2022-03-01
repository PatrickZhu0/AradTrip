using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002AA9 RID: 10921
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_wei_node12 : Action
	{
		// Token: 0x06013E72 RID: 81522 RVA: 0x005F82EC File Offset: 0x005F66EC
		public Action_bt_Guanka_apc_Mofashi_wei_node12()
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
			item.skillID = 2003;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013E73 RID: 81523 RVA: 0x005F837C File Offset: 0x005F677C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8E6 RID: 55526
		private List<Input> method_p0;

		// Token: 0x0400D8E7 RID: 55527
		private bool method_p1;
	}
}
