using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028F0 RID: 10480
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node24 : Action
	{
		// Token: 0x06013B17 RID: 80663 RVA: 0x005E2490 File Offset: 0x005E0890
		public Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node24()
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
			item.skillID = 4007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B18 RID: 80664 RVA: 0x005E2520 File Offset: 0x005E0920
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D579 RID: 54649
		private List<Input> method_p0;

		// Token: 0x0400D57A RID: 54650
		private bool method_p1;
	}
}
