using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E1D RID: 15901
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node5 : Action
	{
		// Token: 0x060163C2 RID: 91074 RVA: 0x006B9024 File Offset: 0x006B7424
		public Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node5()
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
			item.skillID = 9757;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163C3 RID: 91075 RVA: 0x006B90B4 File Offset: 0x006B74B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC29 RID: 64553
		private List<Input> method_p0;

		// Token: 0x0400FC2A RID: 64554
		private bool method_p1;
	}
}
