using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E24 RID: 15908
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node6 : Action
	{
		// Token: 0x060163CF RID: 91087 RVA: 0x006B94FC File Offset: 0x006B78FC
		public Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node6()
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

		// Token: 0x060163D0 RID: 91088 RVA: 0x006B958C File Offset: 0x006B798C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC36 RID: 64566
		private List<Input> method_p0;

		// Token: 0x0400FC37 RID: 64567
		private bool method_p1;
	}
}
