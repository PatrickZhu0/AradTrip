using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E6E RID: 15982
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node17 : Action
	{
		// Token: 0x0601645F RID: 91231 RVA: 0x006BBE20 File Offset: 0x006BA220
		public Action_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node17()
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

		// Token: 0x06016460 RID: 91232 RVA: 0x006BBEB0 File Offset: 0x006BA2B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC9C RID: 64668
		private List<Input> method_p0;

		// Token: 0x0400FC9D RID: 64669
		private bool method_p1;
	}
}
