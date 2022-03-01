using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A6D RID: 14957
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node44 : Action
	{
		// Token: 0x06015CA3 RID: 89251 RVA: 0x006947D0 File Offset: 0x00692BD0
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node44()
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

		// Token: 0x06015CA4 RID: 89252 RVA: 0x00694860 File Offset: 0x00692C60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5D7 RID: 62935
		private List<Input> method_p0;

		// Token: 0x0400F5D8 RID: 62936
		private bool method_p1;
	}
}
