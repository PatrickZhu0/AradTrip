using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020020A0 RID: 8352
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node30 : Action
	{
		// Token: 0x06012AD8 RID: 76504 RVA: 0x0057B664 File Offset: 0x00579A64
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node30()
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
			item.skillID = 3;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06012AD9 RID: 76505 RVA: 0x0057B748 File Offset: 0x00579B48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4CC RID: 50380
		private List<Input> method_p0;

		// Token: 0x0400C4CD RID: 50381
		private bool method_p1;
	}
}
