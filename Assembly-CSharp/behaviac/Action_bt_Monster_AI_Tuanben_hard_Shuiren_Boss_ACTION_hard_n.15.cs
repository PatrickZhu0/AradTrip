using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D62 RID: 15714
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node40 : Action
	{
		// Token: 0x0601625A RID: 90714 RVA: 0x006B1360 File Offset: 0x006AF760
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node40()
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
			item.skillID = 21080;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601625B RID: 90715 RVA: 0x006B13F0 File Offset: 0x006AF7F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAB5 RID: 64181
		private List<Input> method_p0;

		// Token: 0x0400FAB6 RID: 64182
		private bool method_p1;
	}
}
