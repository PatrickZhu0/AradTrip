using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B5C RID: 15196
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node31 : Action
	{
		// Token: 0x06015E6D RID: 89709 RVA: 0x0069DBA8 File Offset: 0x0069BFA8
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node31()
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
			item.skillID = 21081;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015E6E RID: 89710 RVA: 0x0069DC38 File Offset: 0x0069C038
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F73A RID: 63290
		private List<Input> method_p0;

		// Token: 0x0400F73B RID: 63291
		private bool method_p1;
	}
}
