using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027C6 RID: 10182
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node69 : Action
	{
		// Token: 0x060138CB RID: 80075 RVA: 0x005D4820 File Offset: 0x005D2C20
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node69()
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
			item.skillID = 3614;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138CC RID: 80076 RVA: 0x005D48B0 File Offset: 0x005D2CB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D329 RID: 54057
		private List<Input> method_p0;

		// Token: 0x0400D32A RID: 54058
		private bool method_p1;
	}
}
