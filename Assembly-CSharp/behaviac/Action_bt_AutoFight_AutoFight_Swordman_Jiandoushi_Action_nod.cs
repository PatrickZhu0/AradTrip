using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028E4 RID: 10468
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node8 : Action
	{
		// Token: 0x06013B00 RID: 80640 RVA: 0x005E1FC4 File Offset: 0x005E03C4
		public Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node8()
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
			item.skillID = 4014;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B01 RID: 80641 RVA: 0x005E2054 File Offset: 0x005E0454
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D563 RID: 54627
		private List<Input> method_p0;

		// Token: 0x0400D564 RID: 54628
		private bool method_p1;
	}
}
