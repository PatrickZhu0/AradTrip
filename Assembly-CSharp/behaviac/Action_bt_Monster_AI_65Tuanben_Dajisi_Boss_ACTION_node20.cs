using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D85 RID: 11653
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node20 : Action
	{
		// Token: 0x060143EC RID: 82924 RVA: 0x00614AB8 File Offset: 0x00612EB8
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node20()
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
			item.skillID = 21602;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143ED RID: 82925 RVA: 0x00614B48 File Offset: 0x00612F48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDBF RID: 56767
		private List<Input> method_p0;

		// Token: 0x0400DDC0 RID: 56768
		private bool method_p1;
	}
}
