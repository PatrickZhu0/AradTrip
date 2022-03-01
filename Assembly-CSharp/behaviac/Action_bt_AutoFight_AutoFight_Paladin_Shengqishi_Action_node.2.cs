using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200281A RID: 10266
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node59 : Action
	{
		// Token: 0x06013972 RID: 80242 RVA: 0x005D87E8 File Offset: 0x005D6BE8
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node59()
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
			item.skillID = 3709;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013973 RID: 80243 RVA: 0x005D8878 File Offset: 0x005D6C78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3CE RID: 54222
		private List<Input> method_p0;

		// Token: 0x0400D3CF RID: 54223
		private bool method_p1;
	}
}
