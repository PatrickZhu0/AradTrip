using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004009 RID: 16393
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10 : Action
	{
		// Token: 0x06016776 RID: 92022 RVA: 0x006CC85C File Offset: 0x006CAC5C
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10()
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
			item.skillID = 5093;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016777 RID: 92023 RVA: 0x006CC8EC File Offset: 0x006CACEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFC5 RID: 65477
		private List<Input> method_p0;

		// Token: 0x0400FFC6 RID: 65478
		private bool method_p1;
	}
}
