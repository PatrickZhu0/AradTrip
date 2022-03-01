using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002091 RID: 8337
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node10 : Action
	{
		// Token: 0x06012ABA RID: 76474 RVA: 0x0057AEC0 File Offset: 0x005792C0
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node10()
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
			item.skillID = 2508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012ABB RID: 76475 RVA: 0x0057AF50 File Offset: 0x00579350
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4AD RID: 50349
		private List<Input> method_p0;

		// Token: 0x0400C4AE RID: 50350
		private bool method_p1;
	}
}
