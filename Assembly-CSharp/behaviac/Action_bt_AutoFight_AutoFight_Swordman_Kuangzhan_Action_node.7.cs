using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200295E RID: 10590
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node14 : Action
	{
		// Token: 0x06013BF1 RID: 80881 RVA: 0x005E7620 File Offset: 0x005E5A20
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1503;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 600;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1509;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013BF2 RID: 80882 RVA: 0x005E770C File Offset: 0x005E5B0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D656 RID: 54870
		private List<Input> method_p0;

		// Token: 0x0400D657 RID: 54871
		private bool method_p1;
	}
}
