using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E93 RID: 7827
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_node91 : Action
	{
		// Token: 0x060126D0 RID: 75472 RVA: 0x00563704 File Offset: 0x00561B04
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_node91()
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
			item.skillID = 9741;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060126D1 RID: 75473 RVA: 0x00563794 File Offset: 0x00561B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0BD RID: 49341
		private List<Input> method_p0;

		// Token: 0x0400C0BE RID: 49342
		private bool method_p1;
	}
}
