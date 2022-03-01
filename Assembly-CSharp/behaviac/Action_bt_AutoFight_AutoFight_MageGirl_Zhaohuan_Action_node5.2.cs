using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002752 RID: 10066
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node55 : Action
	{
		// Token: 0x060137E5 RID: 79845 RVA: 0x005CF6A4 File Offset: 0x005CDAA4
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node55()
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
			item.skillID = 2103;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137E6 RID: 79846 RVA: 0x005CF734 File Offset: 0x005CDB34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D241 RID: 53825
		private List<Input> method_p0;

		// Token: 0x0400D242 RID: 53826
		private bool method_p1;
	}
}
