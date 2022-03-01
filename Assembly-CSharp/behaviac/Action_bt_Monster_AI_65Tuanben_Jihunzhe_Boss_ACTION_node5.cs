using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F0C RID: 12044
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5 : Action
	{
		// Token: 0x060146EF RID: 83695 RVA: 0x006257BC File Offset: 0x00623BBC
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5()
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
			item.skillID = 21613;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060146F0 RID: 83696 RVA: 0x0062584C File Offset: 0x00623C4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E066 RID: 57446
		private List<Input> method_p0;

		// Token: 0x0400E067 RID: 57447
		private bool method_p1;
	}
}
