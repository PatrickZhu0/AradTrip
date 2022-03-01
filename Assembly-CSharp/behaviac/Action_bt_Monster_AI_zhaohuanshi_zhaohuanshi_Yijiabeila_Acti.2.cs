using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004005 RID: 16389
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node25 : Action
	{
		// Token: 0x0601676E RID: 92014 RVA: 0x006CC6A8 File Offset: 0x006CAAA8
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node25()
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
			item.skillID = 5094;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601676F RID: 92015 RVA: 0x006CC738 File Offset: 0x006CAB38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFBD RID: 65469
		private List<Input> method_p0;

		// Token: 0x0400FFBE RID: 65470
		private bool method_p1;
	}
}
