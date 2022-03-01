using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A5C RID: 14940
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node24 : Action
	{
		// Token: 0x06015C81 RID: 89217 RVA: 0x00693FF4 File Offset: 0x006923F4
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node24()
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
			item.skillID = 21061;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C82 RID: 89218 RVA: 0x00694084 File Offset: 0x00692484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5AE RID: 62894
		private List<Input> method_p0;

		// Token: 0x0400F5AF RID: 62895
		private bool method_p1;
	}
}
