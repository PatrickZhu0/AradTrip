using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CF2 RID: 11506
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node41 : Action
	{
		// Token: 0x060142D4 RID: 82644 RVA: 0x0060F104 File Offset: 0x0060D504
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node41()
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
			item.skillID = 20742;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060142D5 RID: 82645 RVA: 0x0060F194 File Offset: 0x0060D594
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC7F RID: 56447
		private List<Input> method_p0;

		// Token: 0x0400DC80 RID: 56448
		private bool method_p1;
	}
}
