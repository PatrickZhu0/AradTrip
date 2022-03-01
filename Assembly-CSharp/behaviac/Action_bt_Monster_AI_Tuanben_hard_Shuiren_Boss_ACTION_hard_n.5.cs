using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D49 RID: 15689
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node1 : Action
	{
		// Token: 0x06016228 RID: 90664 RVA: 0x006B0B5C File Offset: 0x006AEF5C
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node1()
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

		// Token: 0x06016229 RID: 90665 RVA: 0x006B0BEC File Offset: 0x006AEFEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA8C RID: 64140
		private List<Input> method_p0;

		// Token: 0x0400FA8D RID: 64141
		private bool method_p1;
	}
}
