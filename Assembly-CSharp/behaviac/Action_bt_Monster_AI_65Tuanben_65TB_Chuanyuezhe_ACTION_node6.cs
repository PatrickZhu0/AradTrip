using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B66 RID: 11110
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node62 : Action
	{
		// Token: 0x06013FDA RID: 81882 RVA: 0x0060006C File Offset: 0x005FE46C
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node62()
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
			item.skillID = 21852;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013FDB RID: 81883 RVA: 0x006000FC File Offset: 0x005FE4FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9EE RID: 55790
		private List<Input> method_p0;

		// Token: 0x0400D9EF RID: 55791
		private bool method_p1;
	}
}
