using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FD0 RID: 16336
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11 : Action
	{
		// Token: 0x06016708 RID: 91912 RVA: 0x006CA45C File Offset: 0x006C885C
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11()
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
			item.skillID = 5022;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016709 RID: 91913 RVA: 0x006CA4EC File Offset: 0x006C88EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF5A RID: 65370
		private List<Input> method_p0;

		// Token: 0x0400FF5B RID: 65371
		private bool method_p1;
	}
}
