using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DB4 RID: 11700
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node0 : Action
	{
		// Token: 0x06014449 RID: 83017 RVA: 0x0061666C File Offset: 0x00614A6C
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node0()
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
			item.skillID = 21642;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601444A RID: 83018 RVA: 0x006166FC File Offset: 0x00614AFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE11 RID: 56849
		private List<Input> method_p0;

		// Token: 0x0400DE12 RID: 56850
		private bool method_p1;
	}
}
