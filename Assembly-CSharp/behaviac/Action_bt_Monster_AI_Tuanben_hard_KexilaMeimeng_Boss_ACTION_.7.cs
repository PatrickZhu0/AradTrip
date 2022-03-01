using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C18 RID: 15384
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node31 : Action
	{
		// Token: 0x06015FDB RID: 90075 RVA: 0x006A4F68 File Offset: 0x006A3368
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node31()
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
			item.skillID = 21474;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015FDC RID: 90076 RVA: 0x006A4FF8 File Offset: 0x006A33F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F85A RID: 63578
		private List<Input> method_p0;

		// Token: 0x0400F85B RID: 63579
		private bool method_p1;
	}
}
