using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004079 RID: 16505
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node11 : Action
	{
		// Token: 0x0601684F RID: 92239 RVA: 0x006D1638 File Offset: 0x006CFA38
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node11()
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

		// Token: 0x06016850 RID: 92240 RVA: 0x006D16C8 File Offset: 0x006CFAC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010099 RID: 65689
		private List<Input> method_p0;

		// Token: 0x0401009A RID: 65690
		private bool method_p1;
	}
}
