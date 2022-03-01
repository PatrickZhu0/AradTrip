using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C83 RID: 15491
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node7 : Action
	{
		// Token: 0x060160AD RID: 90285 RVA: 0x006A92D8 File Offset: 0x006A76D8
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node7()
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
			item.skillID = 21472;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060160AE RID: 90286 RVA: 0x006A9368 File Offset: 0x006A7768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F941 RID: 63809
		private List<Input> method_p0;

		// Token: 0x0400F942 RID: 63810
		private bool method_p1;
	}
}
