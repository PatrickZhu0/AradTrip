using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B59 RID: 11097
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node29 : Action
	{
		// Token: 0x06013FC0 RID: 81856 RVA: 0x005FFB9C File Offset: 0x005FDF9C
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node29()
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

		// Token: 0x06013FC1 RID: 81857 RVA: 0x005FFC2C File Offset: 0x005FE02C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9DD RID: 55773
		private List<Input> method_p0;

		// Token: 0x0400D9DE RID: 55774
		private bool method_p1;
	}
}
