using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200283E RID: 10302
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node16 : Action
	{
		// Token: 0x060139BA RID: 80314 RVA: 0x005D96DC File Offset: 0x005D7ADC
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node16()
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
			item.skillID = 3707;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139BB RID: 80315 RVA: 0x005D976C File Offset: 0x005D7B6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D412 RID: 54290
		private List<Input> method_p0;

		// Token: 0x0400D413 RID: 54291
		private bool method_p1;
	}
}
