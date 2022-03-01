using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029AA RID: 10666
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node89 : Action
	{
		// Token: 0x06013C88 RID: 81032 RVA: 0x005EAAE8 File Offset: 0x005E8EE8
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node89()
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
			item.skillID = 1807;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C89 RID: 81033 RVA: 0x005EAB78 File Offset: 0x005E8F78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6F3 RID: 55027
		private List<Input> method_p0;

		// Token: 0x0400D6F4 RID: 55028
		private bool method_p1;
	}
}
