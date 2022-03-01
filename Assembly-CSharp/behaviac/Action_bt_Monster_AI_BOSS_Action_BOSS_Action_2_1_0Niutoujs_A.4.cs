using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F50 RID: 12112
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node22 : Action
	{
		// Token: 0x06014770 RID: 83824 RVA: 0x00628324 File Offset: 0x00626724
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node22()
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
			item.skillID = 5451;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014771 RID: 83825 RVA: 0x006283B4 File Offset: 0x006267B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0DF RID: 57567
		private List<Input> method_p0;

		// Token: 0x0400E0E0 RID: 57568
		private bool method_p1;
	}
}
