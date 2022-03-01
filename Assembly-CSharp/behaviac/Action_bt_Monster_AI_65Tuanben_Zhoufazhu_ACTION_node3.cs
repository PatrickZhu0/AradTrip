using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F25 RID: 12069
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node3 : Action
	{
		// Token: 0x0601471F RID: 83743 RVA: 0x006269A0 File Offset: 0x00624DA0
		public Action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node3()
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
			item.skillID = 21609;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014720 RID: 83744 RVA: 0x00626A30 File Offset: 0x00624E30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E095 RID: 57493
		private List<Input> method_p0;

		// Token: 0x0400E096 RID: 57494
		private bool method_p1;
	}
}
