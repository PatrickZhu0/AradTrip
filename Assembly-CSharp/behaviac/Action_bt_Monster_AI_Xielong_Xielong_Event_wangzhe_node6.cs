using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E51 RID: 15953
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node6 : Action
	{
		// Token: 0x06016426 RID: 91174 RVA: 0x006BAFAC File Offset: 0x006B93AC
		public Action_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node6()
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
			item.skillID = 7228;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016427 RID: 91175 RVA: 0x006BB03C File Offset: 0x006B943C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC75 RID: 64629
		private List<Input> method_p0;

		// Token: 0x0400FC76 RID: 64630
		private bool method_p1;
	}
}
