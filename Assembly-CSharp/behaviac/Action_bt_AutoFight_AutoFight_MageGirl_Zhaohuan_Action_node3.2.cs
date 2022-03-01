using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002782 RID: 10114
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node39 : Action
	{
		// Token: 0x06013845 RID: 79941 RVA: 0x005D0BA8 File Offset: 0x005CEFA8
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node39()
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
			item.skillID = 2004;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013846 RID: 79942 RVA: 0x005D0C38 File Offset: 0x005CF038
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2A5 RID: 53925
		private List<Input> method_p0;

		// Token: 0x0400D2A6 RID: 53926
		private bool method_p1;
	}
}
