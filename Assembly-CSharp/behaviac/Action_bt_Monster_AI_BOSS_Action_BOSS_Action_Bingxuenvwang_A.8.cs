using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F96 RID: 12182
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node42 : Action
	{
		// Token: 0x060147FA RID: 83962 RVA: 0x0062ACC4 File Offset: 0x006290C4
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node42()
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
			item.skillID = 5532;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060147FB RID: 83963 RVA: 0x0062AD54 File Offset: 0x00629154
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E15D RID: 57693
		private List<Input> method_p0;

		// Token: 0x0400E15E RID: 57694
		private bool method_p1;
	}
}
