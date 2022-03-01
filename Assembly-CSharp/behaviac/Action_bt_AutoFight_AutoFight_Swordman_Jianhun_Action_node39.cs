using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002912 RID: 10514
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node39 : Action
	{
		// Token: 0x06013B5A RID: 80730 RVA: 0x005E3E48 File Offset: 0x005E2248
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node39()
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
			item.skillID = 1521;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B5B RID: 80731 RVA: 0x005E3ED8 File Offset: 0x005E22D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5BE RID: 54718
		private List<Input> method_p0;

		// Token: 0x0400D5BF RID: 54719
		private bool method_p1;
	}
}
