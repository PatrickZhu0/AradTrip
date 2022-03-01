using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003251 RID: 12881
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node10 : Action
	{
		// Token: 0x06014D22 RID: 85282 RVA: 0x00645CF8 File Offset: 0x006440F8
		public Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node10()
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
			item.skillID = 21503;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014D23 RID: 85283 RVA: 0x00645D88 File Offset: 0x00644188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E66D RID: 58989
		private List<Input> method_p0;

		// Token: 0x0400E66E RID: 58990
		private bool method_p1;
	}
}
