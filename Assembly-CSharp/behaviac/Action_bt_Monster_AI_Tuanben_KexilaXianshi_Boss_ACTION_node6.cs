using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A75 RID: 14965
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node66 : Action
	{
		// Token: 0x06015CB3 RID: 89267 RVA: 0x00694B1C File Offset: 0x00692F1C
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node66()
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
			item.skillID = 21050;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015CB4 RID: 89268 RVA: 0x00694BAC File Offset: 0x00692FAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5ED RID: 62957
		private List<Input> method_p0;

		// Token: 0x0400F5EE RID: 62958
		private bool method_p1;
	}
}
