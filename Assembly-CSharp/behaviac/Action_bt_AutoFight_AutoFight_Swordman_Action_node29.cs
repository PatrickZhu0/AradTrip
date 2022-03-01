using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200287B RID: 10363
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Action_node29 : Action
	{
		// Token: 0x06013A33 RID: 80435 RVA: 0x005DCC0C File Offset: 0x005DB00C
		public Action_bt_AutoFight_AutoFight_Swordman_Action_node29()
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
			item.skillID = 1701;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013A34 RID: 80436 RVA: 0x005DCC9C File Offset: 0x005DB09C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D48C RID: 54412
		private List<Input> method_p0;

		// Token: 0x0400D48D RID: 54413
		private bool method_p1;
	}
}
