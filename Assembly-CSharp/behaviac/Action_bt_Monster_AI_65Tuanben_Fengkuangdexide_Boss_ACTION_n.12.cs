using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EE1 RID: 12001
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node67 : Action
	{
		// Token: 0x0601469C RID: 83612 RVA: 0x0062304C File Offset: 0x0062144C
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node67()
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
			item.skillID = 21601;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601469D RID: 83613 RVA: 0x006230DC File Offset: 0x006214DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E012 RID: 57362
		private List<Input> method_p0;

		// Token: 0x0400E013 RID: 57363
		private bool method_p1;
	}
}
