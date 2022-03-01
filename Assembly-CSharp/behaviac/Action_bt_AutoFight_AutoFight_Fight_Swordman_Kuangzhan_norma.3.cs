using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020023E9 RID: 9193
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node22 : Action
	{
		// Token: 0x06013133 RID: 78131 RVA: 0x005A7A54 File Offset: 0x005A5E54
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node22()
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

		// Token: 0x06013134 RID: 78132 RVA: 0x005A7AE4 File Offset: 0x005A5EE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB5E RID: 52062
		private List<Input> method_p0;

		// Token: 0x0400CB5F RID: 52063
		private bool method_p1;
	}
}
