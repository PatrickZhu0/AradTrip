using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A79 RID: 14969
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node70 : Action
	{
		// Token: 0x06015CBB RID: 89275 RVA: 0x00694CD0 File Offset: 0x006930D0
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node70()
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
			item.skillID = 21054;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015CBC RID: 89276 RVA: 0x00694D60 File Offset: 0x00693160
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5F5 RID: 62965
		private List<Input> method_p0;

		// Token: 0x0400F5F6 RID: 62966
		private bool method_p1;
	}
}
