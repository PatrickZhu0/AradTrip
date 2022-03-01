using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200279A RID: 10138
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node15 : Action
	{
		// Token: 0x06013874 RID: 79988 RVA: 0x005D281C File Offset: 0x005D0C1C
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node15()
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
			item.skillID = 3504;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013875 RID: 79989 RVA: 0x005D28AC File Offset: 0x005D0CAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2D3 RID: 53971
		private List<Input> method_p0;

		// Token: 0x0400D2D4 RID: 53972
		private bool method_p1;
	}
}
