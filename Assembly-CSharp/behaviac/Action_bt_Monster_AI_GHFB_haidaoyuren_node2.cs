using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032C8 RID: 13000
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_haidaoyuren_node2 : Action
	{
		// Token: 0x06014E02 RID: 85506 RVA: 0x00649F18 File Offset: 0x00648318
		public Action_bt_Monster_AI_GHFB_haidaoyuren_node2()
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
			item.skillID = 20166;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014E03 RID: 85507 RVA: 0x00649FA8 File Offset: 0x006483A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6EB RID: 59115
		private List<Input> method_p0;

		// Token: 0x0400E6EC RID: 59116
		private bool method_p1;
	}
}
