using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002743 RID: 10051
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node22 : Action
	{
		// Token: 0x060137C8 RID: 79816 RVA: 0x005CDBB0 File Offset: 0x005CBFB0
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node22()
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
			item.skillID = 2010;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137C9 RID: 79817 RVA: 0x005CDC40 File Offset: 0x005CC040
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D221 RID: 53793
		private List<Input> method_p0;

		// Token: 0x0400D222 RID: 53794
		private bool method_p1;
	}
}
