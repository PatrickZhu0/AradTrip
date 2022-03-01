using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002970 RID: 10608
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node51 : Action
	{
		// Token: 0x06013C15 RID: 80917 RVA: 0x005E7DBC File Offset: 0x005E61BC
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node51()
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
			item.skillID = 1607;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C16 RID: 80918 RVA: 0x005E7E4C File Offset: 0x005E624C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D67A RID: 54906
		private List<Input> method_p0;

		// Token: 0x0400D67B RID: 54907
		private bool method_p1;
	}
}
