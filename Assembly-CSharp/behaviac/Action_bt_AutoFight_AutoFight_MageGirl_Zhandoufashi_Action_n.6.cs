using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200271B RID: 10011
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node36 : Action
	{
		// Token: 0x06013778 RID: 79736 RVA: 0x005CCAA8 File Offset: 0x005CAEA8
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node36()
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
			item.skillID = 2304;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013779 RID: 79737 RVA: 0x005CCB38 File Offset: 0x005CAF38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1D1 RID: 53713
		private List<Input> method_p0;

		// Token: 0x0400D1D2 RID: 53714
		private bool method_p1;
	}
}
