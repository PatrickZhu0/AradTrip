using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004096 RID: 16534
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node7 : Action
	{
		// Token: 0x06016887 RID: 92295 RVA: 0x006D296C File Offset: 0x006D0D6C
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node7()
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

		// Token: 0x06016888 RID: 92296 RVA: 0x006D29FC File Offset: 0x006D0DFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100D0 RID: 65744
		private List<Input> method_p0;

		// Token: 0x040100D1 RID: 65745
		private bool method_p1;
	}
}
