using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200246A RID: 9322
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node41 : Action
	{
		// Token: 0x06013224 RID: 78372 RVA: 0x005AD5E8 File Offset: 0x005AB9E8
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node41()
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
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013225 RID: 78373 RVA: 0x005AD678 File Offset: 0x005ABA78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC48 RID: 52296
		private List<Input> method_p0;

		// Token: 0x0400CC49 RID: 52297
		private bool method_p1;
	}
}
