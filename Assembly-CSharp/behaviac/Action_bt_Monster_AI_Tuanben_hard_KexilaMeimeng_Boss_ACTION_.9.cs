using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C20 RID: 15392
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node20 : Action
	{
		// Token: 0x06015FEB RID: 90091 RVA: 0x006A52B8 File Offset: 0x006A36B8
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node20()
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
			item.skillID = 21068;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015FEC RID: 90092 RVA: 0x006A5348 File Offset: 0x006A3748
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F86A RID: 63594
		private List<Input> method_p0;

		// Token: 0x0400F86B RID: 63595
		private bool method_p1;
	}
}
