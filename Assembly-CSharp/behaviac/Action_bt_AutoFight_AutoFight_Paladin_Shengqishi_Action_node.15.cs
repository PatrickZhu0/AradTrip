using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200284E RID: 10318
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node84 : Action
	{
		// Token: 0x060139DA RID: 80346 RVA: 0x005D9DAC File Offset: 0x005D81AC
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node84()
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

		// Token: 0x060139DB RID: 80347 RVA: 0x005D9E3C File Offset: 0x005D823C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D432 RID: 54322
		private List<Input> method_p0;

		// Token: 0x0400D433 RID: 54323
		private bool method_p1;
	}
}
