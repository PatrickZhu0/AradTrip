using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A28 RID: 14888
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node20 : Action
	{
		// Token: 0x06015C1A RID: 89114 RVA: 0x00692230 File Offset: 0x00690630
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node20()
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
			item.skillID = 21068;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C1B RID: 89115 RVA: 0x006922C0 File Offset: 0x006906C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F533 RID: 62771
		private List<Input> method_p0;

		// Token: 0x0400F534 RID: 62772
		private bool method_p1;
	}
}
