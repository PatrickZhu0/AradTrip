using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003F90 RID: 16272
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node8 : Action
	{
		// Token: 0x0601668A RID: 91786 RVA: 0x006C77A0 File Offset: 0x006C5BA0
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node8()
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
			item.skillID = 5109;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601668B RID: 91787 RVA: 0x006C7830 File Offset: 0x006C5C30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEDD RID: 65245
		private List<Input> method_p0;

		// Token: 0x0400FEDE RID: 65246
		private bool method_p1;
	}
}
