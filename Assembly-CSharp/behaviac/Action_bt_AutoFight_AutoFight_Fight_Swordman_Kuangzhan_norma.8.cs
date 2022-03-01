using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002401 RID: 9217
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node51 : Action
	{
		// Token: 0x06013161 RID: 78177 RVA: 0x005A846C File Offset: 0x005A686C
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node51()
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

		// Token: 0x06013162 RID: 78178 RVA: 0x005A84FC File Offset: 0x005A68FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB8C RID: 52108
		private List<Input> method_p0;

		// Token: 0x0400CB8D RID: 52109
		private bool method_p1;
	}
}
