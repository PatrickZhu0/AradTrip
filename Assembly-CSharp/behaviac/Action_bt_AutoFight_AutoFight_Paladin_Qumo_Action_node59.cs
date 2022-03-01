using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027E2 RID: 10210
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node59 : Action
	{
		// Token: 0x06013903 RID: 80131 RVA: 0x005D540C File Offset: 0x005D380C
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node59()
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
			item.skillID = 3611;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013904 RID: 80132 RVA: 0x005D549C File Offset: 0x005D389C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D361 RID: 54113
		private List<Input> method_p0;

		// Token: 0x0400D362 RID: 54114
		private bool method_p1;
	}
}
