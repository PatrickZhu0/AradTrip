using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D94 RID: 7572
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node17 : Action
	{
		// Token: 0x060124E2 RID: 74978 RVA: 0x00557CA8 File Offset: 0x005560A8
		public Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node17()
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

		// Token: 0x060124E3 RID: 74979 RVA: 0x00557D38 File Offset: 0x00556138
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BECB RID: 48843
		private List<Input> method_p0;

		// Token: 0x0400BECC RID: 48844
		private bool method_p1;
	}
}
