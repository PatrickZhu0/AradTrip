using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003111 RID: 12561
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Huoyaotong_Da_Event_node2 : Action
	{
		// Token: 0x06014ACC RID: 84684 RVA: 0x00639D54 File Offset: 0x00638154
		public Action_bt_Monster_AI_Chapter10_Huoyaotong_Da_Event_node2()
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
			item.skillID = 20718;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014ACD RID: 84685 RVA: 0x00639DE4 File Offset: 0x006381E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E43B RID: 58427
		private List<Input> method_p0;

		// Token: 0x0400E43C RID: 58428
		private bool method_p1;
	}
}
