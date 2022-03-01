using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CFE RID: 11518
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node56 : Action
	{
		// Token: 0x060142EC RID: 82668 RVA: 0x0060F584 File Offset: 0x0060D984
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node56()
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

		// Token: 0x060142ED RID: 82669 RVA: 0x0060F614 File Offset: 0x0060DA14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC94 RID: 56468
		private List<Input> method_p0;

		// Token: 0x0400DC95 RID: 56469
		private bool method_p1;
	}
}
