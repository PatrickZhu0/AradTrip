using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B96 RID: 15254
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node56 : Action
	{
		// Token: 0x06015EDC RID: 89820 RVA: 0x006A0320 File Offset: 0x0069E720
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node56()
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
			item.skillID = 21174;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015EDD RID: 89821 RVA: 0x006A03B0 File Offset: 0x0069E7B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F78E RID: 63374
		private List<Input> method_p0;

		// Token: 0x0400F78F RID: 63375
		private bool method_p1;
	}
}
