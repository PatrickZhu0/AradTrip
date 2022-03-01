using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B46 RID: 11078
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node30 : Action
	{
		// Token: 0x06013F9A RID: 81818 RVA: 0x005FF13C File Offset: 0x005FD53C
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node30()
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
			item.skillID = 21844;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013F9B RID: 81819 RVA: 0x005FF1CC File Offset: 0x005FD5CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9BE RID: 55742
		private List<Input> method_p0;

		// Token: 0x0400D9BF RID: 55743
		private bool method_p1;
	}
}
