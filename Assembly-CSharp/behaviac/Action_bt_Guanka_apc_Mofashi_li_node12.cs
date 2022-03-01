using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A97 RID: 10903
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_li_node12 : Action
	{
		// Token: 0x06013E50 RID: 81488 RVA: 0x005F75BC File Offset: 0x005F59BC
		public Action_bt_Guanka_apc_Mofashi_li_node12()
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
			item.skillID = 2005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013E51 RID: 81489 RVA: 0x005F764C File Offset: 0x005F5A4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8C4 RID: 55492
		private List<Input> method_p0;

		// Token: 0x0400D8C5 RID: 55493
		private bool method_p1;
	}
}
