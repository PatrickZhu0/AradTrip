using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020020E5 RID: 8421
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node25 : Action
	{
		// Token: 0x06012B5F RID: 76639 RVA: 0x0057ED34 File Offset: 0x0057D134
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node25()
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
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012B60 RID: 76640 RVA: 0x0057EDC4 File Offset: 0x0057D1C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C552 RID: 50514
		private List<Input> method_p0;

		// Token: 0x0400C553 RID: 50515
		private bool method_p1;
	}
}
