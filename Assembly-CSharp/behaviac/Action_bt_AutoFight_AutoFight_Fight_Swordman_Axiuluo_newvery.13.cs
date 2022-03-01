using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200223C RID: 8764
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node8 : Action
	{
		// Token: 0x06012E01 RID: 77313 RVA: 0x00590288 File Offset: 0x0058E688
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node8()
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
			item.skillID = 1515;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = true;
		}

		// Token: 0x06012E02 RID: 77314 RVA: 0x00590318 File Offset: 0x0058E718
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7FC RID: 51196
		private List<Input> method_p0;

		// Token: 0x0400C7FD RID: 51197
		private bool method_p1;
	}
}
