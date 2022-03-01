using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026FD RID: 9981
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node34 : Action
	{
		// Token: 0x0601373D RID: 79677 RVA: 0x005CA6A0 File Offset: 0x005C8AA0
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node34()
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
			item.skillID = 2111;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601373E RID: 79678 RVA: 0x005CA730 File Offset: 0x005C8B30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D193 RID: 53651
		private List<Input> method_p0;

		// Token: 0x0400D194 RID: 53652
		private bool method_p1;
	}
}
