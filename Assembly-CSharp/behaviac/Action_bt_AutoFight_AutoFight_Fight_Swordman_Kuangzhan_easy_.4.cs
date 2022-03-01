using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002316 RID: 8982
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node28 : Action
	{
		// Token: 0x06012FA0 RID: 77728 RVA: 0x0059C390 File Offset: 0x0059A790
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1514;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 400;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1514;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06012FA1 RID: 77729 RVA: 0x0059C47C File Offset: 0x0059A87C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9B7 RID: 51639
		private List<Input> method_p0;

		// Token: 0x0400C9B8 RID: 51640
		private bool method_p1;
	}
}
