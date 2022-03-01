using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D56 RID: 15702
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node31 : Action
	{
		// Token: 0x06016242 RID: 90690 RVA: 0x006B0F98 File Offset: 0x006AF398
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node31()
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
			item.skillID = 21081;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016243 RID: 90691 RVA: 0x006B1028 File Offset: 0x006AF428
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAA3 RID: 64163
		private List<Input> method_p0;

		// Token: 0x0400FAA4 RID: 64164
		private bool method_p1;
	}
}
