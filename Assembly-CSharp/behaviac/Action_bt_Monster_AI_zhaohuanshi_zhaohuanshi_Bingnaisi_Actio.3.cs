using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003F84 RID: 16260
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node17 : Action
	{
		// Token: 0x06016674 RID: 91764 RVA: 0x006C6DA4 File Offset: 0x006C51A4
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node17()
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
			item.skillID = 5355;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016675 RID: 91765 RVA: 0x006C6E34 File Offset: 0x006C5234
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEC9 RID: 65225
		private List<Input> method_p0;

		// Token: 0x0400FECA RID: 65226
		private bool method_p1;
	}
}
