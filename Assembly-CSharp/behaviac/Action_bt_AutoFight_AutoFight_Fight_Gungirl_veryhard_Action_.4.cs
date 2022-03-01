using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020020A9 RID: 8361
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node10 : Action
	{
		// Token: 0x06012AE9 RID: 76521 RVA: 0x0057C180 File Offset: 0x0057A580
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node10()
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

		// Token: 0x06012AEA RID: 76522 RVA: 0x0057C210 File Offset: 0x0057A610
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4DC RID: 50396
		private List<Input> method_p0;

		// Token: 0x0400C4DD RID: 50397
		private bool method_p1;
	}
}
