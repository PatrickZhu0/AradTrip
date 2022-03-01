using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200398E RID: 14734
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node2 : Action
	{
		// Token: 0x06015AF1 RID: 88817 RVA: 0x0068CBD0 File Offset: 0x0068AFD0
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node2()
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
			item.skillID = 21039;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015AF2 RID: 88818 RVA: 0x0068CC60 File Offset: 0x0068B060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F48C RID: 62604
		private List<Input> method_p0;

		// Token: 0x0400F48D RID: 62605
		private bool method_p1;
	}
}
