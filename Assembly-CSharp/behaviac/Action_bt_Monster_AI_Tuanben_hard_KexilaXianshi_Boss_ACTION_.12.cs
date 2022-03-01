using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C98 RID: 15512
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node35 : Action
	{
		// Token: 0x060160D7 RID: 90327 RVA: 0x006A9C80 File Offset: 0x006A8080
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node35()
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

		// Token: 0x060160D8 RID: 90328 RVA: 0x006A9D10 File Offset: 0x006A8110
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F974 RID: 63860
		private List<Input> method_p0;

		// Token: 0x0400F975 RID: 63861
		private bool method_p1;
	}
}
