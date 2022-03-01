using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029C1 RID: 10689
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node46 : Action
	{
		// Token: 0x06013CB6 RID: 81078 RVA: 0x005EB48C File Offset: 0x005E988C
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node46()
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
			item.skillID = 1716;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013CB7 RID: 81079 RVA: 0x005EB51C File Offset: 0x005E991C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D724 RID: 55076
		private List<Input> method_p0;

		// Token: 0x0400D725 RID: 55077
		private bool method_p1;
	}
}
