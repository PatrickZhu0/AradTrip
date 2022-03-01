using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DEB RID: 11755
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node10 : Action
	{
		// Token: 0x060144B3 RID: 83123 RVA: 0x00618CBC File Offset: 0x006170BC
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node10()
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
			item.skillID = 21623;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060144B4 RID: 83124 RVA: 0x00618D4C File Offset: 0x0061714C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE6B RID: 56939
		private List<Input> method_p0;

		// Token: 0x0400DE6C RID: 56940
		private bool method_p1;
	}
}
