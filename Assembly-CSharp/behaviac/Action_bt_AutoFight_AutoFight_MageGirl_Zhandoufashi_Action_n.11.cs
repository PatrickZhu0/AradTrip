using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200272F RID: 10031
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node66 : Action
	{
		// Token: 0x060137A0 RID: 79776 RVA: 0x005CD32C File Offset: 0x005CB72C
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node66()
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
			item.skillID = 2312;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137A1 RID: 79777 RVA: 0x005CD3BC File Offset: 0x005CB7BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1F9 RID: 53753
		private List<Input> method_p0;

		// Token: 0x0400D1FA RID: 53754
		private bool method_p1;
	}
}
