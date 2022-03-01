using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004055 RID: 16469
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node43 : Action
	{
		// Token: 0x06016809 RID: 92169 RVA: 0x006CF568 File Offset: 0x006CD968
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node43()
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
			item.skillID = 5109;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601680A RID: 92170 RVA: 0x006CF5F8 File Offset: 0x006CD9F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010054 RID: 65620
		private List<Input> method_p0;

		// Token: 0x04010055 RID: 65621
		private bool method_p1;
	}
}
