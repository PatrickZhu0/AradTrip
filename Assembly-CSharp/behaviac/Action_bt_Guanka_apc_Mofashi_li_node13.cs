using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A9B RID: 10907
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Mofashi_li_node13 : Action
	{
		// Token: 0x06013E58 RID: 81496 RVA: 0x005F7770 File Offset: 0x005F5B70
		public Action_bt_Guanka_apc_Mofashi_li_node13()
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
			item.skillID = 2007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013E59 RID: 81497 RVA: 0x005F7801 File Offset: 0x005F5C01
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8CC RID: 55500
		private List<Input> method_p0;

		// Token: 0x0400D8CD RID: 55501
		private bool method_p1;
	}
}
