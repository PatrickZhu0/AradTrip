using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003CA7 RID: 15527
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node66 : Action
	{
		// Token: 0x060160F5 RID: 90357 RVA: 0x006AA304 File Offset: 0x006A8704
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node66()
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
			item.skillID = 21050;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060160F6 RID: 90358 RVA: 0x006AA394 File Offset: 0x006A8794
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F99B RID: 63899
		private List<Input> method_p0;

		// Token: 0x0400F99C RID: 63900
		private bool method_p1;
	}
}
