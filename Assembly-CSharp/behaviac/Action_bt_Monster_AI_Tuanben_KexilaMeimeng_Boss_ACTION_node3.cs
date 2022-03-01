using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A24 RID: 14884
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node34 : Action
	{
		// Token: 0x06015C12 RID: 89106 RVA: 0x00692060 File Offset: 0x00690460
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node34()
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
			item.skillID = 21066;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C13 RID: 89107 RVA: 0x006920F0 File Offset: 0x006904F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F529 RID: 62761
		private List<Input> method_p0;

		// Token: 0x0400F52A RID: 62762
		private bool method_p1;
	}
}
