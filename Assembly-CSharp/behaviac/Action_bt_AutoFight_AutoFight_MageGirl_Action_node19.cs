using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200268F RID: 9871
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node19 : Action
	{
		// Token: 0x06013662 RID: 79458 RVA: 0x005C6A68 File Offset: 0x005C4E68
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node19()
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
			item.skillID = 2005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013663 RID: 79459 RVA: 0x005C6AF8 File Offset: 0x005C4EF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0B5 RID: 53429
		private List<Input> method_p0;

		// Token: 0x0400D0B6 RID: 53430
		private bool method_p1;
	}
}
