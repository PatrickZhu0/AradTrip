using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E17 RID: 7703
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_Action_node6 : Action
	{
		// Token: 0x060125DF RID: 75231 RVA: 0x0055D914 File Offset: 0x0055BD14
		public Action_bt_APC_APC_Tiantangmanbuzhe_Action_node6()
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
			item.skillID = 8012;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060125E0 RID: 75232 RVA: 0x0055D9A4 File Offset: 0x0055BDA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFC8 RID: 49096
		private List<Input> method_p0;

		// Token: 0x0400BFC9 RID: 49097
		private bool method_p1;
	}
}
