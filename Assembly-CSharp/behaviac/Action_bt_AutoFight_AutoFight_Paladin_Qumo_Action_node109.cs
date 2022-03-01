using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002806 RID: 10246
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node109 : Action
	{
		// Token: 0x0601394B RID: 80203 RVA: 0x005D6360 File Offset: 0x005D4760
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node109()
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

		// Token: 0x0601394C RID: 80204 RVA: 0x005D63F0 File Offset: 0x005D47F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3A9 RID: 54185
		private List<Input> method_p0;

		// Token: 0x0400D3AA RID: 54186
		private bool method_p1;
	}
}
