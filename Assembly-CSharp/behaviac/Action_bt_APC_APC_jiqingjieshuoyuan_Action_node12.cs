using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D6A RID: 7530
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_jiqingjieshuoyuan_Action_node12 : Action
	{
		// Token: 0x06012491 RID: 74897 RVA: 0x00555B64 File Offset: 0x00553F64
		public Action_bt_APC_APC_jiqingjieshuoyuan_Action_node12()
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
			item.skillID = 8008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012492 RID: 74898 RVA: 0x00555BF4 File Offset: 0x00553FF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE80 RID: 48768
		private List<Input> method_p0;

		// Token: 0x0400BE81 RID: 48769
		private bool method_p1;
	}
}
