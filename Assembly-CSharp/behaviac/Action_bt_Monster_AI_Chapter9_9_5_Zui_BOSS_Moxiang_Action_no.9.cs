using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031B7 RID: 12727
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node37 : Action
	{
		// Token: 0x06014C01 RID: 84993 RVA: 0x0063F904 File Offset: 0x0063DD04
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node37()
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
			item.skillID = 21572;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C02 RID: 84994 RVA: 0x0063F994 File Offset: 0x0063DD94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E562 RID: 58722
		private List<Input> method_p0;

		// Token: 0x0400E563 RID: 58723
		private bool method_p1;
	}
}
