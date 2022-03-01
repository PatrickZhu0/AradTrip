using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F37 RID: 12087
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node8 : Action
	{
		// Token: 0x0601473F RID: 83775 RVA: 0x006274CC File Offset: 0x006258CC
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node8()
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
			item.skillID = 5000;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014740 RID: 83776 RVA: 0x0062755C File Offset: 0x0062595C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0AF RID: 57519
		private List<Input> method_p0;

		// Token: 0x0400E0B0 RID: 57520
		private bool method_p1;
	}
}
