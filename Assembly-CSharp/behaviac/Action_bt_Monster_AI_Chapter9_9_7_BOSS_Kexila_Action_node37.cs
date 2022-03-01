using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200320C RID: 12812
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node37 : Action
	{
		// Token: 0x06014CA2 RID: 85154 RVA: 0x006432B4 File Offset: 0x006416B4
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node37()
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
			item.skillID = 21562;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014CA3 RID: 85155 RVA: 0x00643344 File Offset: 0x00641744
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5EE RID: 58862
		private List<Input> method_p0;

		// Token: 0x0400E5EF RID: 58863
		private bool method_p1;
	}
}
