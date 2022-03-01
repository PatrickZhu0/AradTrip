using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D50 RID: 7504
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Husong_Aganzuo_Action_node5 : Action
	{
		// Token: 0x0601245F RID: 74847 RVA: 0x00554AE4 File Offset: 0x00552EE4
		public Action_bt_APC_APC_Husong_Aganzuo_Action_node5()
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
			item.skillID = 9036;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012460 RID: 74848 RVA: 0x00554B74 File Offset: 0x00552F74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE4D RID: 48717
		private List<Input> method_p0;

		// Token: 0x0400BE4E RID: 48718
		private bool method_p1;
	}
}
