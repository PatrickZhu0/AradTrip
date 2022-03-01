using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B51 RID: 11089
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node23 : Action
	{
		// Token: 0x06013FB0 RID: 81840 RVA: 0x005FF89C File Offset: 0x005FDC9C
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node23()
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
			item.skillID = 21852;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013FB1 RID: 81841 RVA: 0x005FF92C File Offset: 0x005FDD2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9CF RID: 55759
		private List<Input> method_p0;

		// Token: 0x0400D9D0 RID: 55760
		private bool method_p1;
	}
}
