using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028FC RID: 10492
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node58 : Action
	{
		// Token: 0x06013B2F RID: 80687 RVA: 0x005E29AC File Offset: 0x005E0DAC
		public Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node58()
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
			item.skillID = 4013;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B30 RID: 80688 RVA: 0x005E2A3C File Offset: 0x005E0E3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D591 RID: 54673
		private List<Input> method_p0;

		// Token: 0x0400D592 RID: 54674
		private bool method_p1;
	}
}
