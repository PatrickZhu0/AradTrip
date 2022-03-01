using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FAC RID: 16300
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node43 : Action
	{
		// Token: 0x060166C2 RID: 91842 RVA: 0x006C838C File Offset: 0x006C678C
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node43()
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

		// Token: 0x060166C3 RID: 91843 RVA: 0x006C841C File Offset: 0x006C681C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF15 RID: 65301
		private List<Input> method_p0;

		// Token: 0x0400FF16 RID: 65302
		private bool method_p1;
	}
}
