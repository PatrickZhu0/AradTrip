using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D57 RID: 7511
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Husong_Aganzuo_Action_node14 : Action
	{
		// Token: 0x0601246D RID: 74861 RVA: 0x00554EBC File Offset: 0x005532BC
		public Action_bt_APC_APC_Husong_Aganzuo_Action_node14()
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

		// Token: 0x0601246E RID: 74862 RVA: 0x00554F4C File Offset: 0x0055334C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE5C RID: 48732
		private List<Input> method_p0;

		// Token: 0x0400BE5D RID: 48733
		private bool method_p1;
	}
}
