using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020020C1 RID: 8385
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node10 : Action
	{
		// Token: 0x06012B18 RID: 76568 RVA: 0x0057D440 File Offset: 0x0057B840
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node10()
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

		// Token: 0x06012B19 RID: 76569 RVA: 0x0057D4D0 File Offset: 0x0057B8D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C50B RID: 50443
		private List<Input> method_p0;

		// Token: 0x0400C50C RID: 50444
		private bool method_p1;
	}
}
