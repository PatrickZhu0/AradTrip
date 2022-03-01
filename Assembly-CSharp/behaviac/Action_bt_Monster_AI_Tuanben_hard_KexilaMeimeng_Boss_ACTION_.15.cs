using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C3D RID: 15421
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node34 : Action
	{
		// Token: 0x06016024 RID: 90148 RVA: 0x006A69E4 File Offset: 0x006A4DE4
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node34()
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
			item.skillID = 21066;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016025 RID: 90149 RVA: 0x006A6A74 File Offset: 0x006A4E74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F89A RID: 63642
		private List<Input> method_p0;

		// Token: 0x0400F89B RID: 63643
		private bool method_p1;
	}
}
