using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CAC RID: 11436
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node11 : Action
	{
		// Token: 0x0601424D RID: 82509 RVA: 0x0060CD00 File Offset: 0x0060B100
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node11()
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
			item.skillID = 20756;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601424E RID: 82510 RVA: 0x0060CD90 File Offset: 0x0060B190
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC05 RID: 56325
		private List<Input> method_p0;

		// Token: 0x0400DC06 RID: 56326
		private bool method_p1;
	}
}
