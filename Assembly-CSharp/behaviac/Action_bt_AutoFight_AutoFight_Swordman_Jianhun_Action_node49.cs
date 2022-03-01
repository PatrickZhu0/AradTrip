using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002935 RID: 10549
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node49 : Action
	{
		// Token: 0x06013BA0 RID: 80800 RVA: 0x005E5140 File Offset: 0x005E3540
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node49()
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
			item.skillID = 1918;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013BA1 RID: 80801 RVA: 0x005E51D0 File Offset: 0x005E35D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D605 RID: 54789
		private List<Input> method_p0;

		// Token: 0x0400D606 RID: 54790
		private bool method_p1;
	}
}
