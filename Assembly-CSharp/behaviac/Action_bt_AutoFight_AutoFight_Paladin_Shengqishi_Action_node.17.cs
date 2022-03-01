using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002856 RID: 10326
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node94 : Action
	{
		// Token: 0x060139EA RID: 80362 RVA: 0x005DA114 File Offset: 0x005D8514
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node94()
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
			item.skillID = 3507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139EB RID: 80363 RVA: 0x005DA1A4 File Offset: 0x005D85A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D442 RID: 54338
		private List<Input> method_p0;

		// Token: 0x0400D443 RID: 54339
		private bool method_p1;
	}
}
