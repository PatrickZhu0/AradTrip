using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D66 RID: 15718
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node43 : Action
	{
		// Token: 0x06016262 RID: 90722 RVA: 0x006B1518 File Offset: 0x006AF918
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node43()
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
			item.skillID = 21082;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016263 RID: 90723 RVA: 0x006B15A8 File Offset: 0x006AF9A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FABD RID: 64189
		private List<Input> method_p0;

		// Token: 0x0400FABE RID: 64190
		private bool method_p1;
	}
}
