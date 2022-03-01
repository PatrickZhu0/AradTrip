using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004029 RID: 16425
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node13 : Action
	{
		// Token: 0x060167B3 RID: 92083 RVA: 0x006CDDCC File Offset: 0x006CC1CC
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node13()
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
			item.skillID = 5355;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060167B4 RID: 92084 RVA: 0x006CDE5C File Offset: 0x006CC25C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010000 RID: 65536
		private List<Input> method_p0;

		// Token: 0x04010001 RID: 65537
		private bool method_p1;
	}
}
