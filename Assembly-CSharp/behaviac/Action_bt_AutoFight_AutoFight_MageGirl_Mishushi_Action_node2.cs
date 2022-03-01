using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026F9 RID: 9977
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node24 : Action
	{
		// Token: 0x06013735 RID: 79669 RVA: 0x005CA4EC File Offset: 0x005C88EC
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node24()
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

		// Token: 0x06013736 RID: 79670 RVA: 0x005CA57C File Offset: 0x005C897C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D18B RID: 53643
		private List<Input> method_p0;

		// Token: 0x0400D18C RID: 53644
		private bool method_p1;
	}
}
