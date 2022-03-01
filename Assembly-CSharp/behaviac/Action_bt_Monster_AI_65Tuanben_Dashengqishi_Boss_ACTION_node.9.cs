using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DA3 RID: 11683
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node41 : Action
	{
		// Token: 0x06014427 RID: 82983 RVA: 0x00615EF4 File Offset: 0x006142F4
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node41()
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
			item.skillID = 21645;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014428 RID: 82984 RVA: 0x00615F84 File Offset: 0x00614384
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDED RID: 56813
		private List<Input> method_p0;

		// Token: 0x0400DDEE RID: 56814
		private bool method_p1;
	}
}
