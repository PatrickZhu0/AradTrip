using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028F8 RID: 10488
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node75 : Action
	{
		// Token: 0x06013B27 RID: 80679 RVA: 0x005E27F8 File Offset: 0x005E0BF8
		public Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node75()
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
			item.skillID = 4012;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B28 RID: 80680 RVA: 0x005E2888 File Offset: 0x005E0C88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D589 RID: 54665
		private List<Input> method_p0;

		// Token: 0x0400D58A RID: 54666
		private bool method_p1;
	}
}
