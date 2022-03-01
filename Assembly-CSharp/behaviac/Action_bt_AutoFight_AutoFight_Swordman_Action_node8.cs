using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200286F RID: 10351
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Action_node8 : Action
	{
		// Token: 0x06013A1B RID: 80411 RVA: 0x005DC694 File Offset: 0x005DAA94
		public Action_bt_AutoFight_AutoFight_Swordman_Action_node8()
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
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013A1C RID: 80412 RVA: 0x005DC724 File Offset: 0x005DAB24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D474 RID: 54388
		private List<Input> method_p0;

		// Token: 0x0400D475 RID: 54389
		private bool method_p1;
	}
}
