using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002311 RID: 8977
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node22 : Action
	{
		// Token: 0x06012F97 RID: 77719 RVA: 0x0059C1CC File Offset: 0x0059A5CC
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node22()
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

		// Token: 0x06012F98 RID: 77720 RVA: 0x0059C25C File Offset: 0x0059A65C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9AF RID: 51631
		private List<Input> method_p0;

		// Token: 0x0400C9B0 RID: 51632
		private bool method_p1;
	}
}
