using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027F2 RID: 10226
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node74 : Action
	{
		// Token: 0x06013923 RID: 80163 RVA: 0x005D5ADC File Offset: 0x005D3EDC
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node74()
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
			item.skillID = 3604;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013924 RID: 80164 RVA: 0x005D5B6C File Offset: 0x005D3F6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D381 RID: 54145
		private List<Input> method_p0;

		// Token: 0x0400D382 RID: 54146
		private bool method_p1;
	}
}
