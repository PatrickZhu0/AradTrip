using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EB9 RID: 7865
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node28 : Action
	{
		// Token: 0x0601271A RID: 75546 RVA: 0x00564EBC File Offset: 0x005632BC
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node28()
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
			item.skillID = 9702;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601271B RID: 75547 RVA: 0x00564F4C File Offset: 0x0056334C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C107 RID: 49415
		private List<Input> method_p0;

		// Token: 0x0400C108 RID: 49416
		private bool method_p1;
	}
}
