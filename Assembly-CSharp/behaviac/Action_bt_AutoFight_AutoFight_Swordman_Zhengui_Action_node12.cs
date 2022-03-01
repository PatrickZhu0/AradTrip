using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002994 RID: 10644
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node121 : Action
	{
		// Token: 0x06013C5C RID: 80988 RVA: 0x005EA0BC File Offset: 0x005E84BC
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node121()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 3;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1801;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 600;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1802;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 600;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 1803;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			this.method_p1 = false;
		}

		// Token: 0x06013C5D RID: 80989 RVA: 0x005EA204 File Offset: 0x005E8604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6C6 RID: 54982
		private List<Input> method_p0;

		// Token: 0x0400D6C7 RID: 54983
		private bool method_p1;
	}
}
