using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039EA RID: 14826
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node15 : Action
	{
		// Token: 0x06015BA4 RID: 88996 RVA: 0x0068FA98 File Offset: 0x0068DE98
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node15()
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
			item.skillID = 21072;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015BA5 RID: 88997 RVA: 0x0068FB28 File Offset: 0x0068DF28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4E3 RID: 62691
		private List<Input> method_p0;

		// Token: 0x0400F4E4 RID: 62692
		private bool method_p1;
	}
}
