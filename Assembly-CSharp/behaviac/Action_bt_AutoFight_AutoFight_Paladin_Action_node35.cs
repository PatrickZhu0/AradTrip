using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027AA RID: 10154
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node35 : Action
	{
		// Token: 0x06013894 RID: 80020 RVA: 0x005D2EEC File Offset: 0x005D12EC
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node35()
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
			item.skillID = 3511;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013895 RID: 80021 RVA: 0x005D2F7C File Offset: 0x005D137C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2F3 RID: 54003
		private List<Input> method_p0;

		// Token: 0x0400D2F4 RID: 54004
		private bool method_p1;
	}
}
