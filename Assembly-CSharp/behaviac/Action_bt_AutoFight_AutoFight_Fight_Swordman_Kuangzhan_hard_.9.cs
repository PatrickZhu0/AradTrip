using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200238E RID: 9102
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node58 : Action
	{
		// Token: 0x06013083 RID: 77955 RVA: 0x005A1390 File Offset: 0x0059F790
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node58()
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

		// Token: 0x06013084 RID: 77956 RVA: 0x005A1420 File Offset: 0x0059F820
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA9A RID: 51866
		private List<Input> method_p0;

		// Token: 0x0400CA9B RID: 51867
		private bool method_p1;
	}
}
