using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F8C RID: 12172
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node32 : Action
	{
		// Token: 0x060147E6 RID: 83942 RVA: 0x0062A8CC File Offset: 0x00628CCC
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node32()
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
			item.skillID = 5545;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060147E7 RID: 83943 RVA: 0x0062A95C File Offset: 0x00628D5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E14B RID: 57675
		private List<Input> method_p0;

		// Token: 0x0400E14C RID: 57676
		private bool method_p1;
	}
}
