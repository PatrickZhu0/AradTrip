using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002717 RID: 10007
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node7 : Action
	{
		// Token: 0x06013770 RID: 79728 RVA: 0x005CC8F4 File Offset: 0x005CACF4
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node7()
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
			item.skillID = 2306;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013771 RID: 79729 RVA: 0x005CC984 File Offset: 0x005CAD84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1C9 RID: 53705
		private List<Input> method_p0;

		// Token: 0x0400D1CA RID: 53706
		private bool method_p1;
	}
}
