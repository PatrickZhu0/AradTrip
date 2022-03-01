using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CB1 RID: 11441
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node19 : Action
	{
		// Token: 0x06014257 RID: 82519 RVA: 0x0060CECC File Offset: 0x0060B2CC
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node19()
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
			item.skillID = 20758;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014258 RID: 82520 RVA: 0x0060CF5C File Offset: 0x0060B35C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC0F RID: 56335
		private List<Input> method_p0;

		// Token: 0x0400DC10 RID: 56336
		private bool method_p1;
	}
}
