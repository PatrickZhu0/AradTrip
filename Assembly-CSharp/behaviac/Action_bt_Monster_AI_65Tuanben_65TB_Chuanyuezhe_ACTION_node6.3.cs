using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B6A RID: 11114
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node68 : Action
	{
		// Token: 0x06013FE2 RID: 81890 RVA: 0x00600254 File Offset: 0x005FE654
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node68()
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
			item.skillID = 21850;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013FE3 RID: 81891 RVA: 0x006002E4 File Offset: 0x005FE6E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9F4 RID: 55796
		private List<Input> method_p0;

		// Token: 0x0400D9F5 RID: 55797
		private bool method_p1;
	}
}
