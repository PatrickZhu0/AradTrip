using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B64 RID: 11108
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node59 : Action
	{
		// Token: 0x06013FD6 RID: 81878 RVA: 0x005FFF78 File Offset: 0x005FE378
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node59()
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

		// Token: 0x06013FD7 RID: 81879 RVA: 0x00600008 File Offset: 0x005FE408
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9EB RID: 55787
		private List<Input> method_p0;

		// Token: 0x0400D9EC RID: 55788
		private bool method_p1;
	}
}
