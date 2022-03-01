using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E5C RID: 15964
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node17 : Action
	{
		// Token: 0x0601643C RID: 91196 RVA: 0x006BB374 File Offset: 0x006B9774
		public Action_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node17()
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

		// Token: 0x0601643D RID: 91197 RVA: 0x006BB404 File Offset: 0x006B9804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC84 RID: 64644
		private List<Input> method_p0;

		// Token: 0x0400FC85 RID: 64645
		private bool method_p1;
	}
}
