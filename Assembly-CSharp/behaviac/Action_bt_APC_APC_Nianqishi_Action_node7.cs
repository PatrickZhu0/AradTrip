using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DEA RID: 7658
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_node7 : Action
	{
		// Token: 0x0601258A RID: 75146 RVA: 0x0055B644 File Offset: 0x00559A44
		public Action_bt_APC_APC_Nianqishi_Action_node7()
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

		// Token: 0x0601258B RID: 75147 RVA: 0x0055B6D4 File Offset: 0x00559AD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF7C RID: 49020
		private List<Input> method_p0;

		// Token: 0x0400BF7D RID: 49021
		private bool method_p1;
	}
}
