using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004049 RID: 16457
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node28 : Action
	{
		// Token: 0x060167F1 RID: 92145 RVA: 0x006CF04C File Offset: 0x006CD44C
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node28()
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
			item.skillID = 5112;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060167F2 RID: 92146 RVA: 0x006CF0DC File Offset: 0x006CD4DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401003C RID: 65596
		private List<Input> method_p0;

		// Token: 0x0401003D RID: 65597
		private bool method_p1;
	}
}
