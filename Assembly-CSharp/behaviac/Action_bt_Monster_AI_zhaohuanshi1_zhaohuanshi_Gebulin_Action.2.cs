using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200403D RID: 16445
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node13 : Action
	{
		// Token: 0x060167D9 RID: 92121 RVA: 0x006CEB30 File Offset: 0x006CCF30
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node13()
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

		// Token: 0x060167DA RID: 92122 RVA: 0x006CEBC0 File Offset: 0x006CCFC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010024 RID: 65572
		private List<Input> method_p0;

		// Token: 0x04010025 RID: 65573
		private bool method_p1;
	}
}
