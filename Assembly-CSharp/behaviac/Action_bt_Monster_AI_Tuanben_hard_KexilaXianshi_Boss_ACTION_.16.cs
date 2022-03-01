using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003CAB RID: 15531
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node70 : Action
	{
		// Token: 0x060160FD RID: 90365 RVA: 0x006AA4B8 File Offset: 0x006A88B8
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node70()
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
			item.skillID = 21054;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060160FE RID: 90366 RVA: 0x006AA548 File Offset: 0x006A8948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9A3 RID: 63907
		private List<Input> method_p0;

		// Token: 0x0400F9A4 RID: 63908
		private bool method_p1;
	}
}
