using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021DD RID: 8669
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node25 : Action
	{
		// Token: 0x06012D48 RID: 77128 RVA: 0x0058A940 File Offset: 0x00588D40
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node25()
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

		// Token: 0x06012D49 RID: 77129 RVA: 0x0058A9D0 File Offset: 0x00588DD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C73B RID: 51003
		private List<Input> method_p0;

		// Token: 0x0400C73C RID: 51004
		private bool method_p1;
	}
}
