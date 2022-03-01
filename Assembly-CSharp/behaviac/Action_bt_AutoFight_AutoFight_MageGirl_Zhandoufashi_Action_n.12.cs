using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002733 RID: 10035
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node41 : Action
	{
		// Token: 0x060137A8 RID: 79784 RVA: 0x005CD4E0 File Offset: 0x005CB8E0
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node41()
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
			item.skillID = 2308;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137A9 RID: 79785 RVA: 0x005CD570 File Offset: 0x005CB970
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D201 RID: 53761
		private List<Input> method_p0;

		// Token: 0x0400D202 RID: 53762
		private bool method_p1;
	}
}
