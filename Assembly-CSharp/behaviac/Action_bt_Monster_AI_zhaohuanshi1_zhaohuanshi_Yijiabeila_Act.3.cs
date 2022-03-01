using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020040B2 RID: 16562
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node10 : Action
	{
		// Token: 0x060168BD RID: 92349 RVA: 0x006D3A38 File Offset: 0x006D1E38
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node10()
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
			item.skillID = 5093;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060168BE RID: 92350 RVA: 0x006D3AC8 File Offset: 0x006D1EC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010104 RID: 65796
		private List<Input> method_p0;

		// Token: 0x04010105 RID: 65797
		private bool method_p1;
	}
}
