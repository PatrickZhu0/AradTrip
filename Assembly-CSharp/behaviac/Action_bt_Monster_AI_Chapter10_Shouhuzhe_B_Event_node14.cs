using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003142 RID: 12610
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node14 : Action
	{
		// Token: 0x06014B27 RID: 84775 RVA: 0x0063B75C File Offset: 0x00639B5C
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node14()
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
			item.skillID = 20618;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B28 RID: 84776 RVA: 0x0063B7EC File Offset: 0x00639BEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4A0 RID: 58528
		private List<Input> method_p0;

		// Token: 0x0400E4A1 RID: 58529
		private bool method_p1;
	}
}
