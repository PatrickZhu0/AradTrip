using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020020FD RID: 8445
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node25 : Action
	{
		// Token: 0x06012B8E RID: 76686 RVA: 0x0057FFF4 File Offset: 0x0057E3F4
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node25()
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
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012B8F RID: 76687 RVA: 0x00580084 File Offset: 0x0057E484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C581 RID: 50561
		private List<Input> method_p0;

		// Token: 0x0400C582 RID: 50562
		private bool method_p1;
	}
}
