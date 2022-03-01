using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C95 RID: 15509
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node32 : Action
	{
		// Token: 0x060160D1 RID: 90321 RVA: 0x006A9B14 File Offset: 0x006A7F14
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node32()
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
			item.skillID = 21062;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060160D2 RID: 90322 RVA: 0x006A9BA4 File Offset: 0x006A7FA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F96D RID: 63853
		private List<Input> method_p0;

		// Token: 0x0400F96E RID: 63854
		private bool method_p1;
	}
}
