using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200276E RID: 10094
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node14 : Action
	{
		// Token: 0x0601381D RID: 79901 RVA: 0x005D0324 File Offset: 0x005CE724
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node14()
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
			item.skillID = 2009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601381E RID: 79902 RVA: 0x005D03B4 File Offset: 0x005CE7B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D27D RID: 53885
		private List<Input> method_p0;

		// Token: 0x0400D27E RID: 53886
		private bool method_p1;
	}
}
