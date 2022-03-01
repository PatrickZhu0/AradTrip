using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002FA5 RID: 12197
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node57 : Action
	{
		// Token: 0x06014818 RID: 83992 RVA: 0x0062B2B8 File Offset: 0x006296B8
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node57()
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
			item.skillID = 5546;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014819 RID: 83993 RVA: 0x0062B348 File Offset: 0x00629748
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E178 RID: 57720
		private List<Input> method_p0;

		// Token: 0x0400E179 RID: 57721
		private bool method_p1;
	}
}
