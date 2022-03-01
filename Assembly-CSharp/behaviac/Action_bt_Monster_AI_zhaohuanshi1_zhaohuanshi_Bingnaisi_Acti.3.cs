using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200402D RID: 16429
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node17 : Action
	{
		// Token: 0x060167BB RID: 92091 RVA: 0x006CDF80 File Offset: 0x006CC380
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node17()
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

		// Token: 0x060167BC RID: 92092 RVA: 0x006CE010 File Offset: 0x006CC410
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010008 RID: 65544
		private List<Input> method_p0;

		// Token: 0x04010009 RID: 65545
		private bool method_p1;
	}
}
