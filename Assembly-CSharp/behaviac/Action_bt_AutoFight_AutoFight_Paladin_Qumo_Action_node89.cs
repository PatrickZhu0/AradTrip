using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027FA RID: 10234
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node89 : Action
	{
		// Token: 0x06013933 RID: 80179 RVA: 0x005D5E44 File Offset: 0x005D4244
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node89()
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
			item.skillID = 3504;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013934 RID: 80180 RVA: 0x005D5ED4 File Offset: 0x005D42D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D391 RID: 54161
		private List<Input> method_p0;

		// Token: 0x0400D392 RID: 54162
		private bool method_p1;
	}
}
