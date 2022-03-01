using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020023F3 RID: 9203
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node35 : Action
	{
		// Token: 0x06013145 RID: 78149 RVA: 0x005A7E34 File Offset: 0x005A6234
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node35()
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
			item.skillID = 1608;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013146 RID: 78150 RVA: 0x005A7EC4 File Offset: 0x005A62C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB6E RID: 52078
		private List<Input> method_p0;

		// Token: 0x0400CB6F RID: 52079
		private bool method_p1;
	}
}
