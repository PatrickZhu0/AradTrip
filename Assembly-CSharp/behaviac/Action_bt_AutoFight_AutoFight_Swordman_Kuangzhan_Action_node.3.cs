using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200294E RID: 10574
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node41 : Action
	{
		// Token: 0x06013BD1 RID: 80849 RVA: 0x005E6EFC File Offset: 0x005E52FC
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node41()
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
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013BD2 RID: 80850 RVA: 0x005E6F8C File Offset: 0x005E538C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D636 RID: 54838
		private List<Input> method_p0;

		// Token: 0x0400D637 RID: 54839
		private bool method_p1;
	}
}
