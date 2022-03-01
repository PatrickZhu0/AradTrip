using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020020F1 RID: 8433
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node10 : Action
	{
		// Token: 0x06012B76 RID: 76662 RVA: 0x0057F9C0 File Offset: 0x0057DDC0
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node10()
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

		// Token: 0x06012B77 RID: 76663 RVA: 0x0057FA50 File Offset: 0x0057DE50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C569 RID: 50537
		private List<Input> method_p0;

		// Token: 0x0400C56A RID: 50538
		private bool method_p1;
	}
}
