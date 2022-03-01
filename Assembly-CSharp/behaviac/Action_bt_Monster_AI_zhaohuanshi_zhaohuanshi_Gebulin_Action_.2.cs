using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003F94 RID: 16276
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node13 : Action
	{
		// Token: 0x06016692 RID: 91794 RVA: 0x006C7954 File Offset: 0x006C5D54
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node13()
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
			item.skillID = 5110;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016693 RID: 91795 RVA: 0x006C79E4 File Offset: 0x006C5DE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEE5 RID: 65253
		private List<Input> method_p0;

		// Token: 0x0400FEE6 RID: 65254
		private bool method_p1;
	}
}
