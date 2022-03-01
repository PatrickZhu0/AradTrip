using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C75 RID: 15477
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node12 : Action
	{
		// Token: 0x06016091 RID: 90257 RVA: 0x006A8DA0 File Offset: 0x006A71A0
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node12()
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
			item.skillID = 21455;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016092 RID: 90258 RVA: 0x006A8E30 File Offset: 0x006A7230
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F91C RID: 63772
		private List<Input> method_p0;

		// Token: 0x0400F91D RID: 63773
		private bool method_p1;
	}
}
