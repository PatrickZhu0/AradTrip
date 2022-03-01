using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C45 RID: 15429
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node15 : Action
	{
		// Token: 0x06016034 RID: 90164 RVA: 0x006A6D84 File Offset: 0x006A5184
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node15()
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
			item.skillID = 21067;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016035 RID: 90165 RVA: 0x006A6E14 File Offset: 0x006A5214
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8AE RID: 63662
		private List<Input> method_p0;

		// Token: 0x0400F8AF RID: 63663
		private bool method_p1;
	}
}
