using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D94 RID: 11668
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node12 : Action
	{
		// Token: 0x06014409 RID: 82953 RVA: 0x00615990 File Offset: 0x00613D90
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node12()
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
			item.skillID = 21645;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601440A RID: 82954 RVA: 0x00615A20 File Offset: 0x00613E20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDD2 RID: 56786
		private List<Input> method_p0;

		// Token: 0x0400DDD3 RID: 56787
		private bool method_p1;
	}
}
