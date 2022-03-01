using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F87 RID: 12167
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node27 : Action
	{
		// Token: 0x060147DC RID: 83932 RVA: 0x0062A6D0 File Offset: 0x00628AD0
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node27()
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
			item.skillID = 5534;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060147DD RID: 83933 RVA: 0x0062A760 File Offset: 0x00628B60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E142 RID: 57666
		private List<Input> method_p0;

		// Token: 0x0400E143 RID: 57667
		private bool method_p1;
	}
}
