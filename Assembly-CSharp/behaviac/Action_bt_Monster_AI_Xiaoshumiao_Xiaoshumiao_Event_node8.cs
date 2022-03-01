using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E27 RID: 15911
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node8 : Action
	{
		// Token: 0x060163D5 RID: 91093 RVA: 0x006B9650 File Offset: 0x006B7A50
		public Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node8()
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
			item.skillID = 7244;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163D6 RID: 91094 RVA: 0x006B96E0 File Offset: 0x006B7AE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC3C RID: 64572
		private List<Input> method_p0;

		// Token: 0x0400FC3D RID: 64573
		private bool method_p1;
	}
}
