using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200290E RID: 10510
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node60 : Action
	{
		// Token: 0x06013B52 RID: 80722 RVA: 0x005E3C98 File Offset: 0x005E2098
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node60()
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
			item.skillID = 1906;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B53 RID: 80723 RVA: 0x005E3D28 File Offset: 0x005E2128
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5B6 RID: 54710
		private List<Input> method_p0;

		// Token: 0x0400D5B7 RID: 54711
		private bool method_p1;
	}
}
