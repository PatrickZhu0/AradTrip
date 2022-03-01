using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004081 RID: 16513
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node20 : Action
	{
		// Token: 0x0601685F RID: 92255 RVA: 0x006D19A0 File Offset: 0x006CFDA0
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node20()
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
			item.skillID = 5353;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016860 RID: 92256 RVA: 0x006D1A30 File Offset: 0x006CFE30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100A9 RID: 65705
		private List<Input> method_p0;

		// Token: 0x040100AA RID: 65706
		private bool method_p1;
	}
}
