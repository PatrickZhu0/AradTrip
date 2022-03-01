using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F2C RID: 7980
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node24 : Action
	{
		// Token: 0x060127FB RID: 75771 RVA: 0x0056A2B4 File Offset: 0x005686B4
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node24()
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
			item.skillID = 3202;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127FC RID: 75772 RVA: 0x0056A344 File Offset: 0x00568744
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1F2 RID: 49650
		private List<Input> method_p0;

		// Token: 0x0400C1F3 RID: 49651
		private bool method_p1;
	}
}
