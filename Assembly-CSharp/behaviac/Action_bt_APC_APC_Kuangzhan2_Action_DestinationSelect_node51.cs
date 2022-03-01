using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D99 RID: 7577
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node51 : Action
	{
		// Token: 0x060124EC RID: 74988 RVA: 0x00557EB8 File Offset: 0x005562B8
		public Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node51()
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
			item.skillID = 9701;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060124ED RID: 74989 RVA: 0x00557F48 File Offset: 0x00556348
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BED6 RID: 48854
		private List<Input> method_p0;

		// Token: 0x0400BED7 RID: 48855
		private bool method_p1;
	}
}
