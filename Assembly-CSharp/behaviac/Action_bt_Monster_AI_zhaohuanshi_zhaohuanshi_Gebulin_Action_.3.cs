using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003F98 RID: 16280
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node18 : Action
	{
		// Token: 0x0601669A RID: 91802 RVA: 0x006C7B08 File Offset: 0x006C5F08
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node18()
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
			item.skillID = 5111;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601669B RID: 91803 RVA: 0x006C7B98 File Offset: 0x006C5F98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEED RID: 65261
		private List<Input> method_p0;

		// Token: 0x0400FEEE RID: 65262
		private bool method_p1;
	}
}
