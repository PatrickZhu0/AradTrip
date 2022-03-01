using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FD4 RID: 16340
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node15 : Action
	{
		// Token: 0x06016710 RID: 91920 RVA: 0x006CA610 File Offset: 0x006C8A10
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node15()
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
			item.skillID = 5023;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016711 RID: 91921 RVA: 0x006CA6A0 File Offset: 0x006C8AA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF62 RID: 65378
		private List<Input> method_p0;

		// Token: 0x0400FF63 RID: 65379
		private bool method_p1;
	}
}
