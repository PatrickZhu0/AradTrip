using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CDC RID: 11484
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node1 : Action
	{
		// Token: 0x060142A8 RID: 82600 RVA: 0x0060E904 File Offset: 0x0060CD04
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node1()
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

		// Token: 0x060142A9 RID: 82601 RVA: 0x0060E994 File Offset: 0x0060CD94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC59 RID: 56409
		private List<Input> method_p0;

		// Token: 0x0400DC5A RID: 56410
		private bool method_p1;
	}
}
