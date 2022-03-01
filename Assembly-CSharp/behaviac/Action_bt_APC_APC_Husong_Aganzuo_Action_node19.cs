using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D5B RID: 7515
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Husong_Aganzuo_Action_node19 : Action
	{
		// Token: 0x06012475 RID: 74869 RVA: 0x00555070 File Offset: 0x00553470
		public Action_bt_APC_APC_Husong_Aganzuo_Action_node19()
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
			item.skillID = 1503;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012476 RID: 74870 RVA: 0x00555100 File Offset: 0x00553500
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE64 RID: 48740
		private List<Input> method_p0;

		// Token: 0x0400BE65 RID: 48741
		private bool method_p1;
	}
}
