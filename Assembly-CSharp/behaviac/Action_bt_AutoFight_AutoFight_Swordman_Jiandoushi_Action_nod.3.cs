using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028EC RID: 10476
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node41 : Action
	{
		// Token: 0x06013B0F RID: 80655 RVA: 0x005E22DC File Offset: 0x005E06DC
		public Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node41()
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
			item.skillID = 4005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B10 RID: 80656 RVA: 0x005E236C File Offset: 0x005E076C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D571 RID: 54641
		private List<Input> method_p0;

		// Token: 0x0400D572 RID: 54642
		private bool method_p1;
	}
}
