using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003613 RID: 13843
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node35 : Action
	{
		// Token: 0x0601544C RID: 87116 RVA: 0x00668FA4 File Offset: 0x006673A4
		public Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node35()
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
			item.skillID = 5442;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601544D RID: 87117 RVA: 0x00669034 File Offset: 0x00667434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE07 RID: 60935
		private List<Input> method_p0;

		// Token: 0x0400EE08 RID: 60936
		private bool method_p1;
	}
}
