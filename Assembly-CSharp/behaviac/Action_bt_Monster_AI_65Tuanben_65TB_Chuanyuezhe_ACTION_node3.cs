using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B42 RID: 11074
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node36 : Action
	{
		// Token: 0x06013F92 RID: 81810 RVA: 0x005FEF84 File Offset: 0x005FD384
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node36()
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
			item.skillID = 21847;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013F93 RID: 81811 RVA: 0x005FF014 File Offset: 0x005FD414
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9B6 RID: 55734
		private List<Input> method_p0;

		// Token: 0x0400D9B7 RID: 55735
		private bool method_p1;
	}
}
