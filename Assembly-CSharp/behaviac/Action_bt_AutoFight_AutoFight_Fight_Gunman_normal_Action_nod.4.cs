using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021D1 RID: 8657
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node10 : Action
	{
		// Token: 0x06012D30 RID: 77104 RVA: 0x0058A30C File Offset: 0x0058870C
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node10()
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
			item.skillID = 1007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012D31 RID: 77105 RVA: 0x0058A39C File Offset: 0x0058879C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C723 RID: 50979
		private List<Input> method_p0;

		// Token: 0x0400C724 RID: 50980
		private bool method_p1;
	}
}
