using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FF1 RID: 16369
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node12 : Action
	{
		// Token: 0x06016748 RID: 91976 RVA: 0x006CB944 File Offset: 0x006C9D44
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node12()
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

		// Token: 0x06016749 RID: 91977 RVA: 0x006CB9D4 File Offset: 0x006C9DD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF99 RID: 65433
		private List<Input> method_p0;

		// Token: 0x0400FF9A RID: 65434
		private bool method_p1;
	}
}
