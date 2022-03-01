using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FA4 RID: 16292
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node33 : Action
	{
		// Token: 0x060166B2 RID: 91826 RVA: 0x006C8024 File Offset: 0x006C6424
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node33()
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
			item.skillID = 5110;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060166B3 RID: 91827 RVA: 0x006C80B4 File Offset: 0x006C64B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF05 RID: 65285
		private List<Input> method_p0;

		// Token: 0x0400FF06 RID: 65286
		private bool method_p1;
	}
}
