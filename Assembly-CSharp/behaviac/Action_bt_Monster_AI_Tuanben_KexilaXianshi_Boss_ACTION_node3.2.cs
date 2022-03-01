using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A66 RID: 14950
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node35 : Action
	{
		// Token: 0x06015C95 RID: 89237 RVA: 0x00694498 File Offset: 0x00692898
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node35()
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
			item.skillID = 21052;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C96 RID: 89238 RVA: 0x00694528 File Offset: 0x00692928
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5C6 RID: 62918
		private List<Input> method_p0;

		// Token: 0x0400F5C7 RID: 62919
		private bool method_p1;
	}
}
