using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002341 RID: 9025
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node22 : Action
	{
		// Token: 0x06012FF1 RID: 77809 RVA: 0x0059E498 File Offset: 0x0059C898
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node22()
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

		// Token: 0x06012FF2 RID: 77810 RVA: 0x0059E528 File Offset: 0x0059C928
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA08 RID: 51720
		private List<Input> method_p0;

		// Token: 0x0400CA09 RID: 51721
		private bool method_p1;
	}
}
