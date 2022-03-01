using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CF6 RID: 11510
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node46 : Action
	{
		// Token: 0x060142DC RID: 82652 RVA: 0x0060F284 File Offset: 0x0060D684
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node46()
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
			item.skillID = 20743;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060142DD RID: 82653 RVA: 0x0060F314 File Offset: 0x0060D714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC86 RID: 56454
		private List<Input> method_p0;

		// Token: 0x0400DC87 RID: 56455
		private bool method_p1;
	}
}
