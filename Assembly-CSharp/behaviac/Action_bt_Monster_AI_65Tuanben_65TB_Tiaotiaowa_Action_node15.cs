using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CE4 RID: 11492
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node15 : Action
	{
		// Token: 0x060142B8 RID: 82616 RVA: 0x0060EC04 File Offset: 0x0060D004
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node15()
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
			item.skillID = 20745;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060142B9 RID: 82617 RVA: 0x0060EC94 File Offset: 0x0060D094
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC67 RID: 56423
		private List<Input> method_p0;

		// Token: 0x0400DC68 RID: 56424
		private bool method_p1;
	}
}
