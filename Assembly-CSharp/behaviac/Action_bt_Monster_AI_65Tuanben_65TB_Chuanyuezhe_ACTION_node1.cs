using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B3C RID: 11068
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node11 : Action
	{
		// Token: 0x06013F86 RID: 81798 RVA: 0x005FECF0 File Offset: 0x005FD0F0
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node11()
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
			item.skillID = 21858;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013F87 RID: 81799 RVA: 0x005FED80 File Offset: 0x005FD180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9AC RID: 55724
		private List<Input> method_p0;

		// Token: 0x0400D9AD RID: 55725
		private bool method_p1;
	}
}
