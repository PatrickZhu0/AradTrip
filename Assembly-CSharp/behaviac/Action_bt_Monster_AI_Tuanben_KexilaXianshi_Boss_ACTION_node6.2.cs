using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A7C RID: 14972
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node61 : Action
	{
		// Token: 0x06015CC1 RID: 89281 RVA: 0x00694E3C File Offset: 0x0069323C
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node61()
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
			item.skillID = 21052;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015CC2 RID: 89282 RVA: 0x00694ECC File Offset: 0x006932CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5FC RID: 62972
		private List<Input> method_p0;

		// Token: 0x0400F5FD RID: 62973
		private bool method_p1;
	}
}
