using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020030D0 RID: 12496
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node3 : Action
	{
		// Token: 0x06014A59 RID: 84569 RVA: 0x00637A18 File Offset: 0x00635E18
		public Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node3()
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
			item.skillID = 20644;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014A5A RID: 84570 RVA: 0x00637AA8 File Offset: 0x00635EA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3C0 RID: 58304
		private List<Input> method_p0;

		// Token: 0x0400E3C1 RID: 58305
		private bool method_p1;
	}
}
