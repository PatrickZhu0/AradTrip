using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EDC RID: 7900
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Action_node55 : Action
	{
		// Token: 0x0601275D RID: 75613 RVA: 0x005665E4 File Offset: 0x005649E4
		public Action_bt_AutoFight_AutoFight_Fightergirl_Action_node55()
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
			item.skillID = 3208;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601275E RID: 75614 RVA: 0x00566674 File Offset: 0x00564A74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C150 RID: 49488
		private List<Input> method_p0;

		// Token: 0x0400C151 RID: 49489
		private bool method_p1;
	}
}
