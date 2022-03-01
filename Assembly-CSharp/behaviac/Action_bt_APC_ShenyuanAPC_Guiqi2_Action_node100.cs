using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E4B RID: 7755
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node100 : Action
	{
		// Token: 0x06012643 RID: 75331 RVA: 0x0055FD40 File Offset: 0x0055E140
		public Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node100()
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
			item.skillID = 9726;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012644 RID: 75332 RVA: 0x0055FDD0 File Offset: 0x0055E1D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C029 RID: 49193
		private List<Input> method_p0;

		// Token: 0x0400C02A RID: 49194
		private bool method_p1;
	}
}
