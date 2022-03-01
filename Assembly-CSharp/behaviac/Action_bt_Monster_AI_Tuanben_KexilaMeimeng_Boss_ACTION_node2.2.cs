using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A31 RID: 14897
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node24 : Action
	{
		// Token: 0x06015C2C RID: 89132 RVA: 0x006925A0 File Offset: 0x006909A0
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node24()
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
			item.skillID = 21064;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C2D RID: 89133 RVA: 0x00692630 File Offset: 0x00690A30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F544 RID: 62788
		private List<Input> method_p0;

		// Token: 0x0400F545 RID: 62789
		private bool method_p1;
	}
}
