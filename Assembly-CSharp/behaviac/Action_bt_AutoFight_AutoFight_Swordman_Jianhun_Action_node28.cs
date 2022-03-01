using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200293D RID: 10557
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node28 : Action
	{
		// Token: 0x06013BB0 RID: 80816 RVA: 0x005E5600 File Offset: 0x005E3A00
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node28()
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
			item.skillID = 1514;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 400;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1514;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013BB1 RID: 80817 RVA: 0x005E56EC File Offset: 0x005E3AEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D615 RID: 54805
		private List<Input> method_p0;

		// Token: 0x0400D616 RID: 54806
		private bool method_p1;
	}
}
