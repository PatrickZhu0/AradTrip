using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D1B RID: 7451
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Guiqi2_Action_node26 : Action
	{
		// Token: 0x060123F9 RID: 74745 RVA: 0x00551E34 File Offset: 0x00550234
		public Action_bt_APC_APC_Guiqi2_Action_node26()
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
			item.skillID = 9724;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060123FA RID: 74746 RVA: 0x00551EC4 File Offset: 0x005502C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDE8 RID: 48616
		private List<Input> method_p0;

		// Token: 0x0400BDE9 RID: 48617
		private bool method_p1;
	}
}
