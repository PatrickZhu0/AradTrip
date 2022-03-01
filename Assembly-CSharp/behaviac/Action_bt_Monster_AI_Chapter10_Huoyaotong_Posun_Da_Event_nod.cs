using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003119 RID: 12569
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Da_Event_node2 : Action
	{
		// Token: 0x06014ADA RID: 84698 RVA: 0x0063A1F4 File Offset: 0x006385F4
		public Action_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Da_Event_node2()
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
			item.skillID = 20720;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014ADB RID: 84699 RVA: 0x0063A284 File Offset: 0x00638684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E447 RID: 58439
		private List<Input> method_p0;

		// Token: 0x0400E448 RID: 58440
		private bool method_p1;
	}
}
