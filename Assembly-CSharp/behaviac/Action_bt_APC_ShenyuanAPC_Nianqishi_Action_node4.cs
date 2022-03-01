using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EC1 RID: 7873
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node4 : Action
	{
		// Token: 0x0601272A RID: 75562 RVA: 0x00565248 File Offset: 0x00563648
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node4()
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
			item.skillID = 9706;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601272B RID: 75563 RVA: 0x005652D8 File Offset: 0x005636D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C119 RID: 49433
		private List<Input> method_p0;

		// Token: 0x0400C11A RID: 49434
		private bool method_p1;
	}
}
