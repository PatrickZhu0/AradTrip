using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020040AA RID: 16554
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node5 : Action
	{
		// Token: 0x060168AD RID: 92333 RVA: 0x006D36D0 File Offset: 0x006D1AD0
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node5()
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

		// Token: 0x060168AE RID: 92334 RVA: 0x006D3760 File Offset: 0x006D1B60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100F4 RID: 65780
		private List<Input> method_p0;

		// Token: 0x040100F5 RID: 65781
		private bool method_p1;
	}
}
