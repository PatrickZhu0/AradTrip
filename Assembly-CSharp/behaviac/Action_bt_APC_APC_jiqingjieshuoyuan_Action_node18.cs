using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D6E RID: 7534
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_jiqingjieshuoyuan_Action_node18 : Action
	{
		// Token: 0x06012499 RID: 74905 RVA: 0x00555D18 File Offset: 0x00554118
		public Action_bt_APC_APC_jiqingjieshuoyuan_Action_node18()
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
			item.skillID = 8009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601249A RID: 74906 RVA: 0x00555DA8 File Offset: 0x005541A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE88 RID: 48776
		private List<Input> method_p0;

		// Token: 0x0400BE89 RID: 48777
		private bool method_p1;
	}
}
