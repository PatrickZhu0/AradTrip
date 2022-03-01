using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200240E RID: 9230
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node8 : Action
	{
		// Token: 0x06013179 RID: 78201 RVA: 0x005A9830 File Offset: 0x005A7C30
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node8()
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
			item.skillID = 1609;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601317A RID: 78202 RVA: 0x005A98C0 File Offset: 0x005A7CC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBA4 RID: 52132
		private List<Input> method_p0;

		// Token: 0x0400CBA5 RID: 52133
		private bool method_p1;
	}
}
