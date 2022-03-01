using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036B2 RID: 14002
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node15 : Action
	{
		// Token: 0x0601557E RID: 87422 RVA: 0x00670264 File Offset: 0x0066E664
		public Action_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node15()
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
			item.skillID = 5423;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601557F RID: 87423 RVA: 0x006702F4 File Offset: 0x0066E6F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF52 RID: 61266
		private List<Input> method_p0;

		// Token: 0x0400EF53 RID: 61267
		private bool method_p1;
	}
}
