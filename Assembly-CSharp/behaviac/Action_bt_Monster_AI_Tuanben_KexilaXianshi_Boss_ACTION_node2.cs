using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A58 RID: 14936
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node20 : Action
	{
		// Token: 0x06015C79 RID: 89209 RVA: 0x00693E28 File Offset: 0x00692228
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node20()
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
			item.skillID = 21052;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C7A RID: 89210 RVA: 0x00693EB8 File Offset: 0x006922B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5A4 RID: 62884
		private List<Input> method_p0;

		// Token: 0x0400F5A5 RID: 62885
		private bool method_p1;
	}
}
