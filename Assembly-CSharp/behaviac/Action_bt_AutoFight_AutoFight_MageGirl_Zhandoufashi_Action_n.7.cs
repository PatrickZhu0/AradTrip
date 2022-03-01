using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200271F RID: 10015
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node46 : Action
	{
		// Token: 0x06013780 RID: 79744 RVA: 0x005CCC5C File Offset: 0x005CB05C
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node46()
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
			item.skillID = 2309;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013781 RID: 79745 RVA: 0x005CCCEC File Offset: 0x005CB0EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1D9 RID: 53721
		private List<Input> method_p0;

		// Token: 0x0400D1DA RID: 53722
		private bool method_p1;
	}
}
