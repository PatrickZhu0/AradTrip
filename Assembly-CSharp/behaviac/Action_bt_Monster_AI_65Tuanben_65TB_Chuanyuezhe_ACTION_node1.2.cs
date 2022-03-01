using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B3F RID: 11071
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node17 : Action
	{
		// Token: 0x06013F8C RID: 81804 RVA: 0x005FEE30 File Offset: 0x005FD230
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node17()
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
			item.skillID = 21853;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013F8D RID: 81805 RVA: 0x005FEEC0 File Offset: 0x005FD2C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9B0 RID: 55728
		private List<Input> method_p0;

		// Token: 0x0400D9B1 RID: 55729
		private bool method_p1;
	}
}
