using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A54 RID: 10836
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_guijian_feng_node27 : Action
	{
		// Token: 0x06013DD3 RID: 81363 RVA: 0x005F3A00 File Offset: 0x005F1E00
		public Action_bt_Guanka_apc_guijian_feng_node27()
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
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013DD4 RID: 81364 RVA: 0x005F3A91 File Offset: 0x005F1E91
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D846 RID: 55366
		private List<Input> method_p0;

		// Token: 0x0400D847 RID: 55367
		private bool method_p1;
	}
}
