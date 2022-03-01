using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F7E RID: 8062
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node10 : Action
	{
		// Token: 0x0601289C RID: 75932 RVA: 0x0056DCA0 File Offset: 0x0056C0A0
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node10()
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

		// Token: 0x0601289D RID: 75933 RVA: 0x0056DD30 File Offset: 0x0056C130
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C28E RID: 49806
		private List<Input> method_p0;

		// Token: 0x0400C28F RID: 49807
		private bool method_p1;
	}
}
