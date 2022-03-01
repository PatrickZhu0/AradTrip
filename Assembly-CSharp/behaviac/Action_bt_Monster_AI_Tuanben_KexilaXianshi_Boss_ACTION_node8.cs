using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A3E RID: 14910
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node81 : Action
	{
		// Token: 0x06015C45 RID: 89157 RVA: 0x0069339C File Offset: 0x0069179C
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node81()
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
			item.skillID = 21053;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C46 RID: 89158 RVA: 0x0069342C File Offset: 0x0069182C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F560 RID: 62816
		private List<Input> method_p0;

		// Token: 0x0400F561 RID: 62817
		private bool method_p1;
	}
}
