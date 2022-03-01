using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200288B RID: 10379
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Action_node39 : Action
	{
		// Token: 0x06013A53 RID: 80467 RVA: 0x005DD330 File Offset: 0x005DB730
		public Action_bt_AutoFight_AutoFight_Swordman_Action_node39()
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
			item.skillID = 1510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013A54 RID: 80468 RVA: 0x005DD3C0 File Offset: 0x005DB7C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4AC RID: 54444
		private List<Input> method_p0;

		// Token: 0x0400D4AD RID: 54445
		private bool method_p1;
	}
}
