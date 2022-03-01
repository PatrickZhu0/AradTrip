using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003F9C RID: 16284
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node23 : Action
	{
		// Token: 0x060166A2 RID: 91810 RVA: 0x006C7CBC File Offset: 0x006C60BC
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node23()
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
			item.skillID = 5108;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060166A3 RID: 91811 RVA: 0x006C7D4C File Offset: 0x006C614C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEF5 RID: 65269
		private List<Input> method_p0;

		// Token: 0x0400FEF6 RID: 65270
		private bool method_p1;
	}
}
