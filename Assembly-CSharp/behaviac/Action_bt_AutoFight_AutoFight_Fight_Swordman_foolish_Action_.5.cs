using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002291 RID: 8849
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node28 : Action
	{
		// Token: 0x06012EA2 RID: 77474 RVA: 0x00594324 File Offset: 0x00592724
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node28()
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

		// Token: 0x06012EA3 RID: 77475 RVA: 0x005943B4 File Offset: 0x005927B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8AD RID: 51373
		private List<Input> method_p0;

		// Token: 0x0400C8AE RID: 51374
		private bool method_p1;
	}
}
