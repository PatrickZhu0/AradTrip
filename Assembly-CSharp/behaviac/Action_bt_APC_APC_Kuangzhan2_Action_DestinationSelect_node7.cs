using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DA5 RID: 7589
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node7 : Action
	{
		// Token: 0x06012504 RID: 75012 RVA: 0x005583F0 File Offset: 0x005567F0
		public Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node7()
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
			item.skillID = 9704;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012505 RID: 75013 RVA: 0x00558480 File Offset: 0x00556880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEF0 RID: 48880
		private List<Input> method_p0;

		// Token: 0x0400BEF1 RID: 48881
		private bool method_p1;
	}
}
