using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003132 RID: 12594
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node19 : Action
	{
		// Token: 0x06014B09 RID: 84745 RVA: 0x0063AC68 File Offset: 0x00639068
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node19()
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
			item.skillID = 20620;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B0A RID: 84746 RVA: 0x0063ACF8 File Offset: 0x006390F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E47B RID: 58491
		private List<Input> method_p0;

		// Token: 0x0400E47C RID: 58492
		private bool method_p1;
	}
}
