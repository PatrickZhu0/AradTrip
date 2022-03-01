using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200338C RID: 13196
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16 : Action
	{
		// Token: 0x06014F75 RID: 85877 RVA: 0x00650DB4 File Offset: 0x0064F1B4
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16()
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
			item.skillID = 5802;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014F76 RID: 85878 RVA: 0x00650E44 File Offset: 0x0064F244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E84A RID: 59466
		private List<Input> method_p0;

		// Token: 0x0400E84B RID: 59467
		private bool method_p1;
	}
}
