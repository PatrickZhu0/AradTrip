using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003CF3 RID: 15603
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node56 : Action
	{
		// Token: 0x06016185 RID: 90501 RVA: 0x006ADF50 File Offset: 0x006AC350
		public Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node56()
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
			item.skillID = 21405;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016186 RID: 90502 RVA: 0x006ADFE0 File Offset: 0x006AC3E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA21 RID: 64033
		private List<Input> method_p0;

		// Token: 0x0400FA22 RID: 64034
		private bool method_p1;
	}
}
