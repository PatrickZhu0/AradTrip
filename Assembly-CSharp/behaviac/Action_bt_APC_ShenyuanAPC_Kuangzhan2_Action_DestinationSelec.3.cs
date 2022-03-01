using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E7D RID: 7805
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node11 : Action
	{
		// Token: 0x060126A5 RID: 75429 RVA: 0x005626D0 File Offset: 0x00560AD0
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node11()
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
			item.skillID = 9703;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060126A6 RID: 75430 RVA: 0x00562760 File Offset: 0x00560B60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C08C RID: 49292
		private List<Input> method_p0;

		// Token: 0x0400C08D RID: 49293
		private bool method_p1;
	}
}
