using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E63 RID: 15971
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node6 : Action
	{
		// Token: 0x06016449 RID: 91209 RVA: 0x006BBA58 File Offset: 0x006B9E58
		public Action_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node6()
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
			item.skillID = 7227;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601644A RID: 91210 RVA: 0x006BBAE8 File Offset: 0x006B9EE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC8D RID: 64653
		private List<Input> method_p0;

		// Token: 0x0400FC8E RID: 64654
		private bool method_p1;
	}
}
