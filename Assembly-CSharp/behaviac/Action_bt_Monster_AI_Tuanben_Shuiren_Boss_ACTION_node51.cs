using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B70 RID: 15216
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node51 : Action
	{
		// Token: 0x06015E95 RID: 89749 RVA: 0x0069E2E0 File Offset: 0x0069C6E0
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node51()
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

		// Token: 0x06015E96 RID: 89750 RVA: 0x0069E370 File Offset: 0x0069C770
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F75C RID: 63324
		private List<Input> method_p0;

		// Token: 0x0400F75D RID: 63325
		private bool method_p1;
	}
}
