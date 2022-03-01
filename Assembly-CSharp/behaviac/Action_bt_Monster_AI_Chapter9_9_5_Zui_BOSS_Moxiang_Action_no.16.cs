using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031CD RID: 12749
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node68 : Action
	{
		// Token: 0x06014C2D RID: 85037 RVA: 0x00640208 File Offset: 0x0063E608
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node68()
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
			item.skillID = 21570;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C2E RID: 85038 RVA: 0x00640298 File Offset: 0x0063E698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E581 RID: 58753
		private List<Input> method_p0;

		// Token: 0x0400E582 RID: 58754
		private bool method_p1;
	}
}
