using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002380 RID: 9088
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node41 : Action
	{
		// Token: 0x06013067 RID: 77927 RVA: 0x005A0D58 File Offset: 0x0059F158
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node41()
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
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013068 RID: 77928 RVA: 0x005A0DE8 File Offset: 0x0059F1E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA7C RID: 51836
		private List<Input> method_p0;

		// Token: 0x0400CA7D RID: 51837
		private bool method_p1;
	}
}
