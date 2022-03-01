using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027DE RID: 10206
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node54 : Action
	{
		// Token: 0x060138FB RID: 80123 RVA: 0x005D5258 File Offset: 0x005D3658
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node54()
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
			item.skillID = 3610;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138FC RID: 80124 RVA: 0x005D52E8 File Offset: 0x005D36E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D359 RID: 54105
		private List<Input> method_p0;

		// Token: 0x0400D35A RID: 54106
		private bool method_p1;
	}
}
