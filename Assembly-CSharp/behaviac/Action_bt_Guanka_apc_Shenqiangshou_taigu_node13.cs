using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002ACD RID: 10957
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_Shenqiangshou_taigu_node13 : Action
	{
		// Token: 0x06013EB5 RID: 81589 RVA: 0x005F9EC0 File Offset: 0x005F82C0
		public Action_bt_Guanka_apc_Shenqiangshou_taigu_node13()
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
			item.skillID = 1010;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1009;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013EB6 RID: 81590 RVA: 0x005F9FAC File Offset: 0x005F83AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D927 RID: 55591
		private List<Input> method_p0;

		// Token: 0x0400D928 RID: 55592
		private bool method_p1;
	}
}
