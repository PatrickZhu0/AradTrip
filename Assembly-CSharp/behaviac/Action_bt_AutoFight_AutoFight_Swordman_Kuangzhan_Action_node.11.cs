using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200296B RID: 10603
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node22 : Action
	{
		// Token: 0x06013C0B RID: 80907 RVA: 0x005E7BD0 File Offset: 0x005E5FD0
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node22()
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
			item.skillID = 1606;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C0C RID: 80908 RVA: 0x005E7C60 File Offset: 0x005E6060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D670 RID: 54896
		private List<Input> method_p0;

		// Token: 0x0400D671 RID: 54897
		private bool method_p1;
	}
}
