using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200231B RID: 8987
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node35 : Action
	{
		// Token: 0x06012FA9 RID: 77737 RVA: 0x0059C5AC File Offset: 0x0059A9AC
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node35()
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
			item.skillID = 1608;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012FAA RID: 77738 RVA: 0x0059C63C File Offset: 0x0059AA3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9BF RID: 51647
		private List<Input> method_p0;

		// Token: 0x0400C9C0 RID: 51648
		private bool method_p1;
	}
}
