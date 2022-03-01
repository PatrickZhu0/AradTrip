using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036AE RID: 13998
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node10 : Action
	{
		// Token: 0x06015576 RID: 87414 RVA: 0x006700B0 File Offset: 0x0066E4B0
		public Action_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node10()
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
			item.skillID = 5422;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015577 RID: 87415 RVA: 0x00670140 File Offset: 0x0066E540
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF4A RID: 61258
		private List<Input> method_p0;

		// Token: 0x0400EF4B RID: 61259
		private bool method_p1;
	}
}
