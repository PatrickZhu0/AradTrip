using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F3B RID: 12091
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node12 : Action
	{
		// Token: 0x06014747 RID: 83783 RVA: 0x00627680 File Offset: 0x00625A80
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node12()
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

		// Token: 0x06014748 RID: 83784 RVA: 0x00627710 File Offset: 0x00625B10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0B7 RID: 57527
		private List<Input> method_p0;

		// Token: 0x0400E0B8 RID: 57528
		private bool method_p1;
	}
}
