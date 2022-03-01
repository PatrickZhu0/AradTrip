using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F15 RID: 12053
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2 : Action
	{
		// Token: 0x06014701 RID: 83713 RVA: 0x00625BD4 File Offset: 0x00623FD4
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2()
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
			item.skillID = 21612;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014702 RID: 83714 RVA: 0x00625C64 File Offset: 0x00624064
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E079 RID: 57465
		private List<Input> method_p0;

		// Token: 0x0400E07A RID: 57466
		private bool method_p1;
	}
}
