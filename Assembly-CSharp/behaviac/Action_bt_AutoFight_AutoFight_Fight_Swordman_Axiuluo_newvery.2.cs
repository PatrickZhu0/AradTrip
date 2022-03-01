using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200220D RID: 8717
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node18 : Action
	{
		// Token: 0x06012DA4 RID: 77220 RVA: 0x0058CED4 File Offset: 0x0058B2D4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node18()
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
			item.skillID = 1709;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012DA5 RID: 77221 RVA: 0x0058CF64 File Offset: 0x0058B364
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C797 RID: 51095
		private List<Input> method_p0;

		// Token: 0x0400C798 RID: 51096
		private bool method_p1;
	}
}
