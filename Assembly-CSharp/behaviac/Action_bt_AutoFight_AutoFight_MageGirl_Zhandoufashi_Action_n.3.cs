using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002710 RID: 10000
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node5 : Action
	{
		// Token: 0x06013762 RID: 79714 RVA: 0x005CC5D4 File Offset: 0x005CA9D4
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node5()
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
			item.skillID = 2307;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013763 RID: 79715 RVA: 0x005CC664 File Offset: 0x005CAA64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1BA RID: 53690
		private List<Input> method_p0;

		// Token: 0x0400D1BB RID: 53691
		private bool method_p1;
	}
}
