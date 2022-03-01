using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E6F RID: 11887
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node86 : Action
	{
		// Token: 0x060145BB RID: 83387 RVA: 0x0061C0BC File Offset: 0x0061A4BC
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node86()
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
			item.skillID = 21653;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145BC RID: 83388 RVA: 0x0061C14C File Offset: 0x0061A54C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF43 RID: 57155
		private List<Input> method_p0;

		// Token: 0x0400DF44 RID: 57156
		private bool method_p1;
	}
}
