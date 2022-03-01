using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FED RID: 16365
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node7 : Action
	{
		// Token: 0x06016740 RID: 91968 RVA: 0x006CB790 File Offset: 0x006C9B90
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node7()
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
			item.skillID = 5354;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016741 RID: 91969 RVA: 0x006CB820 File Offset: 0x006C9C20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF91 RID: 65425
		private List<Input> method_p0;

		// Token: 0x0400FF92 RID: 65426
		private bool method_p1;
	}
}
