using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E38 RID: 15928
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node17 : Action
	{
		// Token: 0x060163F6 RID: 91126 RVA: 0x006B9E1C File Offset: 0x006B821C
		public Action_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node17()
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

		// Token: 0x060163F7 RID: 91127 RVA: 0x006B9EAC File Offset: 0x006B82AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC54 RID: 64596
		private List<Input> method_p0;

		// Token: 0x0400FC55 RID: 64597
		private bool method_p1;
	}
}
