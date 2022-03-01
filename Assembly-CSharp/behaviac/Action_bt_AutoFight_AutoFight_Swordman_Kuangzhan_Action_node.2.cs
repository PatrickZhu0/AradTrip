using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200294A RID: 10570
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node25 : Action
	{
		// Token: 0x06013BC9 RID: 80841 RVA: 0x005E6D48 File Offset: 0x005E5148
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node25()
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
			item.skillID = 1612;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013BCA RID: 80842 RVA: 0x005E6DD8 File Offset: 0x005E51D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D62E RID: 54830
		private List<Input> method_p0;

		// Token: 0x0400D62F RID: 54831
		private bool method_p1;
	}
}
