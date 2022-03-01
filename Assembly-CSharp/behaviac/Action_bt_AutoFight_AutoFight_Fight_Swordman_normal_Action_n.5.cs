using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002451 RID: 9297
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node68 : Action
	{
		// Token: 0x060131F6 RID: 78326 RVA: 0x005AC240 File Offset: 0x005AA640
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node68()
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

		// Token: 0x060131F7 RID: 78327 RVA: 0x005AC2D0 File Offset: 0x005AA6D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC1E RID: 52254
		private List<Input> method_p0;

		// Token: 0x0400CC1F RID: 52255
		private bool method_p1;
	}
}
