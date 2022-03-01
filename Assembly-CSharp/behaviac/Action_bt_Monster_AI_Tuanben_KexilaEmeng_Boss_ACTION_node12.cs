using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039EC RID: 14828
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node12 : Action
	{
		// Token: 0x06015BA8 RID: 89000 RVA: 0x0068FB8C File Offset: 0x0068DF8C
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node12()
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
			item.skillID = 21056;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015BA9 RID: 89001 RVA: 0x0068FC1C File Offset: 0x0068E01C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4E6 RID: 62694
		private List<Input> method_p0;

		// Token: 0x0400F4E7 RID: 62695
		private bool method_p1;
	}
}
