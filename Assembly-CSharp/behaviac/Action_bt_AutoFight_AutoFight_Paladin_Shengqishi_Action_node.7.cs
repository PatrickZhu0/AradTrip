using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200282E RID: 10286
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node21 : Action
	{
		// Token: 0x0601399A RID: 80282 RVA: 0x005D900C File Offset: 0x005D740C
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node21()
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
			item.skillID = 3710;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601399B RID: 80283 RVA: 0x005D909C File Offset: 0x005D749C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3F2 RID: 54258
		private List<Input> method_p0;

		// Token: 0x0400D3F3 RID: 54259
		private bool method_p1;
	}
}
