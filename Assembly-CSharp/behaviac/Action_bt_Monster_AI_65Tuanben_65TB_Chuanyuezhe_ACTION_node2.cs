using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B4D RID: 11085
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node20 : Action
	{
		// Token: 0x06013FA8 RID: 81832 RVA: 0x005FF71C File Offset: 0x005FDB1C
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node20()
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
			item.skillID = 21849;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013FA9 RID: 81833 RVA: 0x005FF7AC File Offset: 0x005FDBAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9C8 RID: 55752
		private List<Input> method_p0;

		// Token: 0x0400D9C9 RID: 55753
		private bool method_p1;
	}
}
