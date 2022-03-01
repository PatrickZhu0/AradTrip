using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B61 RID: 11105
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node52 : Action
	{
		// Token: 0x06013FD0 RID: 81872 RVA: 0x005FFE74 File Offset: 0x005FE274
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node52()
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

		// Token: 0x06013FD1 RID: 81873 RVA: 0x005FFF04 File Offset: 0x005FE304
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9E8 RID: 55784
		private List<Input> method_p0;

		// Token: 0x0400D9E9 RID: 55785
		private bool method_p1;
	}
}
