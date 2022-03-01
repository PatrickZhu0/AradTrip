using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E74 RID: 7796
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node17 : Action
	{
		// Token: 0x06012693 RID: 75411 RVA: 0x0056230C File Offset: 0x0056070C
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node17()
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

		// Token: 0x06012694 RID: 75412 RVA: 0x0056239C File Offset: 0x0056079C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C079 RID: 49273
		private List<Input> method_p0;

		// Token: 0x0400C07A RID: 49274
		private bool method_p1;
	}
}
