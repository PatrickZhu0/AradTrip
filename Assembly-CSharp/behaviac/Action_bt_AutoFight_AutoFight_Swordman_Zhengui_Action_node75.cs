using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029A2 RID: 10658
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node75 : Action
	{
		// Token: 0x06013C78 RID: 81016 RVA: 0x005EA784 File Offset: 0x005E8B84
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node75()
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
			item.skillID = 1806;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C79 RID: 81017 RVA: 0x005EA814 File Offset: 0x005E8C14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6E3 RID: 55011
		private List<Input> method_p0;

		// Token: 0x0400D6E4 RID: 55012
		private bool method_p1;
	}
}
