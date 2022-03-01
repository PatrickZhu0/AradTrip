using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031CA RID: 12746
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node64 : Action
	{
		// Token: 0x06014C27 RID: 85031 RVA: 0x006400CC File Offset: 0x0063E4CC
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node64()
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
			item.skillID = 21569;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C28 RID: 85032 RVA: 0x0064015C File Offset: 0x0063E55C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E57D RID: 58749
		private List<Input> method_p0;

		// Token: 0x0400E57E RID: 58750
		private bool method_p1;
	}
}
