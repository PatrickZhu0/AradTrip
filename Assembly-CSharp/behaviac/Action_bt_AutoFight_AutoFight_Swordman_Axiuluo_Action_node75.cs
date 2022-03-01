using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028B4 RID: 10420
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node75 : Action
	{
		// Token: 0x06013AA2 RID: 80546 RVA: 0x005DF364 File Offset: 0x005DD764
		public Action_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node75()
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
			item.skillID = 1703;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013AA3 RID: 80547 RVA: 0x005DF3F4 File Offset: 0x005DD7F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4FE RID: 54526
		private List<Input> method_p0;

		// Token: 0x0400D4FF RID: 54527
		private bool method_p1;
	}
}
