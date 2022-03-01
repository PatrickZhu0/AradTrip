using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002460 RID: 9312
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node22 : Action
	{
		// Token: 0x06013211 RID: 78353 RVA: 0x005AD1B4 File Offset: 0x005AB5B4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node22()
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
			item.skillID = 1505;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013212 RID: 78354 RVA: 0x005AD244 File Offset: 0x005AB644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC35 RID: 52277
		private List<Input> method_p0;

		// Token: 0x0400CC36 RID: 52278
		private bool method_p1;
	}
}
