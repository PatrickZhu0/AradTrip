using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F0E RID: 7950
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node29 : Action
	{
		// Token: 0x060127C0 RID: 75712 RVA: 0x005685B8 File Offset: 0x005669B8
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node29()
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
			item.skillID = 3120;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127C1 RID: 75713 RVA: 0x00568648 File Offset: 0x00566A48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1B5 RID: 49589
		private List<Input> method_p0;

		// Token: 0x0400C1B6 RID: 49590
		private bool method_p1;
	}
}
