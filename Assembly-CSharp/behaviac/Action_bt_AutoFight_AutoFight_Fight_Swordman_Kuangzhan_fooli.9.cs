using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200235E RID: 9054
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node58 : Action
	{
		// Token: 0x06013029 RID: 77865 RVA: 0x0059F0C4 File Offset: 0x0059D4C4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node58()
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
			item.skillID = 1511;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601302A RID: 77866 RVA: 0x0059F154 File Offset: 0x0059D554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA41 RID: 51777
		private List<Input> method_p0;

		// Token: 0x0400CA42 RID: 51778
		private bool method_p1;
	}
}
