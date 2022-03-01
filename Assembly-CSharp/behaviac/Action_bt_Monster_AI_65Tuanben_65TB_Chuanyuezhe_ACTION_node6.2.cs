using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B68 RID: 11112
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node65 : Action
	{
		// Token: 0x06013FDE RID: 81886 RVA: 0x00600160 File Offset: 0x005FE560
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node65()
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
			item.skillID = 21851;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013FDF RID: 81887 RVA: 0x006001F0 File Offset: 0x005FE5F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9F1 RID: 55793
		private List<Input> method_p0;

		// Token: 0x0400D9F2 RID: 55794
		private bool method_p1;
	}
}
