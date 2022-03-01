using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002842 RID: 10306
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node31 : Action
	{
		// Token: 0x060139C2 RID: 80322 RVA: 0x005D9890 File Offset: 0x005D7C90
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node31()
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
			item.skillID = 3713;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139C3 RID: 80323 RVA: 0x005D9920 File Offset: 0x005D7D20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D41A RID: 54298
		private List<Input> method_p0;

		// Token: 0x0400D41B RID: 54299
		private bool method_p1;
	}
}
