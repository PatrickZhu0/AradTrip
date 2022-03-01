using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003597 RID: 13719
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node8 : Action
	{
		// Token: 0x0601535E RID: 86878 RVA: 0x006648F4 File Offset: 0x00662CF4
		public Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node8()
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
			item.skillID = 5171;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601535F RID: 86879 RVA: 0x00664984 File Offset: 0x00662D84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED25 RID: 60709
		private List<Input> method_p0;

		// Token: 0x0400ED26 RID: 60710
		private bool method_p1;
	}
}
