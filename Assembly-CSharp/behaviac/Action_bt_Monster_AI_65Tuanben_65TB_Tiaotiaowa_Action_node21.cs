using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CEC RID: 11500
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node21 : Action
	{
		// Token: 0x060142C8 RID: 82632 RVA: 0x0060EF04 File Offset: 0x0060D304
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node21()
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
			item.skillID = 20748;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060142C9 RID: 82633 RVA: 0x0060EF94 File Offset: 0x0060D394
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC75 RID: 56437
		private List<Input> method_p0;

		// Token: 0x0400DC76 RID: 56438
		private bool method_p1;
	}
}
