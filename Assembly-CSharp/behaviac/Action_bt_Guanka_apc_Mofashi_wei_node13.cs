using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002AAD RID: 10925
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_wei_node13 : Action
	{
		// Token: 0x06013E7A RID: 81530 RVA: 0x005F84A0 File Offset: 0x005F68A0
		public Action_bt_Guanka_apc_Mofashi_wei_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013E7B RID: 81531 RVA: 0x005F8531 File Offset: 0x005F6931
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8EE RID: 55534
		private List<Input> method_p0;

		// Token: 0x0400D8EF RID: 55535
		private bool method_p1;
	}
}
