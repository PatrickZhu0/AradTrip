using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200211D RID: 8477
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node35 : Action
	{
		// Token: 0x06012BCD RID: 76749 RVA: 0x0058153C File Offset: 0x0057F93C
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node35()
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
			item.skillID = 1009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012BCE RID: 76750 RVA: 0x005815CC File Offset: 0x0057F9CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5C0 RID: 50624
		private List<Input> method_p0;

		// Token: 0x0400C5C1 RID: 50625
		private bool method_p1;
	}
}
