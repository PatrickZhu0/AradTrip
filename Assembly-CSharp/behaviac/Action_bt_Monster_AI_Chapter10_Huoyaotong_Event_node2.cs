using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003115 RID: 12565
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2 : Action
	{
		// Token: 0x06014AD3 RID: 84691 RVA: 0x00639FA4 File Offset: 0x006383A4
		public Action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2()
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
			item.skillID = 20717;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014AD4 RID: 84692 RVA: 0x0063A034 File Offset: 0x00638434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E441 RID: 58433
		private List<Input> method_p0;

		// Token: 0x0400E442 RID: 58434
		private bool method_p1;
	}
}
