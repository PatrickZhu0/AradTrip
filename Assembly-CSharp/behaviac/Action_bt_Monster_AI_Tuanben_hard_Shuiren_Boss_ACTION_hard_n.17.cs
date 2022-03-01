using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D6A RID: 15722
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node51 : Action
	{
		// Token: 0x0601626A RID: 90730 RVA: 0x006B16D0 File Offset: 0x006AFAD0
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node51()
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
			item.skillID = 21083;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601626B RID: 90731 RVA: 0x006B1760 File Offset: 0x006AFB60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAC5 RID: 64197
		private List<Input> method_p0;

		// Token: 0x0400FAC6 RID: 64198
		private bool method_p1;
	}
}
