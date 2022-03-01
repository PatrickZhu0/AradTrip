using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026D4 RID: 9940
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node91 : Action
	{
		// Token: 0x060136EB RID: 79595 RVA: 0x005C9560 File Offset: 0x005C7960
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node91()
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
			item.skillID = 2210;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060136EC RID: 79596 RVA: 0x005C95F0 File Offset: 0x005C79F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D141 RID: 53569
		private List<Input> method_p0;

		// Token: 0x0400D142 RID: 53570
		private bool method_p1;
	}
}
