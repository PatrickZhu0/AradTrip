using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E2D RID: 15917
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node6 : Action
	{
		// Token: 0x060163E0 RID: 91104 RVA: 0x006B9A54 File Offset: 0x006B7E54
		public Action_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node6()
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
			item.skillID = 7226;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163E1 RID: 91105 RVA: 0x006B9AE4 File Offset: 0x006B7EE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC45 RID: 64581
		private List<Input> method_p0;

		// Token: 0x0400FC46 RID: 64582
		private bool method_p1;
	}
}
