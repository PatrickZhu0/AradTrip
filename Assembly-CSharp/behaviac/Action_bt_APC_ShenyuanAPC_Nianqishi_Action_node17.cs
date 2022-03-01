using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EAC RID: 7852
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node17 : Action
	{
		// Token: 0x06012700 RID: 75520 RVA: 0x00564944 File Offset: 0x00562D44
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node17()
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
			item.skillID = 9705;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012701 RID: 75521 RVA: 0x005649D4 File Offset: 0x00562DD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0EC RID: 49388
		private List<Input> method_p0;

		// Token: 0x0400C0ED RID: 49389
		private bool method_p1;
	}
}
