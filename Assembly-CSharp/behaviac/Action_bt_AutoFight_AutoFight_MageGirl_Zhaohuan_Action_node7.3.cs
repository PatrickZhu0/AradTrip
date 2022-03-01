using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002776 RID: 10102
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node72 : Action
	{
		// Token: 0x0601382D RID: 79917 RVA: 0x005D068C File Offset: 0x005CEA8C
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node72()
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
			item.skillID = 2008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601382E RID: 79918 RVA: 0x005D071C File Offset: 0x005CEB1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D28D RID: 53901
		private List<Input> method_p0;

		// Token: 0x0400D28E RID: 53902
		private bool method_p1;
	}
}
