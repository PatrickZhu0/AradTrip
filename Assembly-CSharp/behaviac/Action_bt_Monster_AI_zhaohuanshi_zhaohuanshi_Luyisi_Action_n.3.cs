using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FD8 RID: 16344
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node20 : Action
	{
		// Token: 0x06016718 RID: 91928 RVA: 0x006CA7C4 File Offset: 0x006C8BC4
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node20()
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
			item.skillID = 5353;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016719 RID: 91929 RVA: 0x006CA854 File Offset: 0x006C8C54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF6A RID: 65386
		private List<Input> method_p0;

		// Token: 0x0400FF6B RID: 65387
		private bool method_p1;
	}
}
