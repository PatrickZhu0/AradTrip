using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200280A RID: 10250
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node99 : Action
	{
		// Token: 0x06013953 RID: 80211 RVA: 0x005D6514 File Offset: 0x005D4914
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node99()
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
			item.skillID = 3506;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013954 RID: 80212 RVA: 0x005D65A4 File Offset: 0x005D49A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3B1 RID: 54193
		private List<Input> method_p0;

		// Token: 0x0400D3B2 RID: 54194
		private bool method_p1;
	}
}
