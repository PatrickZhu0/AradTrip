using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F7D RID: 12157
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node17 : Action
	{
		// Token: 0x060147C8 RID: 83912 RVA: 0x0062A2D8 File Offset: 0x006286D8
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node17()
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
			item.skillID = 5544;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060147C9 RID: 83913 RVA: 0x0062A368 File Offset: 0x00628768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E130 RID: 57648
		private List<Input> method_p0;

		// Token: 0x0400E131 RID: 57649
		private bool method_p1;
	}
}
