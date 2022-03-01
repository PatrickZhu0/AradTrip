using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D9D RID: 7581
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node11 : Action
	{
		// Token: 0x060124F4 RID: 74996 RVA: 0x0055806C File Offset: 0x0055646C
		public Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node11()
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

		// Token: 0x060124F5 RID: 74997 RVA: 0x005580FC File Offset: 0x005564FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEDE RID: 48862
		private List<Input> method_p0;

		// Token: 0x0400BEDF RID: 48863
		private bool method_p1;
	}
}
