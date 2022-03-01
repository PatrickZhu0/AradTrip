using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A34 RID: 10804
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Feiwuzhifengtianyu_node13 : Action
	{
		// Token: 0x06013D95 RID: 81301 RVA: 0x005F2088 File Offset: 0x005F0488
		public Action_bt_Guanka_apc_Feiwuzhifengtianyu_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 900;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 2511;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013D96 RID: 81302 RVA: 0x005F2174 File Offset: 0x005F0574
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D804 RID: 55300
		private List<Input> method_p0;

		// Token: 0x0400D805 RID: 55301
		private bool method_p1;
	}
}
