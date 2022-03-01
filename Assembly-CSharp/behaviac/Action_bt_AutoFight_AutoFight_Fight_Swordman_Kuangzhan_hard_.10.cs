using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002391 RID: 9105
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node64 : Action
	{
		// Token: 0x06013089 RID: 77961 RVA: 0x005A1500 File Offset: 0x0059F900
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node64()
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
			item.skillID = 3;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x0601308A RID: 77962 RVA: 0x005A15E4 File Offset: 0x0059F9E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAA1 RID: 51873
		private List<Input> method_p0;

		// Token: 0x0400CAA2 RID: 51874
		private bool method_p1;
	}
}
