using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D65 RID: 7525
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_jiqingjieshuoyuan_Action_node6 : Action
	{
		// Token: 0x06012487 RID: 74887 RVA: 0x00555954 File Offset: 0x00553D54
		public Action_bt_APC_APC_jiqingjieshuoyuan_Action_node6()
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
			item.skillID = 8007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012488 RID: 74888 RVA: 0x005559E4 File Offset: 0x00553DE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE75 RID: 48757
		private List<Input> method_p0;

		// Token: 0x0400BE76 RID: 48758
		private bool method_p1;
	}
}
