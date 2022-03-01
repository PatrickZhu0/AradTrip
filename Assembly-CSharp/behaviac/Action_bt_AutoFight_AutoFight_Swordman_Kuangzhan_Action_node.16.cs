using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200297C RID: 10620
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node16 : Action
	{
		// Token: 0x06013C2D RID: 80941 RVA: 0x005E8424 File Offset: 0x005E6824
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 4;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1600;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 350;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1601;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 350;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 1602;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			Input item4 = default(Input);
			item4.delay = 350;
			item4.moveInSkillState = false;
			item4.moveKeepDistance = 0;
			item4.PKRobotComboCheck = false;
			item4.pressTime = 0;
			item4.randomChangeDirection = false;
			item4.skillID = 1603;
			item4.specialChoice = 0;
			this.method_p0.Add(item4);
			this.method_p1 = false;
		}

		// Token: 0x06013C2E RID: 80942 RVA: 0x005E85C8 File Offset: 0x005E69C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D696 RID: 54934
		private List<Input> method_p0;

		// Token: 0x0400D697 RID: 54935
		private bool method_p1;
	}
}
