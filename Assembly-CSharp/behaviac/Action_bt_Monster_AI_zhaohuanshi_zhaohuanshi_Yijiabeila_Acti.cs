using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004001 RID: 16385
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5 : Action
	{
		// Token: 0x06016766 RID: 92006 RVA: 0x006CC4F4 File Offset: 0x006CA8F4
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5()
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
			item.skillID = 5092;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016767 RID: 92007 RVA: 0x006CC584 File Offset: 0x006CA984
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFB5 RID: 65461
		private List<Input> method_p0;

		// Token: 0x0400FFB6 RID: 65462
		private bool method_p1;
	}
}
