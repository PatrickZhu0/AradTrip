using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200265E RID: 9822
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node23 : Action
	{
		// Token: 0x06013601 RID: 79361 RVA: 0x005C4250 File Offset: 0x005C2650
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 2000;
			item.randomChangeDirection = false;
			item.skillID = 1201;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1005;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013602 RID: 79362 RVA: 0x005C4340 File Offset: 0x005C2740
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D051 RID: 53329
		private List<Input> method_p0;

		// Token: 0x0400D052 RID: 53330
		private bool method_p1;
	}
}
