using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A35 RID: 14901
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node31 : Action
	{
		// Token: 0x06015C34 RID: 89140 RVA: 0x00692720 File Offset: 0x00690B20
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node31()
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
			item.skillID = 21065;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C35 RID: 89141 RVA: 0x006927B0 File Offset: 0x00690BB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F54B RID: 62795
		private List<Input> method_p0;

		// Token: 0x0400F54C RID: 62796
		private bool method_p1;
	}
}
