using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BC2 RID: 11202
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6 : Action
	{
		// Token: 0x06014088 RID: 82056 RVA: 0x006043E8 File Offset: 0x006027E8
		public Action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6()
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
			item.skillID = 21635;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014089 RID: 82057 RVA: 0x00604478 File Offset: 0x00602878
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA78 RID: 55928
		private List<Input> method_p0;

		// Token: 0x0400DA79 RID: 55929
		private bool method_p1;
	}
}
