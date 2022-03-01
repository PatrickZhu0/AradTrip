using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002278 RID: 8824
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node28 : Action
	{
		// Token: 0x06012E74 RID: 77428 RVA: 0x005930BC File Offset: 0x005914BC
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node28()
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
			item.skillID = 1510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012E75 RID: 77429 RVA: 0x0059314C File Offset: 0x0059154C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C880 RID: 51328
		private List<Input> method_p0;

		// Token: 0x0400C881 RID: 51329
		private bool method_p1;
	}
}
