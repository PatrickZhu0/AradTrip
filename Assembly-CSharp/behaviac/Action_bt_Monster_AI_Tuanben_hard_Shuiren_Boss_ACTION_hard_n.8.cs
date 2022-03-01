using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D4F RID: 15695
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node18 : Action
	{
		// Token: 0x06016234 RID: 90676 RVA: 0x006B0D64 File Offset: 0x006AF164
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node18()
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

		// Token: 0x06016235 RID: 90677 RVA: 0x006B0DF4 File Offset: 0x006AF1F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA97 RID: 64151
		private List<Input> method_p0;

		// Token: 0x0400FA98 RID: 64152
		private bool method_p1;
	}
}
