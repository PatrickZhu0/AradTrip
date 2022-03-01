using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003382 RID: 13186
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7 : Action
	{
		// Token: 0x06014F61 RID: 85857 RVA: 0x00650A48 File Offset: 0x0064EE48
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7()
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
			item.skillID = 5801;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014F62 RID: 85858 RVA: 0x00650AD8 File Offset: 0x0064EED8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E82E RID: 59438
		private List<Input> method_p0;

		// Token: 0x0400E82F RID: 59439
		private bool method_p1;
	}
}
