using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002AD1 RID: 10961
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Shenqiangshou_taigu_node26 : Action
	{
		// Token: 0x06013EBD RID: 81597 RVA: 0x005FA0D0 File Offset: 0x005F84D0
		public Action_bt_Guanka_apc_Shenqiangshou_taigu_node26()
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
			item.skillID = 1101;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013EBE RID: 81598 RVA: 0x005FA160 File Offset: 0x005F8560
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D92F RID: 55599
		private List<Input> method_p0;

		// Token: 0x0400D930 RID: 55600
		private bool method_p1;
	}
}
