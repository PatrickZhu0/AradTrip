using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036B6 RID: 14006
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node20 : Action
	{
		// Token: 0x06015586 RID: 87430 RVA: 0x00670418 File Offset: 0x0066E818
		public Action_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node20()
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
			item.skillID = 5652;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015587 RID: 87431 RVA: 0x006704A8 File Offset: 0x0066E8A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF5A RID: 61274
		private List<Input> method_p0;

		// Token: 0x0400EF5B RID: 61275
		private bool method_p1;
	}
}
