using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B5C RID: 11100
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node3 : Action
	{
		// Token: 0x06013FC6 RID: 81862 RVA: 0x005FFD08 File Offset: 0x005FE108
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node3()
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
			item.skillID = 21846;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013FC7 RID: 81863 RVA: 0x005FFD98 File Offset: 0x005FE198
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9E4 RID: 55780
		private List<Input> method_p0;

		// Token: 0x0400D9E5 RID: 55781
		private bool method_p1;
	}
}
