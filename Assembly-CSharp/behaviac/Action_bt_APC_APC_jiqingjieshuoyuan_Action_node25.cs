using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D73 RID: 7539
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_jiqingjieshuoyuan_Action_node25 : Action
	{
		// Token: 0x060124A3 RID: 74915 RVA: 0x00555F44 File Offset: 0x00554344
		public Action_bt_APC_APC_jiqingjieshuoyuan_Action_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 3000;
			item.randomChangeDirection = false;
			item.skillID = 8010;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060124A4 RID: 74916 RVA: 0x00555FD8 File Offset: 0x005543D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE94 RID: 48788
		private List<Input> method_p0;

		// Token: 0x0400BE95 RID: 48789
		private bool method_p1;
	}
}
