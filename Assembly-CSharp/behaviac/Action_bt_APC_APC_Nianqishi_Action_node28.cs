using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DE6 RID: 7654
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_node28 : Action
	{
		// Token: 0x06012582 RID: 75138 RVA: 0x0055B470 File Offset: 0x00559870
		public Action_bt_APC_APC_Nianqishi_Action_node28()
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

		// Token: 0x06012583 RID: 75139 RVA: 0x0055B500 File Offset: 0x00559900
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF72 RID: 49010
		private List<Input> method_p0;

		// Token: 0x0400BF73 RID: 49011
		private bool method_p1;
	}
}
