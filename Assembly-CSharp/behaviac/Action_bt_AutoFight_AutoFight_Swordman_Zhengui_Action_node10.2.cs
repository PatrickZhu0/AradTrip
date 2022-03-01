using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029B8 RID: 10680
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node100 : Action
	{
		// Token: 0x06013CA4 RID: 81060 RVA: 0x005EB0C4 File Offset: 0x005E94C4
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node100()
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
			item.skillID = 1808;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013CA5 RID: 81061 RVA: 0x005EB154 File Offset: 0x005E9554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D711 RID: 55057
		private List<Input> method_p0;

		// Token: 0x0400D712 RID: 55058
		private bool method_p1;
	}
}
