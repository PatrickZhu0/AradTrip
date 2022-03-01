using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A2C RID: 14892
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node15 : Action
	{
		// Token: 0x06015C22 RID: 89122 RVA: 0x00692400 File Offset: 0x00690800
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node15()
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
			item.skillID = 21067;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C23 RID: 89123 RVA: 0x00692490 File Offset: 0x00690890
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F53D RID: 62781
		private List<Input> method_p0;

		// Token: 0x0400F53E RID: 62782
		private bool method_p1;
	}
}
