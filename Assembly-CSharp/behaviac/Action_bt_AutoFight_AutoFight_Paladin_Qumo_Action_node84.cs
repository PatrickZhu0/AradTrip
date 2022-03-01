using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027F6 RID: 10230
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node84 : Action
	{
		// Token: 0x0601392B RID: 80171 RVA: 0x005D5C90 File Offset: 0x005D4090
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node84()
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
			item.skillID = 3505;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601392C RID: 80172 RVA: 0x005D5D20 File Offset: 0x005D4120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D389 RID: 54153
		private List<Input> method_p0;

		// Token: 0x0400D38A RID: 54154
		private bool method_p1;
	}
}
