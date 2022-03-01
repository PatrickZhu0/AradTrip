using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002832 RID: 10290
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node6 : Action
	{
		// Token: 0x060139A2 RID: 80290 RVA: 0x005D91C0 File Offset: 0x005D75C0
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node6()
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
			item.skillID = 3702;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139A3 RID: 80291 RVA: 0x005D9250 File Offset: 0x005D7650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3FA RID: 54266
		private List<Input> method_p0;

		// Token: 0x0400D3FB RID: 54267
		private bool method_p1;
	}
}
