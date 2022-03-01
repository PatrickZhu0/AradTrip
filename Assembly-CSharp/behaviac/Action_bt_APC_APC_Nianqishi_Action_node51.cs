using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DDE RID: 7646
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_node51 : Action
	{
		// Token: 0x06012572 RID: 75122 RVA: 0x0055B10C File Offset: 0x0055950C
		public Action_bt_APC_APC_Nianqishi_Action_node51()
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

		// Token: 0x06012573 RID: 75123 RVA: 0x0055B19C File Offset: 0x0055959C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF62 RID: 48994
		private List<Input> method_p0;

		// Token: 0x0400BF63 RID: 48995
		private bool method_p1;
	}
}
